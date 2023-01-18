namespace SX.Win.Library.Models
{
    public class FilesAnalysResults
    {
        /// <summary>
        /// список больших файлов
        /// </summary>
        public List<FileModel> LargeFiles { get; set; } = new List<FileModel>();

        public List<FilesAnalysResultExtensionInfo> ExtensionsAll { get; set; } = new List<FilesAnalysResultExtensionInfo>();

        public List<FilesAnalysResultExtensionInfo> ExtensionsUnknown { get; set; } = new List<FilesAnalysResultExtensionInfo>();

        public List<FileModel> Duplicates { get; set; } = new List<FileModel>();
    }

    public class FilesAnalysResultExtensionInfo
    {
        public string Extension { get; set; }

        public List<FileModel> Files { get; set; }

        public int Count => this.Files.Count;

        public long Size => this.Files.Select(f => f.Size).DefaultIfEmpty(0).Sum();

        public FilesAnalysResultExtensionInfo() { }

        public FilesAnalysResultExtensionInfo(string extension, IEnumerable<FileModel> files)
        {
            this.Extension = extension.ToLower();
            this.Files = files == null ? new List<FileModel>() : files.ToList();
        }
    }
}
