using SX.Shared.Certificates.Models;
using SX.Shared.Certificates.Services;
using SX.Shared.Exceptions;
using SX.Shared.Models;
using System.Security.Cryptography.X509Certificates;

namespace SX.Win.Tools.Forms
{
    public partial class SignerForm : Form
    {
        protected CryptoProService _cryptoProService = new CryptoProService();
        protected CertificateValidator _validator = new CertificateValidator();

        public SignerForm()
        {
            InitializeComponent();
        }

        #region Вспомогательные функции
        private CertificateValidationOptions GetValidationOptions()
        {
            return new CertificateValidationOptions()
            {
                LogCorrectMessages = true
            };
        }

        private void AddLog(string message)
        {
            this.textBox_check_result.Text += Environment.NewLine + message;
        }

        private FileData ReadFileData(string path)
        {
            if (!File.Exists(path))
                return null;

            var filename = (new FileInfo(path)).Name;
            var filedata = File.ReadAllBytes(path);

            return new FileData(filename, filedata);
        }

        private void SetValidationResultText(LogResult validation, bool append = false)
        {
            var text = String.Join(Environment.NewLine, validation.Messages.Select(item => item.ToString()));

            if (append)
                this.textBox_check_result.Text += Environment.NewLine + Environment.NewLine + text;
            else
                this.textBox_check_result.Text = text;
        }

        private CertificateX509 SelectedCertificate
        { get { return this.comboBox_certificate_list.SelectedItem as CertificateX509; } }

        private void FillCertificatesList(params CertificateX509[] certificates)
        {
            //очищаем список сертификатов в выпадающем списке
            this.comboBox_certificate_list.Items.Clear();

            //добавляем каждый сертификат в выпадающий список
            foreach (var cert in certificates)
                if (cert.IssuerCommonName != "DO_NOT_TRUST_FiddlerRoot")
                    this.comboBox_certificate_list.Items.Add(cert);

            //если ксть хотябы 1 сертификат, выбираем его в выпадающем списке
            if (this.comboBox_certificate_list.Items.Count > 0)
                this.comboBox_certificate_list.SelectedIndex = 0;
        }

        private void ValidateCertificate(CertificateX509 certificate)
        {
            //очищаем поле проверки сертификата
            this.textBox_check_result.Text = "";

            //выводим информацию о проверке самого сертификата
            if (certificate != null)
            {
                var validation = _validator.Validate(certificate, this.GetValidationOptions());

                validation.AddInfo("certificate result INN =" + this.GetCertificateINN(validation, certificate as CertificateX509));

                this.SetValidationResultText(validation);
            }
        }
        #endregion

        #region Работа с Сертификатами
        private void comboBox_certificate_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            //определяем выбранный в выпадающем списке сертификат
            var certificate = this.SelectedCertificate;

            //перезагружаем информацию о сертификате в поля формы
            this.textBox_cert_subject.Text = certificate == null ? "" : certificate.Subject;
            this.textBox_cert_serial_number.Text = certificate == null ? "" : certificate.SerialNumber;

            //запускаем проверку сертификата
            this.ValidateCertificate(certificate);
        }

        private void button_certificate_show_Click(object sender, EventArgs e)
        {
            //определяем выбранный в выпадающем списке сертификат
            var certificate = this.SelectedCertificate;

            //показываем стандартное (windows) окно сертификата
            if (certificate != null && certificate.X509 != null)
                X509Certificate2UI.DisplayCertificate(certificate.X509);
        }

        private void button_certificate_check_Click(object sender, EventArgs e)
        {
            //определяем выбранный в выпадающем списке сертификат
            var certificate = this.SelectedCertificate;

            certificate = new CertificateX509(certificate.X509);

            //запускаем проверку сертификата
            this.ValidateCertificate(certificate);
        }

        private void button_certificate_from_store_Click(object sender, EventArgs e)
        {
            //перезагружаем список доступных сертификатов из личного хранилища
            var certificates = _cryptoProService.GetCertificatesFromStore();

            this.FillCertificatesList(certificates.ToArray());
        }

