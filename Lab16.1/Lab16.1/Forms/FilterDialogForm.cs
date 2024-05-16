
namespace Lab16._1
{
    public partial class FilterDialogForm : Form
    {
        public string SelectedType => ComboBox1.SelectedItem?.ToString();
        public string FieldName => ComboBox2.SelectedItem?.ToString();
        public FilterDialogForm()
        {
            InitializeComponent();
            ComboBox1.Items.AddRange(new string[] { "Mammal", "Bird", "Artiodactyl" });
            ComboBox1.SelectedIndex = 0;
            ComboBox2.Items.AddRange(new string[] { "Age", "Weight" });
            ComboBox2.SelectedIndex = 0;
        }
        private void applyButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedType) || string.IsNullOrEmpty(FieldName))
            {
                MessageBox.Show("Пожалуйста, выберите тип и введите имя поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }

}
