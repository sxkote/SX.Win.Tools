﻿namespace SX.Win.Tools.Forms
{
    partial class SignerForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox_certificate_list = new System.Windows.Forms.ComboBox();
            this.button_browse_to_sign = new System.Windows.Forms.Button();
            this.textBox_sign_file = new System.Windows.Forms.TextBox();
            this.button_sign = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox_sign = new System.Windows.Forms.GroupBox();
            this.checkBox_sign_hash = new System.Windows.Forms.CheckBox();
            this.checkBox_sign_detached = new System.Windows.Forms.CheckBox();
            this.button_cert_show = new System.Windows.Forms.Button();
            this.button_certificate_check = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_cert_serial_number = new System.Windows.Forms.TextBox();
            this.textBox_cert_subject = new System.Windows.Forms.TextBox();
            this.saveFileDialog_sign = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog_sign = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog_file = new System.Windows.Forms.OpenFileDialog();
            this.groupBox_check = new System.Windows.Forms.GroupBox();
            this.label_check_file = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button_check = new System.Windows.Forms.Button();
            this.checkBox_check_detached = new System.Windows.Forms.CheckBox();
            this.button_browse_to_check_file = new System.Windows.Forms.Button();
            this.button_browse_to_check_sign = new System.Windows.Forms.Button();
            this.textBox_check_file = new System.Windows.Forms.TextBox();
            this.textBox_check_sign = new System.Windows.Forms.TextBox();
            this.textBox_check_result = new System.Windows.Forms.TextBox();
            this.groupBox_result = new System.Windows.Forms.GroupBox();
            this.groupBox_certificates = new System.Windows.Forms.GroupBox();
            this.button_certificate_from_file = new System.Windows.Forms.Button();
            this.button_certificate_from_store = new System.Windows.Forms.Button();
            this.openFileDialog_certificate = new System.Windows.Forms.OpenFileDialog();
            this.groupBox_Properties = new System.Windows.Forms.GroupBox();
            this.button_read_property = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_property_name = new System.Windows.Forms.TextBox();
            this.groupBox_sign.SuspendLayout();
            this.groupBox_check.SuspendLayout();
            this.groupBox_result.SuspendLayout();
            this.groupBox_certificates.SuspendLayout();
            this.groupBox_Properties.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_certificate_list
            // 
            this.comboBox_certificate_list.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_certificate_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_certificate_list.FormattingEnabled = true;
            this.comboBox_certificate_list.Location = new System.Drawing.Point(203, 55);
            this.comboBox_certificate_list.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox_certificate_list.Name = "comboBox_certificate_list";
            this.comboBox_certificate_list.Size = new System.Drawing.Size(473, 23);
            this.comboBox_certificate_list.TabIndex = 0;
            this.comboBox_certificate_list.SelectedIndexChanged += new System.EventHandler(this.comboBox_certificate_list_SelectedIndexChanged);
            // 
            // button_browse_to_sign
            // 
            this.button_browse_to_sign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_browse_to_sign.Location = new System.Drawing.Point(684, 20);
            this.button_browse_to_sign.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_browse_to_sign.Name = "button_browse_to_sign";
            this.button_browse_to_sign.Size = new System.Drawing.Size(108, 27);
            this.button_browse_to_sign.TabIndex = 1;
            this.button_browse_to_sign.Text = "Обзор";
            this.button_browse_to_sign.UseVisualStyleBackColor = true;
            this.button_browse_to_sign.Click += new System.EventHandler(this.button_browse_to_sign_Click);
            // 
            // textBox_sign_file
            // 
            this.textBox_sign_file.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_sign_file.Location = new System.Drawing.Point(203, 22);
            this.textBox_sign_file.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_sign_file.Name = "textBox_sign_file";
            this.textBox_sign_file.ReadOnly = true;
            this.textBox_sign_file.Size = new System.Drawing.Size(473, 23);
            this.textBox_sign_file.TabIndex = 2;
            // 
            // button_sign
            // 
            this.button_sign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_sign.Location = new System.Drawing.Point(589, 72);
            this.button_sign.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_sign.Name = "button_sign";
            this.button_sign.Size = new System.Drawing.Size(88, 27);
            this.button_sign.TabIndex = 3;
            this.button_sign.Text = "Подписать";
            this.button_sign.UseVisualStyleBackColor = true;
            this.button_sign.Click += new System.EventHandler(this.button_sign_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Файл для подписи:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Сертификаты:";
            // 
            // groupBox_sign
            // 
            this.groupBox_sign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_sign.Controls.Add(this.checkBox_sign_hash);
            this.groupBox_sign.Controls.Add(this.checkBox_sign_detached);
            this.groupBox_sign.Controls.Add(this.textBox_sign_file);
            this.groupBox_sign.Controls.Add(this.label1);
            this.groupBox_sign.Controls.Add(this.button_browse_to_sign);
            this.groupBox_sign.Controls.Add(this.button_sign);
            this.groupBox_sign.Location = new System.Drawing.Point(14, 183);
            this.groupBox_sign.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_sign.Name = "groupBox_sign";
            this.groupBox_sign.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_sign.Size = new System.Drawing.Size(799, 105);
            this.groupBox_sign.TabIndex = 6;
            this.groupBox_sign.TabStop = false;
            this.groupBox_sign.Text = "Подписание документов:";
            // 
            // checkBox_sign_hash
            // 
            this.checkBox_sign_hash.AutoSize = true;
            this.checkBox_sign_hash.Enabled = false;
            this.checkBox_sign_hash.Location = new System.Drawing.Point(203, 52);
            this.checkBox_sign_hash.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox_sign_hash.Name = "checkBox_sign_hash";
            this.checkBox_sign_hash.Size = new System.Drawing.Size(222, 19);
            this.checkBox_sign_hash.TabIndex = 15;
            this.checkBox_sign_hash.Text = "Подписывать Hash значение файла";
            this.checkBox_sign_hash.UseVisualStyleBackColor = true;
            // 
            // checkBox_sign_detached
            // 
            this.checkBox_sign_detached.AutoSize = true;
            this.checkBox_sign_detached.Checked = true;
            this.checkBox_sign_detached.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_sign_detached.Location = new System.Drawing.Point(203, 78);
            this.checkBox_sign_detached.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox_sign_detached.Name = "checkBox_sign_detached";
            this.checkBox_sign_detached.Size = new System.Drawing.Size(327, 19);
            this.checkBox_sign_detached.TabIndex = 14;
            this.checkBox_sign_detached.Text = "Отсоединенная подпись (подпись в отдельном файле)";
            this.checkBox_sign_detached.UseVisualStyleBackColor = true;
            // 
            // button_cert_show
            // 
            this.button_cert_show.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cert_show.Location = new System.Drawing.Point(684, 113);
            this.button_cert_show.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_cert_show.Name = "button_cert_show";
            this.button_cert_show.Size = new System.Drawing.Size(108, 27);
            this.button_cert_show.TabIndex = 16;
            this.button_cert_show.Text = "Просмотр";
            this.button_cert_show.UseVisualStyleBackColor = true;
            this.button_cert_show.Click += new System.EventHandler(this.button_certificate_show_Click);
            // 
            // button_certificate_check
            // 
            this.button_certificate_check.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_certificate_check.Location = new System.Drawing.Point(684, 53);
            this.button_certificate_check.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_certificate_check.Name = "button_certificate_check";
            this.button_certificate_check.Size = new System.Drawing.Size(108, 27);
            this.button_certificate_check.TabIndex = 15;
            this.button_certificate_check.Text = "Проверить ЭП";
            this.button_certificate_check.UseVisualStyleBackColor = true;
            this.button_certificate_check.Click += new System.EventHandler(this.button_certificate_check_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 120);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Серийный номер:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Субъект:";
            // 
            // textBox_cert_serial_number
            // 
            this.textBox_cert_serial_number.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_cert_serial_number.Location = new System.Drawing.Point(203, 117);
            this.textBox_cert_serial_number.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_cert_serial_number.Name = "textBox_cert_serial_number";
            this.textBox_cert_serial_number.ReadOnly = true;
            this.textBox_cert_serial_number.Size = new System.Drawing.Size(473, 23);
            this.textBox_cert_serial_number.TabIndex = 8;
            // 
            // textBox_cert_subject
            // 
            this.textBox_cert_subject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_cert_subject.Location = new System.Drawing.Point(203, 87);
            this.textBox_cert_subject.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_cert_subject.Name = "textBox_cert_subject";
            this.textBox_cert_subject.ReadOnly = true;
            this.textBox_cert_subject.Size = new System.Drawing.Size(473, 23);
            this.textBox_cert_subject.TabIndex = 6;
            // 
            // saveFileDialog_sign
            // 
            this.saveFileDialog_sign.Filter = "P7S|*.p7s|P7B|*.p7b|All Files|*.*";
            // 
            // openFileDialog_sign
            // 
            this.openFileDialog_sign.Filter = "P7S|*.p7s|P7B|*.p7b|All Files|*.*";
            // 
            // openFileDialog_file
            // 
            this.openFileDialog_file.Filter = "All Files|*.*";
            // 
            // groupBox_check
            // 
            this.groupBox_check.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_check.Controls.Add(this.label_check_file);
            this.groupBox_check.Controls.Add(this.label7);
            this.groupBox_check.Controls.Add(this.button_check);
            this.groupBox_check.Controls.Add(this.checkBox_check_detached);
            this.groupBox_check.Controls.Add(this.button_browse_to_check_file);
            this.groupBox_check.Controls.Add(this.button_browse_to_check_sign);
            this.groupBox_check.Controls.Add(this.textBox_check_file);
            this.groupBox_check.Controls.Add(this.textBox_check_sign);
            this.groupBox_check.Location = new System.Drawing.Point(14, 295);
            this.groupBox_check.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_check.Name = "groupBox_check";
            this.groupBox_check.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_check.Size = new System.Drawing.Size(799, 108);
            this.groupBox_check.TabIndex = 7;
            this.groupBox_check.TabStop = false;
            this.groupBox_check.Text = "Проверка подписи:";
            // 
            // label_check_file
            // 
            this.label_check_file.AutoSize = true;
            this.label_check_file.Location = new System.Drawing.Point(12, 55);
            this.label_check_file.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_check_file.Name = "label_check_file";
            this.label_check_file.Size = new System.Drawing.Size(147, 15);
            this.label_check_file.TabIndex = 18;
            this.label_check_file.Text = "Подписываемые данные:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 25);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "Файл, содержащий подпись:";
            // 
            // button_check
            // 
            this.button_check.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_check.Location = new System.Drawing.Point(589, 77);
            this.button_check.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_check.Name = "button_check";
            this.button_check.Size = new System.Drawing.Size(88, 27);
            this.button_check.TabIndex = 16;
            this.button_check.Text = "Проверить";
            this.button_check.UseVisualStyleBackColor = true;
            this.button_check.Click += new System.EventHandler(this.button_check_Click);
            // 
            // checkBox_check_detached
            // 
            this.checkBox_check_detached.AutoSize = true;
            this.checkBox_check_detached.Checked = true;
            this.checkBox_check_detached.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_check_detached.Location = new System.Drawing.Point(203, 82);
            this.checkBox_check_detached.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox_check_detached.Name = "checkBox_check_detached";
            this.checkBox_check_detached.Size = new System.Drawing.Size(327, 19);
            this.checkBox_check_detached.TabIndex = 15;
            this.checkBox_check_detached.Text = "Отсоединенная подпись (подпись в отдельном файле)";
            this.checkBox_check_detached.UseVisualStyleBackColor = true;
            this.checkBox_check_detached.CheckedChanged += new System.EventHandler(this.checkBox_check_detached_CheckedChanged);
            // 
            // button_browse_to_check_file
            // 
            this.button_browse_to_check_file.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_browse_to_check_file.Location = new System.Drawing.Point(684, 50);
            this.button_browse_to_check_file.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_browse_to_check_file.Name = "button_browse_to_check_file";
            this.button_browse_to_check_file.Size = new System.Drawing.Size(108, 27);
            this.button_browse_to_check_file.TabIndex = 6;
            this.button_browse_to_check_file.Text = "Обзор";
            this.button_browse_to_check_file.UseVisualStyleBackColor = true;
            this.button_browse_to_check_file.Click += new System.EventHandler(this.button_browse_to_check_file_Click);
            // 
            // button_browse_to_check_sign
            // 
            this.button_browse_to_check_sign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_browse_to_check_sign.Location = new System.Drawing.Point(684, 20);
            this.button_browse_to_check_sign.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_browse_to_check_sign.Name = "button_browse_to_check_sign";
            this.button_browse_to_check_sign.Size = new System.Drawing.Size(108, 27);
            this.button_browse_to_check_sign.TabIndex = 5;
            this.button_browse_to_check_sign.Text = "Обзор";
            this.button_browse_to_check_sign.UseVisualStyleBackColor = true;
            this.button_browse_to_check_sign.Click += new System.EventHandler(this.button_browse_to_check_sign_Click);
            // 
            // textBox_check_file
            // 
            this.textBox_check_file.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_check_file.Location = new System.Drawing.Point(203, 52);
            this.textBox_check_file.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_check_file.Name = "textBox_check_file";
            this.textBox_check_file.ReadOnly = true;
            this.textBox_check_file.Size = new System.Drawing.Size(473, 23);
            this.textBox_check_file.TabIndex = 4;
            // 
            // textBox_check_sign
            // 
            this.textBox_check_sign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_check_sign.Location = new System.Drawing.Point(203, 22);
            this.textBox_check_sign.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_check_sign.Name = "textBox_check_sign";
            this.textBox_check_sign.ReadOnly = true;
            this.textBox_check_sign.Size = new System.Drawing.Size(473, 23);
            this.textBox_check_sign.TabIndex = 3;
            // 
            // textBox_check_result
            // 
            this.textBox_check_result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_check_result.Location = new System.Drawing.Point(8, 22);
            this.textBox_check_result.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_check_result.Multiline = true;
            this.textBox_check_result.Name = "textBox_check_result";
            this.textBox_check_result.ReadOnly = true;
            this.textBox_check_result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_check_result.Size = new System.Drawing.Size(783, 168);
            this.textBox_check_result.TabIndex = 19;
            this.textBox_check_result.WordWrap = false;
            // 
            // groupBox_result
            // 
            this.groupBox_result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_result.Controls.Add(this.textBox_check_result);
            this.groupBox_result.Location = new System.Drawing.Point(14, 477);
            this.groupBox_result.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_result.Name = "groupBox_result";
            this.groupBox_result.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_result.Size = new System.Drawing.Size(799, 197);
            this.groupBox_result.TabIndex = 8;
            this.groupBox_result.TabStop = false;
            this.groupBox_result.Text = "Результат:";
            // 
            // groupBox_certificates
            // 
            this.groupBox_certificates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_certificates.Controls.Add(this.button_certificate_from_file);
            this.groupBox_certificates.Controls.Add(this.button_certificate_from_store);
            this.groupBox_certificates.Controls.Add(this.button_cert_show);
            this.groupBox_certificates.Controls.Add(this.comboBox_certificate_list);
            this.groupBox_certificates.Controls.Add(this.button_certificate_check);
            this.groupBox_certificates.Controls.Add(this.label2);
            this.groupBox_certificates.Controls.Add(this.textBox_cert_subject);
            this.groupBox_certificates.Controls.Add(this.label5);
            this.groupBox_certificates.Controls.Add(this.textBox_cert_serial_number);
            this.groupBox_certificates.Controls.Add(this.label3);
            this.groupBox_certificates.Location = new System.Drawing.Point(14, 14);
            this.groupBox_certificates.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_certificates.Name = "groupBox_certificates";
            this.groupBox_certificates.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_certificates.Size = new System.Drawing.Size(799, 148);
            this.groupBox_certificates.TabIndex = 9;
            this.groupBox_certificates.TabStop = false;
            this.groupBox_certificates.Text = "Сертификаты:";
            // 
            // button_certificate_from_file
            // 
            this.button_certificate_from_file.Location = new System.Drawing.Point(444, 22);
            this.button_certificate_from_file.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_certificate_from_file.Name = "button_certificate_from_file";
            this.button_certificate_from_file.Size = new System.Drawing.Size(232, 27);
            this.button_certificate_from_file.TabIndex = 18;
            this.button_certificate_from_file.Text = "Загрузить из файла";
            this.button_certificate_from_file.UseVisualStyleBackColor = true;
            this.button_certificate_from_file.Click += new System.EventHandler(this.button_certificate_from_file_Click);
            // 
            // button_certificate_from_store
            // 
            this.button_certificate_from_store.Location = new System.Drawing.Point(203, 22);
            this.button_certificate_from_store.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_certificate_from_store.Name = "button_certificate_from_store";
            this.button_certificate_from_store.Size = new System.Drawing.Size(232, 27);
            this.button_certificate_from_store.TabIndex = 17;
            this.button_certificate_from_store.Text = "Загрузить из хранилища";
            this.button_certificate_from_store.UseVisualStyleBackColor = true;
            this.button_certificate_from_store.Click += new System.EventHandler(this.button_certificate_from_store_Click);
            // 
            // openFileDialog_certificate
            // 
            this.openFileDialog_certificate.Filter = "CER|*.cer|P7B|*.p7b|PFX|*.pfx|All Files|*.*";
            // 
            // groupBox_Properties
            // 
            this.groupBox_Properties.Controls.Add(this.button_read_property);
            this.groupBox_Properties.Controls.Add(this.label4);
            this.groupBox_Properties.Controls.Add(this.textBox_property_name);
            this.groupBox_Properties.Location = new System.Drawing.Point(14, 411);
            this.groupBox_Properties.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_Properties.Name = "groupBox_Properties";
            this.groupBox_Properties.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_Properties.Size = new System.Drawing.Size(799, 59);
            this.groupBox_Properties.TabIndex = 10;
            this.groupBox_Properties.TabStop = false;
            this.groupBox_Properties.Text = "Параметры Сертификата";
            // 
            // button_read_property
            // 
            this.button_read_property.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_read_property.Location = new System.Drawing.Point(684, 20);
            this.button_read_property.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_read_property.Name = "button_read_property";
            this.button_read_property.Size = new System.Drawing.Size(108, 27);
            this.button_read_property.TabIndex = 21;
            this.button_read_property.Text = "Считать";
            this.button_read_property.UseVisualStyleBackColor = true;
            this.button_read_property.Click += new System.EventHandler(this.button_read_property_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "Имя Параметра Сертификата:";
            // 
            // textBox_property_name
            // 
            this.textBox_property_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_property_name.Location = new System.Drawing.Point(203, 22);
            this.textBox_property_name.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_property_name.Name = "textBox_property_name";
            this.textBox_property_name.Size = new System.Drawing.Size(473, 23);
            this.textBox_property_name.TabIndex = 19;
            // 
            // SignerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 688);
            this.Controls.Add(this.groupBox_Properties);
            this.Controls.Add(this.groupBox_certificates);
            this.Controls.Add(this.groupBox_result);
            this.Controls.Add(this.groupBox_check);
            this.Controls.Add(this.groupBox_sign);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "SignerForm";
            this.Text = "SXSigner";
            this.groupBox_sign.ResumeLayout(false);
            this.groupBox_sign.PerformLayout();
            this.groupBox_check.ResumeLayout(false);
            this.groupBox_check.PerformLayout();
            this.groupBox_result.ResumeLayout(false);
            this.groupBox_result.PerformLayout();
            this.groupBox_certificates.ResumeLayout(false);
            this.groupBox_certificates.PerformLayout();
            this.groupBox_Properties.ResumeLayout(false);
            this.groupBox_Properties.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_certificate_list;
        private System.Windows.Forms.Button button_browse_to_sign;
        private System.Windows.Forms.TextBox textBox_sign_file;
        private System.Windows.Forms.Button button_sign;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox_sign;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_sign;
        private System.Windows.Forms.OpenFileDialog openFileDialog_sign;
        private System.Windows.Forms.OpenFileDialog openFileDialog_file;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_cert_serial_number;
        private System.Windows.Forms.TextBox textBox_cert_subject;
        private System.Windows.Forms.CheckBox checkBox_sign_detached;
        private System.Windows.Forms.GroupBox groupBox_check;
        private System.Windows.Forms.CheckBox checkBox_check_detached;
        private System.Windows.Forms.Button button_browse_to_check_file;
        private System.Windows.Forms.Button button_browse_to_check_sign;
        private System.Windows.Forms.TextBox textBox_check_file;
        private System.Windows.Forms.TextBox textBox_check_sign;
        private System.Windows.Forms.Label label_check_file;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_check;
        private System.Windows.Forms.TextBox textBox_check_result;
        private System.Windows.Forms.Button button_certificate_check;
        private System.Windows.Forms.Button button_cert_show;
        private System.Windows.Forms.GroupBox groupBox_result;
        private System.Windows.Forms.GroupBox groupBox_certificates;
        private System.Windows.Forms.Button button_certificate_from_file;
        private System.Windows.Forms.Button button_certificate_from_store;
        private System.Windows.Forms.OpenFileDialog openFileDialog_certificate;
        private System.Windows.Forms.CheckBox checkBox_sign_hash;
        private System.Windows.Forms.GroupBox groupBox_Properties;
        private System.Windows.Forms.Button button_read_property;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_property_name;
    }
}

