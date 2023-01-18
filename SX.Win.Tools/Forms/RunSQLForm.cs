using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SX.Win.Tools.Forms
{
    public partial class RunSQLForm : Form
    {
        private DataTable _table;

        public RunSQLForm()
        {
            InitializeComponent();
        }

        private void RunSQLForm_Load(object sender, EventArgs e)
        {
            //base.OnLoad(e);
            this.textBoxConnectionString.Text = Program.Configuration.GetSection("SQLConnectionString").Value;
            this.textBoxSQLQuery.Text = "";
        }

        protected DataTable GetDataTable(string sqlConnectionString, string sqlQuery)
        {
            try
            {
                var dataTable = new DataTable();

                using (var connection = new SqlConnection(sqlConnectionString))
                {
                    using (var command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandTimeout = 100000;
                        connection.Open();

                        var da = new SqlDataAdapter(command);
                        da.Fill(dataTable);
                    }
                    connection.Close();
                }

                return dataTable;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.toolStripStatusLabel.Text = "ERROR!";
                return null;
            }
        }

        protected void RunSql()
        {
            _table = this.GetDataTable(this.textBoxConnectionString.Text, this.textBoxSQLQuery.Text);

            this.bindingSource.DataSource = _table;
            this.dataGridView.AutoGenerateColumns = true;
            this.dataGridView.DataSource = this.bindingSource;

            this.dataGridView.Refresh();

            if (_table != null)
            {
                this.toolStripStatusLabel.Text = $"{_table.Rows.Count} rows";
            }           
        }

        private void buttonRunSQL_Click(object sender, EventArgs e)
        {
            this.dataGridView.DataSource = null;
            this.dataGridView.Columns.Clear();

            this.RunSql();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (_table == null)
                return;

            if (this.saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            //File.WriteAllBytes(this.saveFileDialog.FileName, new LV.Common.Infrastructure.Services.Excel.ExcelBuilder().ExportDataTable(_table));
        }
    }
}
