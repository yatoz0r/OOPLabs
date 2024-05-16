using Lab10ClassLib;

namespace Lab16._1
{
    public partial class SortListBoxForm : Form
    {
        public SortListBoxForm()
        {
            InitializeComponent();
        }

        public void ShowSortedList(List<Animal> animals)
        {
            listBox1.Items.Clear();
            foreach (var item in animals)
            {
                listBox1.Items.Add(item.ToString());
            }
        }
    }
}
