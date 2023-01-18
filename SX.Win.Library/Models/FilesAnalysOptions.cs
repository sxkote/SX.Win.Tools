namespace SX.Win.Library.Models
{
    public class FilesAnalysOptions : ProgressOptions
    {
        public const long DEFAULT_LARGE_SIZE = 100 * 1024 * 1024;
        public readonly static string[] DEFAULT_STANDARD_EXTENSIONS = new string[]
        {
            // images
            ".jpg",
            ".jpeg",
            ".heic",
            ".png",
            ".tif",

            // video
            ".mov",
            ".mp4",
            ".mpg",
            ".avi",
            ".vob",
            ".mts",
            ".3gp",
            ".wmv",

            // documents
            ".txt",
            ".doc",
            ".docx",
            ".xls",
            ".xlsx",
            ".rtf",
            ".pdf",

            // other
            ".zip",
            ".lnk"
        };

        public string Location { get; set; }

        public long LargeSize { get; set; } = DEFAULT_LARGE_SIZE;

        public string[] StandardExtensions { get; set; } = DEFAULT_STANDARD_EXTENSIONS;

        /// <summary>
        /// Files Matching Options
        /// </summary>
        public FileMatchingOptions FileMatching { get; set; }

        /// <summary>
        /// Duplicate avoid _selected folders 
        /// </summary>
        public string[] DuplicateSelectedFolders { get; set; } = null;
    }
}
