namespace SX.Win.Library.Models
{
    public class FilesSearchingResult
    {
        /// <summary>
        /// Searching Location (Folder)
        /// </summary>
        public DirectoryInfo Location { get; set; }

        /// <summary>
        /// список директорий, в которых происходил поиск
        /// </summary>
        public List<DirectoryInfo> Locations { get; set; } = new List<DirectoryInfo>();

        /// <summary>
        /// список результатов поисков файлов
        /// </summary>
        public List<FileModel> Files { get; set; } = new List<FileModel>();


        /// <summary>
        /// Get all NOT found files
        /// </summary>
        /// <returns>List of NOT found files</returns>
        public List<FileModel> GetNotFoundFiles() => this.Files.Where(f => !f.HasLinks).ToList();

        /// <summary>
        /// Get all found files
        /// </summary>
        /// <returns>List of found files</returns>
        public List<FileModel> GetFoundFiles() => this.Files.Where(f => !f.HasLinks).ToList();
    }
}
