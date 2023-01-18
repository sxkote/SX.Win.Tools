namespace SX.Win.Library.Models
{
    public class FilesSearchingOptions : ProgressOptions
    {
        /// <summary>
        /// Searching FileNames 
        /// </summary>
        public string[] FileNames { get; set; }

        /// <summary>
        /// Searching Location (Directory)
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Stop searching file, when the first matching file is found
        /// </summary>
        public bool StopOnFirstFoundFile { get; set; } = false;


        /// <summary>
        /// Files Matching Options
        /// </summary>
        public FileMatchingOptions FileMatching { get; set; }

        /// <summary>
        /// Copy not found files to location
        /// </summary>
        public string CopyNotFoundLocation { get; set; } = "";

        /// <summary>
        /// Move found files to location
        /// </summary>
        public string MoveFoundLocation { get; set; } = "";
    }
}
