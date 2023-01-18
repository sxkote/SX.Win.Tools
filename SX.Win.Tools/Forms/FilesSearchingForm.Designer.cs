
namespace SX.Win.Tools.Forms
{
    partial class FilesSearchingForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxSearchiFilesOptions = new System.Windows.Forms.GroupBox();
            this.buttonBrowseFolder = new System.Windows.Forms.Button();
            this.checkBoxSearchFastMD5 = new System.Windows.Forms.CheckBox();
            this.textBoxMoveFoundFilesLocation = new System.Windows.Forms.TextBox();
            this.checkBoxMoveFoundFiles = new System.Windows.Forms.CheckBox();
            this.textBoxCopyNotFoundLocation = new System.Windows.Forms.TextBox();
            this.checkBoxCopyNotFoundFiles = new System.Windows.Forms.CheckBox();
            this.checkBoxMatchName = new System.Windows.Forms.CheckBox();
            this.checkBoxMatchSize = new System.Windows.Forms.CheckBox();
            this.checkBoxExcludeSameFile = new System.Windows.Forms.CheckBox();
            this.checkBoxMatchMD5 = new System.Windows.Forms.CheckBox();
            this.checkBoxStopOnFirstFound = new System.Windows.Forms.CheckBox();
            this.buttonStartSearchFiles = new System.Windows.Forms.Button();
            this.buttonBrowseFile = new System.Windows.Forms.Button();
            this.textBoxNameFile = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.resultsPane = new SX.Win.Tools.Controls.ResultsPane();
            this.checkBoxAvoidSelectedFolder = new System.Windows.Forms.CheckBox();
            this.checkBoxDuplicatesFastMD5 = new System.Windows.Forms.CheckBox();
            this.checkBoxMatchSizeAndFileName = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBoxAnalysOptions = new System.Windows.Forms.GroupBox();
            this.textBoxSelectedFolders = new System.Windows.Forms.TextBox();
            this.buttonStartAnalys = new System.Windows.Forms.Button();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_search = new System.Windows.Forms.TabPage();
            this.tabPage_analys = new System.Windows.Forms.TabPage();
            this.locationSelector = new SX.Win.Tools.Controls.LocationSelector();
            this.groupBoxSearchiFilesOptions.SuspendLayout();
            this.groupBoxAnalysOptions.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage_search.SuspendLayout();
            this.tabPage_analys.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSearchiFilesOptions
            // 
            this.groupBoxSearchiFilesOptions.Controls.Add(this.buttonBrowseFolder);
            this.groupBoxSearchiFilesOptions.Controls.Add(this.checkBoxSearchFastMD5);
            this.groupBoxSearchiFilesOptions.Controls.Add(this.textBoxMoveFoundFilesLocation);
            this.groupBoxSearchiFilesOptions.Controls.Add(this.checkBoxMoveFoundFiles);
            this.groupBoxSearchiFilesOptions.Controls.Add(this.textBoxCopyNotFoundLocation);
            this.groupBoxSearchiFilesOptions.Controls.Add(this.checkBoxCopyNotFoundFiles);
            this.groupBoxSearchiFilesOptions.Controls.Add(this.checkBoxMatchName);
            this.groupBoxSearchiFilesOptions.Controls.Add(this.checkBoxMatchSize);
            this.groupBoxSearchiFilesOptions.Controls.Add(this.checkBoxExcludeSameFile);
            this.groupBoxSearchiFilesOptions.Controls.Add(this.checkBoxMatchMD5);
            this.groupBoxSearchiFilesOptions.Controls.Add(this.checkBoxStopOnFirstFound);
            this.groupBoxSearchiFilesOptions.Controls.Add(this.buttonStartSearchFiles);
            this.groupBoxSearchiFilesOptions.Controls.Add(this.buttonBrowseFile);
            this.groupBoxSearchiFilesOptions.Controls.Add(this.textBoxNameFile);
            this.groupBoxSearchiFilesOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSearchiFilesOptions.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSearchiFilesOptions.Name = "groupBoxSearchiFilesOptions";
            this.groupBoxSearchiFilesOptions.Size = new System.Drawing.Size(622, 255);
            this.groupBoxSearchiFilesOptions.TabIndex = 0;
            this.groupBoxSearchiFilesOptions.TabStop = false;
            this.groupBoxSearchiFilesOptions.Text = "Search Files Options";
            // 
            // buttonBrowseFolder
            // 
            this.buttonBrowseFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseFolder.Location = new System.Drawing.Point(541, 51);
            this.buttonBrowseFolder.Name = "buttonBrowseFolder";
            this.buttonBrowseFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseFolder.TabIndex = 13;
            this.buttonBrowseFolder.Text = "folder...";
            this.buttonBrowseFolder.UseVisualStyleBackColor = true;
            this.buttonBrowseFolder.Click += new System.EventHandler(this.buttonBrowseFolder_Click);
            // 
            // checkBoxSearchFastMD5
            // 
            this.checkBoxSearchFastMD5.AutoSize = true;
            this.checkBoxSearchFastMD5.Checked = true;
            this.checkBoxSearchFastMD5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSearchFastMD5.Location = new System.Drawing.Point(324, 114);
            this.checkBoxSearchFastMD5.Name = "checkBoxSearchFastMD5";
            this.checkBoxSearchFastMD5.Size = new System.Drawing.Size(190, 19);
            this.checkBoxSearchFastMD5.TabIndex = 12;
            this.checkBoxSearchFastMD5.Text = "Fast MD5 (small bytes amount)";
            this.checkBoxSearchFastMD5.UseVisualStyleBackColor = true;
            // 
            // textBoxMoveFoundFilesLocation
            // 
            this.textBoxMoveFoundFilesLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMoveFoundFilesLocation.Location = new System.Drawing.Point(165, 190);
            this.textBoxMoveFoundFilesLocation.Name = "textBoxMoveFoundFilesLocation";
            this.textBoxMoveFoundFilesLocation.ReadOnly = true;
            this.textBoxMoveFoundFilesLocation.Size = new System.Drawing.Size(370, 23);
            this.textBoxMoveFoundFilesLocation.TabIndex = 11;
            this.textBoxMoveFoundFilesLocation.Visible = false;
            // 
            // checkBoxMoveFoundFiles
            // 
            this.checkBoxMoveFoundFiles.AutoSize = true;
            this.checkBoxMoveFoundFiles.ForeColor = System.Drawing.Color.Red;
            this.checkBoxMoveFoundFiles.Location = new System.Drawing.Point(6, 192);
            this.checkBoxMoveFoundFiles.Name = "checkBoxMoveFoundFiles";
            this.checkBoxMoveFoundFiles.Size = new System.Drawing.Size(117, 19);
            this.checkBoxMoveFoundFiles.TabIndex = 10;
            this.checkBoxMoveFoundFiles.Text = "Move Found files";
            this.checkBoxMoveFoundFiles.UseVisualStyleBackColor = true;
            this.checkBoxMoveFoundFiles.CheckedChanged += new System.EventHandler(this.checkBoxMoveFoundFiles_CheckedChanged);
            // 
            // textBoxCopyNotFoundLocation
            // 
            this.textBoxCopyNotFoundLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCopyNotFoundLocation.Location = new System.Drawing.Point(165, 161);
            this.textBoxCopyNotFoundLocation.Name = "textBoxCopyNotFoundLocation";
            this.textBoxCopyNotFoundLocation.ReadOnly = true;
            this.textBoxCopyNotFoundLocation.Size = new System.Drawing.Size(370, 23);
            this.textBoxCopyNotFoundLocation.TabIndex = 9;
            this.textBoxCopyNotFoundLocation.Visible = false;
            // 
            // checkBoxCopyNotFoundFiles
            // 
            this.checkBoxCopyNotFoundFiles.AutoSize = true;
            this.checkBoxCopyNotFoundFiles.ForeColor = System.Drawing.Color.Red;
            this.checkBoxCopyNotFoundFiles.Location = new System.Drawing.Point(6, 163);
            this.checkBoxCopyNotFoundFiles.Name = "checkBoxCopyNotFoundFiles";
            this.checkBoxCopyNotFoundFiles.Size = new System.Drawing.Size(139, 19);
            this.checkBoxCopyNotFoundFiles.TabIndex = 8;
            this.checkBoxCopyNotFoundFiles.Text = "Copy NOT found files";
            this.checkBoxCopyNotFoundFiles.UseVisualStyleBackColor = true;
            this.checkBoxCopyNotFoundFiles.CheckedChanged += new System.EventHandler(this.checkBoxCopyNotFoundFiles_CheckedChanged);
            // 
            // checkBoxMatchName
            // 
            this.checkBoxMatchName.AutoSize = true;
            this.checkBoxMatchName.Checked = true;
            this.checkBoxMatchName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMatchName.Location = new System.Drawing.Point(6, 138);
            this.checkBoxMatchName.Name = "checkBoxMatchName";
            this.checkBoxMatchName.Size = new System.Drawing.Size(112, 19);
            this.checkBoxMatchName.TabIndex = 7;
            this.checkBoxMatchName.Text = "Match file name";
            this.checkBoxMatchName.UseVisualStyleBackColor = true;
            // 
            // checkBoxMatchSize
            // 
            this.checkBoxMatchSize.AutoSize = true;
            this.checkBoxMatchSize.Checked = true;
            this.checkBoxMatchSize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMatchSize.Location = new System.Drawing.Point(165, 138);
            this.checkBoxMatchSize.Name = "checkBoxMatchSize";
            this.checkBoxMatchSize.Size = new System.Drawing.Size(101, 19);
            this.checkBoxMatchSize.TabIndex = 6;
            this.checkBoxMatchSize.Text = "Match file size";
            this.checkBoxMatchSize.UseVisualStyleBackColor = true;
            // 
            // checkBoxExcludeSameFile
            // 
            this.checkBoxExcludeSameFile.AutoSize = true;
            this.checkBoxExcludeSameFile.Checked = true;
            this.checkBoxExcludeSameFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxExcludeSameFile.Location = new System.Drawing.Point(165, 114);
            this.checkBoxExcludeSameFile.Name = "checkBoxExcludeSameFile";
            this.checkBoxExcludeSameFile.Size = new System.Drawing.Size(117, 19);
            this.checkBoxExcludeSameFile.TabIndex = 5;
            this.checkBoxExcludeSameFile.Text = "Exclude same file";
            this.checkBoxExcludeSameFile.UseVisualStyleBackColor = true;
            // 
            // checkBoxMatchMD5
            // 
            this.checkBoxMatchMD5.AutoSize = true;
            this.checkBoxMatchMD5.Checked = true;
            this.checkBoxMatchMD5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMatchMD5.Location = new System.Drawing.Point(324, 138);
            this.checkBoxMatchMD5.Name = "checkBoxMatchMD5";
            this.checkBoxMatchMD5.Size = new System.Drawing.Size(157, 19);
            this.checkBoxMatchMD5.TabIndex = 4;
            this.checkBoxMatchMD5.Text = "Match file MD5 footprint";
            this.checkBoxMatchMD5.UseVisualStyleBackColor = true;
            // 
            // checkBoxStopOnFirstFound
            // 
            this.checkBoxStopOnFirstFound.AutoSize = true;
            this.checkBoxStopOnFirstFound.Checked = true;
            this.checkBoxStopOnFirstFound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStopOnFirstFound.Location = new System.Drawing.Point(6, 114);
            this.checkBoxStopOnFirstFound.Name = "checkBoxStopOnFirstFound";
            this.checkBoxStopOnFirstFound.Size = new System.Drawing.Size(144, 19);
            this.checkBoxStopOnFirstFound.TabIndex = 3;
            this.checkBoxStopOnFirstFound.Text = "Stop on first found file";
            this.checkBoxStopOnFirstFound.UseVisualStyleBackColor = true;
            // 
            // buttonStartSearchFiles
            // 
            this.buttonStartSearchFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStartSearchFiles.Location = new System.Drawing.Point(541, 225);
            this.buttonStartSearchFiles.Name = "buttonStartSearchFiles";
            this.buttonStartSearchFiles.Size = new System.Drawing.Size(75, 24);
            this.buttonStartSearchFiles.TabIndex = 2;
            this.buttonStartSearchFiles.Text = "Search !";
            this.buttonStartSearchFiles.UseVisualStyleBackColor = true;
            this.buttonStartSearchFiles.Click += new System.EventHandler(this.buttonStartSearchFiles_Click);
            // 
            // buttonBrowseFile
            // 
            this.buttonBrowseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseFile.Location = new System.Drawing.Point(541, 22);
            this.buttonBrowseFile.Name = "buttonBrowseFile";
            this.buttonBrowseFile.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseFile.TabIndex = 1;
            this.buttonBrowseFile.Text = "browse...";
            this.buttonBrowseFile.UseVisualStyleBackColor = true;
            this.buttonBrowseFile.Click += new System.EventHandler(this.buttonBrowseFile_Click);
            // 
            // textBoxNameFile
            // 
            this.textBoxNameFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNameFile.Location = new System.Drawing.Point(6, 22);
            this.textBoxNameFile.Multiline = true;
            this.textBoxNameFile.Name = "textBoxNameFile";
            this.textBoxNameFile.ReadOnly = true;
            this.textBoxNameFile.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxNameFile.Size = new System.Drawing.Size(529, 86);
            this.textBoxNameFile.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // menuStrip
            // 
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(660, 24);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip1";
            // 
            // resultsPane
            // 
            this.resultsPane.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsPane.Label = "Results";
            this.resultsPane.Location = new System.Drawing.Point(12, 382);
            this.resultsPane.Name = "resultsPane";
            this.resultsPane.Size = new System.Drawing.Size(636, 185);
            this.resultsPane.TabIndex = 5;
            // 
            // checkBoxAvoidSelectedFolder
            // 
            this.checkBoxAvoidSelectedFolder.AutoSize = true;
            this.checkBoxAvoidSelectedFolder.Checked = true;
            this.checkBoxAvoidSelectedFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAvoidSelectedFolder.Location = new System.Drawing.Point(6, 47);
            this.checkBoxAvoidSelectedFolder.Name = "checkBoxAvoidSelectedFolder";
            this.checkBoxAvoidSelectedFolder.Size = new System.Drawing.Size(142, 19);
            this.checkBoxAvoidSelectedFolder.TabIndex = 14;
            this.checkBoxAvoidSelectedFolder.Text = "Avoid _selected folder";
            this.checkBoxAvoidSelectedFolder.UseVisualStyleBackColor = true;
            // 
            // checkBoxDuplicatesFastMD5
            // 
            this.checkBoxDuplicatesFastMD5.AutoSize = true;
            this.checkBoxDuplicatesFastMD5.Checked = true;
            this.checkBoxDuplicatesFastMD5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDuplicatesFastMD5.Location = new System.Drawing.Point(337, 22);
            this.checkBoxDuplicatesFastMD5.Name = "checkBoxDuplicatesFastMD5";
            this.checkBoxDuplicatesFastMD5.Size = new System.Drawing.Size(190, 19);
            this.checkBoxDuplicatesFastMD5.TabIndex = 13;
            this.checkBoxDuplicatesFastMD5.Text = "Fast MD5 (small bytes amount)";
            this.checkBoxDuplicatesFastMD5.UseVisualStyleBackColor = true;
            // 
            // checkBoxMatchSizeAndFileName
            // 
            this.checkBoxMatchSizeAndFileName.AutoSize = true;
            this.checkBoxMatchSizeAndFileName.Checked = true;
            this.checkBoxMatchSizeAndFileName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMatchSizeAndFileName.Location = new System.Drawing.Point(6, 22);
            this.checkBoxMatchSizeAndFileName.Name = "checkBoxMatchSizeAndFileName";
            this.checkBoxMatchSizeAndFileName.Size = new System.Drawing.Size(177, 19);
            this.checkBoxMatchSizeAndFileName.TabIndex = 4;
            this.checkBoxMatchSizeAndFileName.Text = "Match size && file name (fast)";
            this.checkBoxMatchSizeAndFileName.UseVisualStyleBackColor = true;
            // 
            // groupBoxAnalysOptions
            // 
            this.groupBoxAnalysOptions.Controls.Add(this.textBoxSelectedFolders);
            this.groupBoxAnalysOptions.Controls.Add(this.checkBoxAvoidSelectedFolder);
            this.groupBoxAnalysOptions.Controls.Add(this.buttonStartAnalys);
            this.groupBoxAnalysOptions.Controls.Add(this.checkBoxDuplicatesFastMD5);
            this.groupBoxAnalysOptions.Controls.Add(this.checkBoxMatchSizeAndFileName);
            this.groupBoxAnalysOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxAnalysOptions.Location = new System.Drawing.Point(3, 3);
            this.groupBoxAnalysOptions.Name = "groupBoxAnalysOptions";
            this.groupBoxAnalysOptions.Size = new System.Drawing.Size(622, 255);
            this.groupBoxAnalysOptions.TabIndex = 7;
            this.groupBoxAnalysOptions.TabStop = false;
            this.groupBoxAnalysOptions.Text = "Duplicates Analisys";
            // 
            // textBoxSelectedFolders
            // 
            this.textBoxSelectedFolders.Location = new System.Drawing.Point(154, 45);
            this.textBoxSelectedFolders.Name = "textBoxSelectedFolders";
            this.textBoxSelectedFolders.Size = new System.Drawing.Size(170, 23);
            this.textBoxSelectedFolders.TabIndex = 15;
            this.textBoxSelectedFolders.Text = "\\_selected; \\_sel";
            // 
            // buttonStartAnalys
            // 
            this.buttonStartAnalys.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStartAnalys.Location = new System.Drawing.Point(541, 226);
            this.buttonStartAnalys.Name = "buttonStartAnalys";
            this.buttonStartAnalys.Size = new System.Drawing.Size(75, 23);
            this.buttonStartAnalys.TabIndex = 0;
            this.buttonStartAnalys.Text = "Analys!";
            this.buttonStartAnalys.UseVisualStyleBackColor = true;
            this.buttonStartAnalys.Click += new System.EventHandler(this.buttonStartAnalys_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage_search);
            this.tabControl.Controls.Add(this.tabPage_analys);
            this.tabControl.Location = new System.Drawing.Point(12, 91);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(636, 289);
            this.tabControl.TabIndex = 8;
            // 
            // tabPage_search
            // 
            this.tabPage_search.Controls.Add(this.groupBoxSearchiFilesOptions);
            this.tabPage_search.Location = new System.Drawing.Point(4, 24);
            this.tabPage_search.Name = "tabPage_search";
            this.tabPage_search.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_search.Size = new System.Drawing.Size(628, 261);
            this.tabPage_search.TabIndex = 0;
            this.tabPage_search.Text = "Search Files";
            this.tabPage_search.UseVisualStyleBackColor = true;
            // 
            // tabPage_analys
            // 
            this.tabPage_analys.Controls.Add(this.groupBoxAnalysOptions);
            this.tabPage_analys.Location = new System.Drawing.Point(4, 24);
            this.tabPage_analys.Name = "tabPage_analys";
            this.tabPage_analys.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_analys.Size = new System.Drawing.Size(628, 261);
            this.tabPage_analys.TabIndex = 1;
            this.tabPage_analys.Text = "Duplicates Analisys";
            this.tabPage_analys.UseVisualStyleBackColor = true;
            // 
            // locationSelector
            // 
            this.locationSelector.Label = "Search Location";
            this.locationSelector.Location = new System.Drawing.Point(12, 27);
            this.locationSelector.LocationPath = "C:\\";
            this.locationSelector.Name = "locationSelector";
            this.locationSelector.Size = new System.Drawing.Size(636, 58);
            this.locationSelector.TabIndex = 9;
            // 
            // FilesSearchingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 567);
            this.Controls.Add(this.locationSelector);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.resultsPane);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FilesSearchingForm";
            this.Text = "File Searcher";
            this.groupBoxSearchiFilesOptions.ResumeLayout(false);
            this.groupBoxSearchiFilesOptions.PerformLayout();
            this.groupBoxAnalysOptions.ResumeLayout(false);
            this.groupBoxAnalysOptions.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage_search.ResumeLayout(false);
            this.tabPage_analys.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSearchiFilesOptions;
        private System.Windows.Forms.Button buttonStartSearchFiles;
        private System.Windows.Forms.Button buttonBrowseFile;
        private System.Windows.Forms.TextBox textBoxNameFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox checkBoxMatchMD5;
        private System.Windows.Forms.CheckBox checkBoxStopOnFirstFound;
        private System.Windows.Forms.CheckBox checkBoxExcludeSameFile;
        private System.Windows.Forms.CheckBox checkBoxMatchSize;
        private System.Windows.Forms.CheckBox checkBoxMatchName;
        private System.Windows.Forms.MenuStrip menuStrip;
        private Controls.ResultsPane resultsPane;
        private System.Windows.Forms.CheckBox checkBoxMatchSizeAndFileName;
        private System.Windows.Forms.TextBox textBoxCopyNotFoundLocation;
        private System.Windows.Forms.CheckBox checkBoxCopyNotFoundFiles;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox textBoxMoveFoundFilesLocation;
        private System.Windows.Forms.CheckBox checkBoxMoveFoundFiles;
        private System.Windows.Forms.CheckBox checkBoxSearchFastMD5;
        private System.Windows.Forms.CheckBox checkBoxDuplicatesFastMD5;
        private System.Windows.Forms.CheckBox checkBoxAvoidSelectedFolder;
        private System.Windows.Forms.GroupBox groupBoxAnalysOptions;
        private System.Windows.Forms.Button buttonStartAnalys;
        private System.Windows.Forms.TextBox textBoxSelectedFolders;
        private System.Windows.Forms.Button buttonBrowseFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_search;
        private System.Windows.Forms.TabPage tabPage_analys;
        private Controls.LocationSelector locationSelector;
    }
}

