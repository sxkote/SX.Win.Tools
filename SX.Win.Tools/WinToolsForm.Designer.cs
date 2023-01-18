
namespace SX.Win.Tools
{
    partial class WinToolsForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSQLExecutor = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEmailSender = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDigitalSigner = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSearcher = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCalculator = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(288, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSQLExecutor,
            this.menuEmailSender,
            this.menuDigitalSigner,
            this.menuFileSearcher,
            this.menuCalculator});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // menuSQLExecutor
            // 
            this.menuSQLExecutor.Name = "menuSQLExecutor";
            this.menuSQLExecutor.Size = new System.Drawing.Size(180, 22);
            this.menuSQLExecutor.Text = "SQL Executor";
            this.menuSQLExecutor.Click += new System.EventHandler(this.menuSQLExecutor_Click);
            // 
            // menuEmailSender
            // 
            this.menuEmailSender.Name = "menuEmailSender";
            this.menuEmailSender.Size = new System.Drawing.Size(180, 22);
            this.menuEmailSender.Text = "Email Sender";
            this.menuEmailSender.Click += new System.EventHandler(this.menuEmailSender_Click);
            // 
            // menuDigitalSigner
            // 
            this.menuDigitalSigner.Name = "menuDigitalSigner";
            this.menuDigitalSigner.Size = new System.Drawing.Size(180, 22);
            this.menuDigitalSigner.Text = "Digital Signer";
            this.menuDigitalSigner.Click += new System.EventHandler(this.menuDigitalSigner_Click);
            // 
            // menuFileSearcher
            // 
            this.menuFileSearcher.Name = "menuFileSearcher";
            this.menuFileSearcher.Size = new System.Drawing.Size(180, 22);
            this.menuFileSearcher.Text = "File Searcher";
            this.menuFileSearcher.Click += new System.EventHandler(this.menuFileSearcher_Click);
            // 
            // menuCalculator
            // 
            this.menuCalculator.Name = "menuCalculator";
            this.menuCalculator.Size = new System.Drawing.Size(180, 22);
            this.menuCalculator.Text = "Calculator";
            this.menuCalculator.Click += new System.EventHandler(this.menuCalculator_Click);
            // 
            // WinToolsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 206);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "WinToolsForm";
            this.Text = "Win Tools";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuSQLExecutor;
        private System.Windows.Forms.ToolStripMenuItem menuEmailSender;
        private System.Windows.Forms.ToolStripMenuItem menuDigitalSigner;
        private ToolStripMenuItem menuFileSearcher;
        private ToolStripMenuItem menuCalculator;
    }
}