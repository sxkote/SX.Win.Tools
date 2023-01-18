namespace SX.Win.Tools.Forms
{
    partial class MathForm
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
            this.resultsPane = new SX.Win.Tools.Controls.ResultsPane();
            this.textBoxExpression = new System.Windows.Forms.TextBox();
            this.labelExpession = new System.Windows.Forms.Label();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // resultsPane
            // 
            this.resultsPane.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsPane.Label = "Results";
            this.resultsPane.Location = new System.Drawing.Point(12, 247);
            this.resultsPane.Name = "resultsPane";
            this.resultsPane.Size = new System.Drawing.Size(776, 201);
            this.resultsPane.TabIndex = 0;
            // 
            // textBoxExpression
            // 
            this.textBoxExpression.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxExpression.Location = new System.Drawing.Point(12, 26);
            this.textBoxExpression.Multiline = true;
            this.textBoxExpression.Name = "textBoxExpression";
            this.textBoxExpression.Size = new System.Drawing.Size(776, 186);
            this.textBoxExpression.TabIndex = 1;
            // 
            // labelExpession
            // 
            this.labelExpession.AutoSize = true;
            this.labelExpession.Location = new System.Drawing.Point(12, 8);
            this.labelExpession.Name = "labelExpession";
            this.labelExpession.Size = new System.Drawing.Size(66, 15);
            this.labelExpession.TabIndex = 2;
            this.labelExpession.Text = "Expression:";
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCalculate.Location = new System.Drawing.Point(713, 218);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(75, 23);
            this.buttonCalculate.TabIndex = 3;
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // MathForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.labelExpession);
            this.Controls.Add(this.textBoxExpression);
            this.Controls.Add(this.resultsPane);
            this.Name = "MathForm";
            this.Text = "MathForm";
            this.Load += new System.EventHandler(this.MathForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ResultsPane resultsPane;
        private TextBox textBoxExpression;
        private Label labelExpession;
        private Button buttonCalculate;
    }
}