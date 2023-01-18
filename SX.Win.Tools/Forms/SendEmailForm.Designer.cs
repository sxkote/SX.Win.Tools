
namespace SX.Win.Tools.Forms
{
    partial class SendEmailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelConnectionString = new System.Windows.Forms.Label();
            this.textBoxConnectionString = new System.Windows.Forms.TextBox();
            this.labelRecipient = new System.Windows.Forms.Label();
            this.textBoxRecipient = new System.Windows.Forms.TextBox();
            this.groupBoxEmail = new System.Windows.Forms.GroupBox();
            this.buttonAttachmentsClear = new System.Windows.Forms.Button();
            this.buttonAttachmentsBrowse = new System.Windows.Forms.Button();
            this.textBoxAttachments = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxBody = new System.Windows.Forms.TextBox();
            this.labelBody = new System.Windows.Forms.Label();
            this.textBoxSubject = new System.Windows.Forms.TextBox();
            this.labelSubject = new System.Windows.Forms.Label();
            this.buttonSendEmail = new System.Windows.Forms.Button();
            this.buttonConnectionStringModify = new System.Windows.Forms.Button();
            this.groupBoxSmpt = new System.Windows.Forms.GroupBox();
            this.openFileDialogAttachments = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxEmail.SuspendLayout();
            this.groupBoxSmpt.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelConnectionString
            // 
            this.labelConnectionString.AutoSize = true;
            this.labelConnectionString.Location = new System.Drawing.Point(7, 31);
            this.labelConnectionString.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelConnectionString.Name = "labelConnectionString";
            this.labelConnectionString.Size = new System.Drawing.Size(106, 15);
            this.labelConnectionString.TabIndex = 0;
            this.labelConnectionString.Text = "Connection String:";
            // 
            // textBoxConnectionString
            // 
            this.textBoxConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxConnectionString.Location = new System.Drawing.Point(10, 54);
            this.textBoxConnectionString.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxConnectionString.Multiline = true;
            this.textBoxConnectionString.Name = "textBoxConnectionString";
            this.textBoxConnectionString.ReadOnly = true;
            this.textBoxConnectionString.Size = new System.Drawing.Size(454, 172);
            this.textBoxConnectionString.TabIndex = 1;
            // 
            // labelRecipient
            // 
            this.labelRecipient.AutoSize = true;
            this.labelRecipient.Location = new System.Drawing.Point(7, 29);
            this.labelRecipient.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRecipient.Name = "labelRecipient";
            this.labelRecipient.Size = new System.Drawing.Size(59, 15);
            this.labelRecipient.TabIndex = 3;
            this.labelRecipient.Text = "Recipient:";
            // 
            // textBoxRecipient
            // 
            this.textBoxRecipient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRecipient.Location = new System.Drawing.Point(92, 25);
            this.textBoxRecipient.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxRecipient.Name = "textBoxRecipient";
            this.textBoxRecipient.Size = new System.Drawing.Size(373, 23);
            this.textBoxRecipient.TabIndex = 4;
            // 
            // groupBoxEmail
            // 
            this.groupBoxEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxEmail.Controls.Add(this.buttonAttachmentsClear);
            this.groupBoxEmail.Controls.Add(this.buttonAttachmentsBrowse);
            this.groupBoxEmail.Controls.Add(this.textBoxAttachments);
            this.groupBoxEmail.Controls.Add(this.label1);
            this.groupBoxEmail.Controls.Add(this.textBoxBody);
            this.groupBoxEmail.Controls.Add(this.labelBody);
            this.groupBoxEmail.Controls.Add(this.textBoxSubject);
            this.groupBoxEmail.Controls.Add(this.labelSubject);
            this.groupBoxEmail.Controls.Add(this.textBoxRecipient);
            this.groupBoxEmail.Controls.Add(this.labelRecipient);
            this.groupBoxEmail.Location = new System.Drawing.Point(14, 284);
            this.groupBoxEmail.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxEmail.Name = "groupBoxEmail";
            this.groupBoxEmail.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxEmail.Size = new System.Drawing.Size(472, 320);
            this.groupBoxEmail.TabIndex = 5;
            this.groupBoxEmail.TabStop = false;
            this.groupBoxEmail.Text = "Email Data";
            // 
            // buttonAttachmentsClear
            // 
            this.buttonAttachmentsClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAttachmentsClear.Location = new System.Drawing.Point(284, 284);
            this.buttonAttachmentsClear.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonAttachmentsClear.Name = "buttonAttachmentsClear";
            this.buttonAttachmentsClear.Size = new System.Drawing.Size(88, 27);
            this.buttonAttachmentsClear.TabIndex = 11;
            this.buttonAttachmentsClear.Text = "Clear";
            this.buttonAttachmentsClear.UseVisualStyleBackColor = true;
            this.buttonAttachmentsClear.Click += new System.EventHandler(this.buttonAttachmentsClear_Click);
            // 
            // buttonAttachmentsBrowse
            // 
            this.buttonAttachmentsBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAttachmentsBrowse.Location = new System.Drawing.Point(378, 284);
            this.buttonAttachmentsBrowse.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonAttachmentsBrowse.Name = "buttonAttachmentsBrowse";
            this.buttonAttachmentsBrowse.Size = new System.Drawing.Size(88, 27);
            this.buttonAttachmentsBrowse.TabIndex = 6;
            this.buttonAttachmentsBrowse.Text = "Browse...";
            this.buttonAttachmentsBrowse.UseVisualStyleBackColor = true;
            this.buttonAttachmentsBrowse.Click += new System.EventHandler(this.buttonAttachmentsBrowse_Click);
            // 
            // textBoxAttachments
            // 
            this.textBoxAttachments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAttachments.Location = new System.Drawing.Point(92, 203);
            this.textBoxAttachments.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxAttachments.Multiline = true;
            this.textBoxAttachments.Name = "textBoxAttachments";
            this.textBoxAttachments.ReadOnly = true;
            this.textBoxAttachments.Size = new System.Drawing.Size(373, 73);
            this.textBoxAttachments.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 207);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Attachments:";
            // 
            // textBoxBody
            // 
            this.textBoxBody.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBody.Location = new System.Drawing.Point(92, 85);
            this.textBoxBody.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxBody.Multiline = true;
            this.textBoxBody.Name = "textBoxBody";
            this.textBoxBody.Size = new System.Drawing.Size(373, 110);
            this.textBoxBody.TabIndex = 8;
            // 
            // labelBody
            // 
            this.labelBody.AutoSize = true;
            this.labelBody.Location = new System.Drawing.Point(7, 89);
            this.labelBody.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBody.Name = "labelBody";
            this.labelBody.Size = new System.Drawing.Size(37, 15);
            this.labelBody.TabIndex = 7;
            this.labelBody.Text = "Body:";
            // 
            // textBoxSubject
            // 
            this.textBoxSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSubject.Location = new System.Drawing.Point(92, 55);
            this.textBoxSubject.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxSubject.Name = "textBoxSubject";
            this.textBoxSubject.Size = new System.Drawing.Size(373, 23);
            this.textBoxSubject.TabIndex = 6;
            // 
            // labelSubject
            // 
            this.labelSubject.AutoSize = true;
            this.labelSubject.Location = new System.Drawing.Point(7, 59);
            this.labelSubject.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(49, 15);
            this.labelSubject.TabIndex = 5;
            this.labelSubject.Text = "Subject:";
            // 
            // buttonSendEmail
            // 
            this.buttonSendEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSendEmail.Location = new System.Drawing.Point(170, 618);
            this.buttonSendEmail.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonSendEmail.Name = "buttonSendEmail";
            this.buttonSendEmail.Size = new System.Drawing.Size(164, 57);
            this.buttonSendEmail.TabIndex = 6;
            this.buttonSendEmail.Text = "SEND EMAIL";
            this.buttonSendEmail.UseVisualStyleBackColor = true;
            this.buttonSendEmail.Click += new System.EventHandler(this.buttonSendEmail_Click);
            // 
            // buttonConnectionStringModify
            // 
            this.buttonConnectionStringModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConnectionStringModify.Location = new System.Drawing.Point(378, 230);
            this.buttonConnectionStringModify.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonConnectionStringModify.Name = "buttonConnectionStringModify";
            this.buttonConnectionStringModify.Size = new System.Drawing.Size(88, 27);
            this.buttonConnectionStringModify.TabIndex = 7;
            this.buttonConnectionStringModify.Text = "Modify...";
            this.buttonConnectionStringModify.UseVisualStyleBackColor = true;
            this.buttonConnectionStringModify.Click += new System.EventHandler(this.buttonConnectionStringModify_Click);
            // 
            // groupBoxSmpt
            // 
            this.groupBoxSmpt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSmpt.Controls.Add(this.labelConnectionString);
            this.groupBoxSmpt.Controls.Add(this.buttonConnectionStringModify);
            this.groupBoxSmpt.Controls.Add(this.textBoxConnectionString);
            this.groupBoxSmpt.Location = new System.Drawing.Point(14, 14);
            this.groupBoxSmpt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxSmpt.Name = "groupBoxSmpt";
            this.groupBoxSmpt.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxSmpt.Size = new System.Drawing.Size(472, 263);
            this.groupBoxSmpt.TabIndex = 8;
            this.groupBoxSmpt.TabStop = false;
            this.groupBoxSmpt.Text = "SMTP Configuration";
            // 
            // SendEmailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 689);
            this.Controls.Add(this.groupBoxSmpt);
            this.Controls.Add(this.buttonSendEmail);
            this.Controls.Add(this.groupBoxEmail);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "SendEmailForm";
            this.Text = "Test SMTP Email Send";
            this.Load += new System.EventHandler(this.SendEmailForm_Load);
            this.groupBoxEmail.ResumeLayout(false);
            this.groupBoxEmail.PerformLayout();
            this.groupBoxSmpt.ResumeLayout(false);
            this.groupBoxSmpt.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelConnectionString;
        private System.Windows.Forms.TextBox textBoxConnectionString;
        private System.Windows.Forms.Label labelRecipient;
        private System.Windows.Forms.TextBox textBoxRecipient;
        private System.Windows.Forms.GroupBox groupBoxEmail;
        private System.Windows.Forms.Button buttonAttachmentsBrowse;
        private System.Windows.Forms.TextBox textBoxAttachments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxBody;
        private System.Windows.Forms.Label labelBody;
        private System.Windows.Forms.TextBox textBoxSubject;
        private System.Windows.Forms.Label labelSubject;
        private System.Windows.Forms.Button buttonSendEmail;
        private System.Windows.Forms.Button buttonConnectionStringModify;
        private System.Windows.Forms.GroupBox groupBoxSmpt;
        private System.Windows.Forms.OpenFileDialog openFileDialogAttachments;
        private System.Windows.Forms.Button buttonAttachmentsClear;
    }
}

