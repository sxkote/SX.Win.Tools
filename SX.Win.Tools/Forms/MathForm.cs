using SX.Math;
using SX.Shared;

namespace SX.Win.Tools.Forms
{
    public partial class MathForm : Form
    {
        public MathForm()
        {
            InitializeComponent();
        }

        private void MathForm_Load(object sender, EventArgs e)
        {
            this.textBoxExpression.Text = "((2 + 3 * 9 - 5) * 12 / (4 + 2) + 2)/5 + 17";
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                var expression = new LexemExpression(this.textBoxExpression.Text);
                var result = expression.Calculate();
                this.resultsPane.Log($"{(result?.Value ?? "NULL")} \t = {this.textBoxExpression.Text}");
            }
            catch (Exception ex)
            {
                this.resultsPane.Log(Helpers.GetErrorMessage(ex));
            }
        }

    }
}
