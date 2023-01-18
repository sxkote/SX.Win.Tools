using SX.Win.Library.Models;
using SX.Win.Library.Services;

namespace SX.Win.Tools.Forms
{
    public partial class FilesSearchingForm : Form
    {
        private bool _isWorking = false;

        private string[] _searchFiles;

        private Progress<ProgressStatus> _statusChange;
        private Progress<string> _log;

        private CancellationTokenSource _cancelTokenSource;


        private FileSearchingService _searchingService;


        public FilesSearchingForm()
        {
            InitializeComponent();

            _statusChange = new Progress<ProgressStatus>(this.resultsPane.SetStatus);
            _log = new Progress<string>(this.resultsPane.Log);

            _searchingService = new FileSearchingService(new FileService());
        }

        private void toolStripMenuAlbumGenerator_Click(object sender, EventArgs e)
        {
            //var form = new AlbumGenerator();
            //form.Show();
        }

        private void buttonBrowseFile_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _searchFiles = this.openFileDialog1.FileNames;
                this.textBoxNameFile.Text = _searchFiles == null || _searchFiles.Length <= 0 ? "" : String.Join(Environment.NewLine, _searchFiles);
            }
        }

        private void checkBoxCopyNotFoundFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxCopyNotFoundFiles.Checked)
            {
                if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.textBoxCopyNotFoundLocation.Visible = true;
                    this.textBoxCopyNotFoundLocation.Text = this.folderBrowserDialog1.SelectedPath;
                }
                else
                {
                    this.checkBoxCopyNotFoundFiles.Checked = false;
                }
            }
            else
            {
                this.textBoxCopyNotFoundLocation.Visible = false;
                this.textBoxCopyNotFoundLocation.Text = "";
            }
        }

        private void checkBoxMoveFoundFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxMoveFoundFiles.Checked)
            {
                if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.textBoxMoveFoundFilesLocation.Visible = true;
                    this.textBoxMoveFoundFilesLocation.Text = this.folderBrowserDialog1.SelectedPath;
                }
                else
                {
                    this.checkBoxMoveFoundFiles.Checked = false;
                }
            }
            else
            {
                this.textBoxMoveFoundFilesLocation.Visible = false;
                this.textBoxMoveFoundFilesLocation.Text = "";
            }
        }

        private void StartWorking()
        {
            _isWorking = true;
            this.buttonStartSearchFiles.Text = "Cancel";
            this.buttonStartAnalys.Text = "Cancel";
            _cancelTokenSource = new CancellationTokenSource();

        }

        private void StopWorking()
        {
            _isWorking = false;
            this.buttonStartSearchFiles.Text = "Search!";
            this.buttonStartAnalys.Text = "Analys!";

            this.checkBoxMoveFoundFiles.Checked = false;
            this.checkBoxCopyNotFoundFiles.Checked = false;
        }


        private async void buttonStartSearchFiles_Click(object sender, EventArgs e)
        {
            if (!_isWorking)
            {
                this.resultsPane.Clear();

                _cancelTokenSource = new CancellationTokenSource();

                this.StartWorking();

                try
                {
                    var result = await _searchingService.SearchAsync(new FilesSearchingOptions()
                    {
                        FileNames = _searchFiles,
                        Location = this.locationSelector.LocationPath,
                        FileMatching = new FileMatchingOptions()
                        {
                            MaxMD5FileSize = FileMatchingOptions.MAX_MD5_FILE_SIZE,
                            MatchFileName = this.checkBoxMatchName.Checked,
                            MatchFileSize = this.checkBoxMatchSize.Checked,
                            MatchFileMD5 = this.checkBoxMatchMD5.Checked,
                            ExcludeSameFilePath = this.checkBoxExcludeSameFile.Checked,
                            CountOfBytesToCalculateHash = this.checkBoxSearchFastMD5.Checked ? FileMatchingOptions.DEFAULT_COUNT_OF_BYTES_FOR_HASH : FileMatchingOptions.MAX_MD5_FILE_SIZE
                        },
                        StopOnFirstFoundFile = this.checkBoxStopOnFirstFound.Checked,
                        CopyNotFoundLocation = this.checkBoxCopyNotFoundFiles.Checked ? this.textBoxCopyNotFoundLocation.Text : "",
                        MoveFoundLocation = this.checkBoxMoveFoundFiles.Checked ? this.textBoxMoveFoundFilesLocation.Text : "",
                        ProgressLog = _log,
                        ProgressStatus = _statusChange
                    }, _cancelTokenSource.Token);

                    this.resultsPane.Log();
                    this.resultsPane.Log("RESULTS:");
                    this.resultsPane.Log();
                    this.resultsPane.Log($"Found: {result.Count(f => f.HasLinks)}/{result.Count}");

                    var notFound = result.Where(f => !f.HasLinks).ToList();
                    if (notFound != null && notFound.Any())
                    {
                        this.resultsPane.Log($"NOT Found: {notFound.Count}/{result.Count} :");
                        foreach (var nf in notFound)
                            this.resultsPane.Log($"  {nf.FullName}");
                    }
                }
                catch (OperationCanceledException ex)
                {
                    this.resultsPane.SetStatus(new ProgressStatus(0, 0, "canceled"));
                }
                finally
                {
                    this.StopWorking();
                }
            }
            else
            {
                _cancelTokenSource.Cancel();
            }
        }

        private async void buttonStartAnalys_Click(object sender, EventArgs e)
        {
            if (!_isWorking)
            {
                this.resultsPane.Clear();

                _cancelTokenSource = new CancellationTokenSource();

                this.StartWorking();

                try
                {
                    var analys = await _searchingService.AnalysAsync(new FilesAnalysOptions()
                    {
                        Location = this.locationSelector.LocationPath,
                        ProgressLog = _log,
                        ProgressStatus = _statusChange,
                        FileMatching = new FileMatchingOptions()
                        {
                            MaxMD5FileSize = FileMatchingOptions.MAX_MD5_FILE_SIZE,
                            MatchFileMD5 = this.checkBoxMatchSizeAndFileName.Checked ? false : true,
                            MatchFileSize = true,
                            MatchFileName = this.checkBoxMatchSizeAndFileName.Checked ? true : false,
                            ExcludeSameFilePath = true,
                            CountOfBytesToCalculateHash = this.checkBoxDuplicatesFastMD5.Checked ? FileMatchingOptions.DEFAULT_COUNT_OF_BYTES_FOR_HASH : FileMatchingOptions.MAX_MD5_FILE_SIZE
                        },
                        DuplicateSelectedFolders = this.checkBoxAvoidSelectedFolder.Checked
                            ? this.textBoxSelectedFolders.Text
                                .Split(new char[] { ';', ',' })
                                .Select(s=>s.Trim().ToLower())
                                .Where(s => !String.IsNullOrEmpty(s))
                                .ToArray()
                            : null,
                        LargeSize = FilesAnalysOptions.DEFAULT_LARGE_SIZE,
                        StandardExtensions = FilesAnalysOptions.DEFAULT_STANDARD_EXTENSIONS
                    }, _cancelTokenSource.Token);

                    this.resultsPane.Log($"");
                    this.resultsPane.Log($"Extensions ALL by count:");
                    analys.ExtensionsAll
                        .OrderByDescending(e => e.Count)
                        .ToList()
                        .ForEach(e => this.resultsPane.Log($"Extension {e.Extension}\t count: {e.Count}\t size: {(e.Size.ToString("#,0"))}"));

                    this.resultsPane.Log($"");
                    this.resultsPane.Log($"Extensions ALL by size:");
                    analys.ExtensionsAll
                        .OrderByDescending(e => e.Size)
                        .ToList()
                        .ForEach(e => this.resultsPane.Log($"Extension {e.Extension}\t count: {e.Count}\t size: {(e.Size.ToString("#,0"))}"));

                    this.resultsPane.Log($"");
                    this.resultsPane.Log($"Extensions UNKNOWN by count:");
                    analys.ExtensionsUnknown
                        .OrderByDescending(e => e.Count)
                        .ToList()
                        .ForEach(e => this.resultsPane.Log($"Extension {e.Extension}\t count: {e.Count}\t size: {(e.Size.ToString("#,0"))}"));

                    this.resultsPane.Log($"");
                    this.resultsPane.Log($"Extensions UNKNOWN by size:");
                    analys.ExtensionsUnknown
                        .OrderByDescending(e => e.Size)
                        .ToList()
                        .ForEach(e => this.resultsPane.Log($"Extension {e.Extension}\t count: {e.Count}\t size: {(e.Size.ToString("#,0"))}"));

                    // print all UNKNOWN extensions
                    foreach (var item in analys.ExtensionsUnknown.OrderBy(i => i.Extension))
                    {
                        this.resultsPane.Log($"");
                        this.resultsPane.Log($"Extension '{item.Extension}':");
                        foreach (var file in item.Files)
                            this.resultsPane.Log($"{file.FullName} [{file.Size}]");
                    }

                    this.resultsPane.Log();
                    this.resultsPane.Log($"Done");
                }
                catch (OperationCanceledException ex)
                {
                    this.resultsPane.SetStatus(new ProgressStatus(0, 0, "canceled"));
                }
                finally
                {
                    this.StopWorking();
                }
            }
            else
            {
                _cancelTokenSource.Cancel();
            }
        }

        private void buttonBrowseFolder_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                _searchFiles = this.GetAllFilesFromFolder(this.folderBrowserDialog2.SelectedPath).ToArray();
                this.textBoxNameFile.Text = _searchFiles == null || _searchFiles.Length <= 0 ? "" : String.Join(Environment.NewLine, _searchFiles);
            }
        }

        private IEnumerable<string> GetAllFilesFromFolder(string path)
        {
            List<string> files = Directory.GetFiles(path)?.ToList() ?? new List<string>();

            var directories = Directory.GetDirectories(path);
            foreach (var dir in directories)
            {
                var subFiles = this.GetAllFilesFromFolder(dir);
                if (subFiles != null && subFiles.Any())
                    files.AddRange(subFiles);
            }

            return files;
        }
    }
}
