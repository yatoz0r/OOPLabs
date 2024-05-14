using Lab12Hash;

namespace Lab16._1
{
    public partial class FilterListBoxForm : Form
    {
        public FilterListBoxForm()
        {
            InitializeComponent();
        }

        public void UpdateFilteredCollection(List<Element<AnimalKey, int>> filteredCollection)
        {
            listBox1.Items.Clear();
            foreach (var item in filteredCollection)
            {
                listBox1.Items.Add(item.ToString());
            }
        }
    }
}
