using SX.Win.Tools.Forms;

namespace SX.Win.Tools
{
    public partial class WinToolsForm : Form
    {
        public WinToolsForm()
        {
            InitializeComponent();
        }

        private void menuSQLExecutor_Click(object sender, EventArgs e)
        {
            (new RunSQLForm()).ShowDialog();
        }

        private void menuEmailSender_Click(object sender, EventArgs e)
        {
            (new SendEmailForm()).ShowDialog();
        }

        private void menuDigitalSigner_Click(object sender, EventArgs e)
        {
            (new SignerForm()).ShowDialog();
        }

        private void menuFileSearcher_Click(object sender, EventArgs e)
        {
            (new FilesSearchingForm()).ShowDialog();
        }

        private void menuCalculator_Click(object sender, EventArgs e)
        {
            (new MathForm()).ShowDialog();
        }
    }
}
