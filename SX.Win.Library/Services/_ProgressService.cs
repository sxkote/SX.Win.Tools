using SX.Win.Library.Contracts;
using SX.Win.Library.Models;

namespace SX.Win.Library.Services
{
    public class ProgressService : IProgressService
    {
        public event ProgressLog Log;
        public event ProgressStatusChanged StatusChanged;

        protected void AddLog(string message, IProgress<string> progress)
        {
            if (progress != null)
                progress.Report(message);

            this.Log?.Invoke(message);
        }

        protected void ChangeStatus(ProgressStatus status, IProgress<ProgressStatus> progress = null)
        {
            if (progress != null)
                progress.Report(status);

            this.StatusChanged?.Invoke(status);
        }
        protected void ChangeStatus(int value, int total, string message, IProgress<ProgressStatus> progress = null)
        {
            this.ChangeStatus(new ProgressStatus(value, total, message), progress);
        }

    }
}
