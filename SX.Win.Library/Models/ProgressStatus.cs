namespace SX.Win.Library.Models
{
    public class ProgressStatus
    {
        public int Value { get; set; }
        public int Total { get; set; }
        public string Message { get; set; }

        public ProgressStatus() { }

        public ProgressStatus(int value, int total, string message)
        {
            this.Value = value;
            this.Total = total;
            this.Message = message ?? "";
        }
    }

    public delegate void ProgressStatusChanged(ProgressStatus status);

    public delegate void ProgressLog(string message);


}
