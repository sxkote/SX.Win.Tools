namespace SX.Win.Tools.Controls
{
    public partial class LocationSelector : UserControl
    {
        protected string _location = "C:\\";

        public string Label
        {
            get { return this.groupBoxSource.Text; }
            set { this.groupBoxSource.Text = value; }
        }

        public string LocationPath
        {
            get { return _location; }
            set
            {
                _location = value;
                this.textBoxLocationPath.Text = _location;
            }
        }

        public LocationSelector()
        {
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                this.LocationPath = this.folderBrowserDialog1.SelectedPath;
        }
    }
}
