using Lab10ClassLib;
using Lab12Hash;
using Lab14;
using System.Diagnostics.Contracts;

namespace Lab16._1
{
    public partial class MainWindowForm : Form
    {
        HashTable<AnimalKey, Animal> hashTable;
        AnimalKey animalKey;
        Animal animal;
        Algorythems alg = new Algorythems();
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;
        CollectionManager cfl = new CollectionManager();
        public MainWindowForm()
        {
            InitializeComponent();
            hashTable = new HashTable<AnimalKey, Animal>(10000);
            saveFileDialog = new SaveFileDialog();
        }

        private void addElementButton_Click(object sender, EventArgs e)
        {
            if (!alg.CheckEmpty(ValueTextBox1) || !alg.CheckEmpty(ValueTextBox2) || !alg.CheckEmpty(ValueTextBox3) || !alg.CheckEmpty(KeyTextBox1)
                || !alg.CheckEmpty(KeyTextBox2))
                MessageBox.Show("Заполнитие Пустые поля");
            else
            {
                if (!alg.IsTextBoxInt(ValueTextBox2) || !alg.IsTextBoxInt(ValueTextBox3) || !alg.IsTextBoxInt(KeyTextBox2))
                    MessageBox.Show("Текст в одном из текстовых полей(Возраст или Вес) не является целым числом.");
                else
                {
                    animal = new Animal(ValueTextBox1.Text, int.Parse(ValueTextBox2.Text), int.Parse(ValueTextBox3.Text));
                    animalKey = new AnimalKey(KeyTextBox1.Text, int.Parse(KeyTextBox2.Text));

                    hashTable.Add(animalKey, animal);
                    ValueTextBox1.Clear();
                    ValueTextBox2.Clear();
                    ValueTextBox3.Clear();
                    KeyTextBox1.Clear();
                    KeyTextBox2.Clear();
                    alg.UpdateListBox(listBox1, hashTable);
                }
            }
        }

        private void randomFillButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                var random = new Random();
                int item = random.Next(1, 4);
                switch (item)
                {
                    case 1:
                        var mammal = new Mammal();
                        var mammalKey = new AnimalKey(mammal.Name, mammal.Age);
                        hashTable.Add(mammalKey, mammal);
                        break;
                    case 2:
                        var bird = new Bird();
                        var birdKey = new AnimalKey(bird.Name, bird.Age);
                        hashTable.Add(birdKey, bird);
                        break;
                    case 3:
                        var artiodactyl = new Artiodactyl();
                        var artiodactylKey = new AnimalKey(artiodactyl.Name, artiodactyl.Age);
                        hashTable.Add(artiodactylKey, artiodactyl);
                        break;
                }

            }
            alg.UpdateListBox(listBox1, hashTable);
        }

        private void deleteElementButton_Click(object sender, EventArgs e)
        {
            if (!alg.CheckEmpty(KeyTextBox1) || !alg.CheckEmpty(KeyTextBox2))
                MessageBox.Show("Заполнитие Пустые поля Ключа");
            else
            {
                animalKey = new AnimalKey(KeyTextBox1.Text, int.Parse(KeyTextBox2.Text));
                if (!alg.CheckKey(animalKey, KeyTextBox2, hashTable)) { }
                else
                {

                    hashTable.Remove(animalKey);
                    KeyTextBox1.Clear();
                    KeyTextBox2.Clear();
                    alg.UpdateListBox(listBox1, hashTable);
                    MessageBox.Show("Элемент удален");
                }
            }

        }

        private void changeElementButton_Click(object sender, EventArgs e)
        {
            if (!alg.CheckEmpty(KeyTextBox1) || !alg.CheckEmpty(KeyTextBox2))
                MessageBox.Show("Заполнитие Пустые поля Ключа");
            else
            {
                
                animalKey = new AnimalKey(KeyTextBox1.Text, int.Parse(KeyTextBox2.Text));
                    if (!alg.CheckKey(animalKey, KeyTextBox2, hashTable)) { }
                    else
                    {
                        var animalValue = new Animal(ValueTextBox1.Text, int.Parse(ValueTextBox2.Text), int.Parse(ValueTextBox3.Text));
                        var animalKey1 = new AnimalKey(KeyTextBox1.Text, int.Parse(KeyTextBox2.Text));
                        var animalEl = new Element<AnimalKey, Animal>(animalKey1, animalValue);
                        hashTable[animalKey] = animalEl;
                        ValueTextBox1.Clear();
                        ValueTextBox2.Clear();
                        ValueTextBox3.Clear();
                        KeyTextBox1.Clear();
                        KeyTextBox2.Clear();
                        alg.UpdateListBox(listBox1, hashTable);
                    }
            }
        }

        private void findElementButton_Click(object sender, EventArgs e)
        {
            if (!alg.CheckEmpty(KeyTextBox1) || !alg.CheckEmpty(KeyTextBox2))
                MessageBox.Show("Заполнитие Пустые поля Ключа");
            else
            {
                animalKey = new AnimalKey(KeyTextBox1.Text, int.Parse(KeyTextBox2.Text));
                if (!alg.CheckKey(animalKey, KeyTextBox2, hashTable)) { }
                else
                {
                    if (hashTable.Contains(animalKey))
                        MessageBox.Show($"Элмент найден: {hashTable[animalKey]}");
                    KeyTextBox1.Clear();
                    KeyTextBox2.Clear();
                }
            }
        }

        private void filterCollectionButton_Click(object sender, EventArgs e)
        {
            using (var filterDialog = new FilterDialogForm())
            {
                if (filterDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedType = filterDialog.SelectedType;
                    string fieldName = filterDialog.FieldName;

                    alg.FilterCollection(selectedType, fieldName, hashTable);
                }
            }
        }

        private void sortCollectionButton_Click(object sender, EventArgs e)
        {
            List<Animal> animalsSorted = hashTable.SortAnimal(animal => animal.Age);
            var form4 = new SortListBoxForm();
            form4.ShowSortedList(animalsSorted);
            form4.ShowDialog();
        }

        private void saveCollectionButton_Click(object sender, EventArgs e)
        {
            cfl.SaveCollection(saveFileDialog, hashTable);

        }

        private void loadCollectionButton_Click(object sender, EventArgs e)
        {
            var temp = cfl.LoadCollection(openFileDialog);
            if (temp == null)
                return;
            else
                hashTable = temp;
            alg.UpdateListBox(listBox1, hashTable);
        }

        private void syncAsyncTestButton_Click(object sender, EventArgs e)
        {
            if (hashTable.isEmpty)
                MessageBox.Show("Заполните коллекцию");
            else
            {
                var form6 = new SyncAsyncForm(hashTable);
                form6.ShowDialog();
            }
        }
    }
}
