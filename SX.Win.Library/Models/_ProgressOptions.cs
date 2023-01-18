namespace SX.Win.Library.Models
{
    public class ProgressOptions
    {
        /// <summary>
        /// Progress of the status
        /// </summary>
        public IProgress<ProgressStatus> ProgressStatus { get; set; }

        /// <summary>
        /// Progress of the Log
        /// </summary>
        public IProgress<string> ProgressLog { get; set; }
    }
}
