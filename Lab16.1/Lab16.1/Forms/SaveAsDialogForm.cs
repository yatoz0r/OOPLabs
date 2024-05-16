
namespace Lab16._1
{
    public partial class SaveAsDialogForm : Form
    {

        public string SelectedSaveType => comboBox1.SelectedItem?.ToString();
        public SaveAsDialogForm()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new string[] { "Text", "Bin", "JSON", "XML" });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