        private void button_certificate_from_file_Click(object sender, EventArgs e)
        {
            var openCertForm = new OpenCertificateForm();
            if (openCertForm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            if (!File.Exists(openCertForm.FileName))
            {
                MessageBox.Show("Указанный файл не существует");
                return;
            }

            byte[] data = File.ReadAllBytes(openCertForm.FileName);
            if (data == null || data.Length <= 0)
            {
                MessageBox.Show("Указан пустой файл");
                return;
            }

            var cert = _cryptoProService.GetCertificateFromFile(File.ReadAllBytes(openCertForm.FileName), openCertForm.Password);
            if (cert == null)
            {
                MessageBox.Show("Невозможно открыть файл с сертификатом");
                return;
            }

            this.FillCertificatesList(cert);
        }
        #endregion

        #region Формирование Подписи
        private void button_browse_to_sign_Click(object sender, EventArgs e)
        {
            //просто выбираем файл, который будем подписывать
            if (this.openFileDialog_file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.textBox_sign_file.Text = this.openFileDialog_file.FileName;

            //очищаем имя файла в диалоговом окне (чтобы каждый раз выбирать новый файл)
            this.openFileDialog_file.FileName = "";
        }

        private void button_sign_Click(object sender, EventArgs e)
        {
            //определяем выбранный в выпадающем списке сертификат
            var certificate = this.SelectedCertificate;

            //если по какой-то причине сертификат не выбран
            if (certificate == null || certificate.X509 == null)
            {
                MessageBox.Show("Необходимо выбрать сертификат!");
                return;
            }

            //проверяем, что указан файл, который будем подписывать
            if (this.textBox_sign_file.Text.Trim() == "")
            {
                MessageBox.Show("Необходимо выбрать файл для подписи");
                return;
            }

            //читаем файл, который будем подписывать
            byte[] original_data = File.ReadAllBytes(this.textBox_sign_file.Text);
            if (original_data == null)
            {
                MessageBox.Show("Выбран не корректный файл для подписи");
                return;
            }

            this.AddLog("ORIGINAL_BASE64" + Environment.NewLine + Environment.NewLine + Convert.ToBase64String(original_data) + Environment.NewLine + Environment.NewLine);

            // данные подписи
            byte[] signed_data = null;

            // подписывать ли хэш или оригинальный данные
            if (this.checkBox_sign_hash.Checked)
            {
                throw new CustomNotImplementedException("Необходимо реализовать на .net core функцию HashData, использующую CryptoPro Sharpei (только в .net core)!");
                //var hash_data = _cryptoProService.HashData(original_data, certificate.SerialNumber);

                //this.AddLog(String.Join(string.Empty, hash_data.Select(x => x.ToString("X2"))));
                //signed_data = _cryptoProService.SignHash(hash_data, certificate.SerialNumber);

            }
            else
            {
                // подписываем файл и сохраняем подпись
                signed_data = _cryptoProService.SignData(original_data, certificate.SerialNumber);

            }

            //сохраняем файл с подпсиью
            if (this.saveFileDialog_sign.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllBytes(this.saveFileDialog_sign.FileName, signed_data);
                MessageBox.Show("Файл с подписью сохранен успешно!");
                return;
            }
        }
        #endregion

        #region Проверка Подписи
        private void checkBox_check_detached_CheckedChanged(object sender, EventArgs e)
        {
            this.label_check_file.Visible = this.checkBox_check_detached.Checked;
            this.textBox_check_file.Visible = this.checkBox_check_detached.Checked;
            this.button_browse_to_check_file.Visible = this.checkBox_check_detached.Checked;
        }

        private void button_browse_to_check_sign_Click(object sender, EventArgs e)
        {
            //выбираем файл содержащий подпись
            if (this.openFileDialog_sign.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.textBox_check_sign.Text = this.openFileDialog_sign.FileName;

            this.openFileDialog_sign.FileName = "";
        }

        private void button_browse_to_check_file_Click(object sender, EventArgs e)
        {
            //выбираем файл содержащий оригинальные данные 
            //только в случае отсоединенной подписи
            if (this.openFileDialog_file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.textBox_check_file.Text = this.openFileDialog_file.FileName;

            this.openFileDialog_file.FileName = "";
        }

        private void button_check_Click(object sender, EventArgs e)
        {
            this.textBox_check_result.Text = "";

            //проверяем, что указан файл с подписью
            if (this.textBox_check_sign.Text.Trim() == "")
            {
                MessageBox.Show("Необходимо выбрать файл, содержащий подпись");
                return;
            }

            //читаем файл с подписью
            var signature = this.ReadFileData(this.textBox_check_sign.Text);
            if (signature == null)
            {
                MessageBox.Show("Выбран не корректный файл с подписью");
                return;
            }

            //определяем параметр подписания:
            // true - значит подпись отделенная (в файле с подписью есть только подпись и содержимое нужно указывать отдельно)
            // false - значит подпись будет присоединенная (в файле с подписью будет и сама подпись и сами данные, которые подписывались)
            bool detached = this.checkBox_check_detached.Checked;

            FileData original = null;

            if (detached)
            {//отсоединенная подпись

                //проверяем, что указан файл с оригинальными данными
                if (this.textBox_check_file.Text.Trim() == "")
                {
                    MessageBox.Show("Необходимо выбрать файл, содержащий оригинальные данные, которые были подписаны");
                    return;
                }

                //читаем файл с подписью
                original = this.ReadFileData(this.textBox_check_file.Text);
                if (original == null)
                {
                    MessageBox.Show("Выбран не корректный файл с оригинальными данными");
                    return;
                }
            }

            //var signer = new CertificateSigner(signature, original);

            var verification = _cryptoProService.VerifySignature(original, signature, out CertificateX509 certificate);

            if (certificate != null)
            {
                this.FillCertificatesList(certificate);

                verification.AddInfo("");
                verification.AddInfo("");
                verification.Messages.AddRange(_validator.Validate(certificate, this.GetValidationOptions()).Messages);
            }

            this.SetValidationResultText(verification);
        }
        #endregion



        #region отладочные функции
        private string GetCertificateINN(CertificateValidation validation, CertificateX509 certificate)
        {
            if (certificate == null)
                return "";

            var inn = "";

            if (String.IsNullOrEmpty(inn))
                inn = this.GetCertificateProperty(validation, certificate, "INNLE");
            if (String.IsNullOrEmpty(inn))
                inn = this.GetCertificateProperty(validation, certificate, "OID.1.2.643.100.4");
            if (String.IsNullOrEmpty(inn))
                inn = this.GetCertificateProperty(validation, certificate, "1.2.643.100.4");

            if (String.IsNullOrEmpty(inn))
                inn = this.GetCertificateProperty(validation, certificate, "ИНН");
            if (String.IsNullOrEmpty(inn))
                inn = this.GetCertificateProperty(validation, certificate, "INN");
            if (String.IsNullOrEmpty(inn))
                inn = this.GetCertificateProperty(validation, certificate, "OID.1.2.643.3.131.1.1");
            if (String.IsNullOrEmpty(inn))
                inn = this.GetCertificateProperty(validation, certificate, "1.2.643.3.131.1.1");

            return inn;
        }

        private string GetCertificateProperty(CertificateValidation validation, CertificateX509 certificate, string name)
        {
            var value = certificate.GetSubjectProperty(name);
            validation.AddInfo($"certificate subj: {name} = {value}");
            return value;
        }

        private string GetCertificateProperty(CertificateX509 certificate, string name)
        {
            var value = certificate.GetSubjectProperty(name) ?? "";
            this.AddLog($"reading property: {name} = {value}");
            return value;
        }
        #endregion

        private void button_read_property_Click(object sender, EventArgs e)
        {
            var cert = new CertificateX509(this.SelectedCertificate.X509);
            this.GetCertificateProperty(cert, this.textBox_property_name.Text);
        }
    }
}
