using SX.Shared;
using SX.Shared.Infrastructure.Models;
using SX.Shared.Infrastructure.Services;
using SX.Shared.Models;
using System.Text;

namespace SX.Win.Tools.Forms
{
    public partial class SendEmailForm : Form
    {
        protected IEnumerable<string>? Attachments { get; set; } = null;

        protected SMTPServerConfig _smtpConfig = new SMTPServerConfig();

        public SendEmailForm()
        {
            InitializeComponent();
        }
        private void SendEmailForm_Load(object sender, EventArgs e)
        {
            _smtpConfig = new SMTPServerConfig(Program.Configuration.GetSection("SMTPServerConfig")?.Value ?? "");

            var now = DateTime.Now;
            this.textBoxSubject.Text = $"Test Subject: {now}";
            this.textBoxBody.Text = $"Test Body: {now}";
            this.textBoxConnectionString.Text = this.GetSmtpConfigText(_smtpConfig);
        }
    
        private string GetSmtpConfigText(SMTPServerConfig config)
        {
            if (config == null)
                return "NULL";

            var sb = new StringBuilder();
            sb.AppendLine($"Server:\t {config.Server}");
            sb.AppendLine($"Port:\t {config.Port}");
            sb.AppendLine($"SSL:\t {config.SSL}");
            sb.AppendLine($"Address:\t {config.Address}");
            sb.AppendLine($"Name:\t {config.Name}");
            sb.AppendLine($"Login:\t {config.Login}");
            //sb.AppendLine($"Password:\t {config.Password}");
            sb.AppendLine($"Protocol:\t {config.SecurityProtocol}");
            sb.AppendLine($"Timeout:\t {config.Timeout}");
            return sb.ToString();
        }

        private void buttonAttachmentsBrowse_Click(object sender, EventArgs e)
        {
            if (this.openFileDialogAttachments.ShowDialog() != DialogResult.OK)
                return;

            this.Attachments = this.openFileDialogAttachments.FileNames;
            this.textBoxAttachments.Text = String.Join(Environment.NewLine, this.Attachments);
        }

        private void buttonAttachmentsClear_Click(object sender, EventArgs e)
        {
            this.Attachments = null;
            this.textBoxAttachments.Text = "";
        }

        private void buttonConnectionStringModify_Click(object sender, EventArgs e)
        {
            var dialog = new SMTPServerConfigForm();
            dialog.SMTPConfig = _smtpConfig;
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            _smtpConfig = dialog.SMTPConfig;
            this.textBoxConnectionString.Text = this.GetSmtpConfigText(_smtpConfig);
        }

        private IEnumerable<FileData>? GetAttachments()
        {
            if (this.Attachments == null || this.Attachments.Count() <= 0)
                return null;

            var attachments = new List<FileData>();
            foreach (var att in this.Attachments)
                attachments.Add(new FileData(att, File.ReadAllBytes(att)));

            return attachments;
        }

        private void buttonSendEmail_Click(object sender, EventArgs e)
        {
            if (_smtpConfig == null)
            {
                MessageBox.Show("Please, specify SMTP config!", "ERROR");
                return;
            }

            if (String.IsNullOrWhiteSpace(this.textBoxRecipient.Text))
            {
                MessageBox.Show("Please, select Recipient!", "ERROR");
                return;
            }
            if (String.IsNullOrWhiteSpace(this.textBoxSubject.Text))
            {
                MessageBox.Show("Please, type in the Subject!", "ERROR");
                return;
            }
            if (String.IsNullOrWhiteSpace(this.textBoxBody.Text))
            {
                MessageBox.Show("Please, type in some Body text!", "ERROR");
                return;
            }

            try
            {
                var emailService = new EmailNotificationService(_smtpConfig);

                var message = new EmailNotificationMessage(
                    this.textBoxSubject.Text,
                    this.textBoxBody.Text,
                    this.textBoxRecipient.Text);

                var attachments = this.GetAttachments();
                if (attachments != null)
                    message.AddAttachments(attachments);

                emailService.SendEmail(message);

                MessageBox.Show("Email was sent successfully!", "SUCCESS");
            }
            catch(Exception ex)
            {
                MessageBox.Show(Helpers.GetErrorMessage(ex), "ERROR");
            }
        }
    }
}
