namespace SX.Win.Library.Models
{
    public class FileMatchingOptions
    {

        public const int MAX_MD5_FILE_SIZE = 15 * 1024 * 1024;

        public const int DEFAULT_COUNT_OF_BYTES_FOR_HASH = 1024 * 1024;

        /// <summary>
        /// Match file name
        /// </summary>
        public bool MatchFileName { get; set; } = true;

        /// <summary>
        /// Match file size
        /// </summary>
        public bool MatchFileSize { get; set; } = true;

        /// <summary>
        /// Match files with MD5 footprint option
        /// </summary>
        public bool MatchFileMD5 { get; set; } = true;

        /// <summary>
        /// Same file (same file path) won't be matched
        /// </summary>
        public bool ExcludeSameFilePath { get; set; } = true;

        /// <summary>
        /// Max size of file to MD5
        /// </summary>
        public long MaxMD5FileSize { get; set; } = MAX_MD5_FILE_SIZE;


        /// <summary>
        /// Count of bytes (of the file) to calcular hash (md5)
        /// </summary>
        public int CountOfBytesToCalculateHash { get; set; } = DEFAULT_COUNT_OF_BYTES_FOR_HASH;
    }
}
