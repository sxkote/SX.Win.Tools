using SX.Win.Library.Models;

namespace SX.Win.Tools.Controls
{
    public partial class ResultsPane : UserControl
    {

        public string Label
        {
            get { return this.groupBoxResults.Text;}
            set { this.groupBoxResults.Text = value; }
        }

        public ResultsPane()
        {
            InitializeComponent();
        }

        public void SetStatus(ProgressStatus status)
        {
            this.progressBar.Minimum = 0;
            this.progressBar.Maximum = status.Total;
            this.progressBar.Value = status.Value;
            this.progressLabel.Text = status.Message;
        }

        public void Log(string text = "")
        {
            this.textBoxResults.AppendText(text + Environment.NewLine);
        }

        public void Clear()
        {
            this.textBoxResults.Text = "";
            this.SetStatus(new ProgressStatus(0, 0, ""));
        }
    }
}
