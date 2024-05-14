using Lab10ClassLib;
using Lab12Hash;
using Lab14;

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
                if (!alg.IsTextBoxInt(ValueTextBox2) || !alg.IsTextBoxInt(ValueTextBox2) || !alg.IsTextBoxInt(KeyTextBox2))
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
            string selectedSaveType = "";
            using (var saveDialog = new SaveAsDialogForm())
            {
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedSaveType = saveDialog.SelectedSaveType;
                    using (saveFileDialog)
                    {
                        // Устанавливаем фильтр для выбора типов файлов
                        switch (selectedSaveType)
                        {
                            case "Text":
                                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                                break;
                            case "Bin":
                                saveFileDialog.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
                                break;
                            case "JSON":
                                saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                                break;
                            case "XML":
                                saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                                break;
                            default:
                                MessageBox.Show("Неверный тип сохранения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                        }
                    }
                }
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    switch (selectedSaveType)
                    {
                        case "Text":
                            cfl.SaveToTextFile(filePath, hashTable);
                            break;
                        case "Bin":
                            cfl.SaveToBinaryFile(filePath, hashTable);
                            break;
                        case "JSON":
                            cfl.SaveToJsonFile(filePath, hashTable);
                            break;
                        case "XML":
                            cfl.SaveToXmlFile(filePath, hashTable);
                            break;
                    }

                    MessageBox.Show("Коллекция успешно сохранена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void loadCollectionButton_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|Binary files (*.bin)|*.bin|JSON files (*.json)|*.json|XML files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1; // Устанавливаем фильтр по умолчанию

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Определяем тип файла и вызываем соответствующий метод загрузки
                string fileExtension = Path.GetExtension(filePath).ToLower();
                var loadedCollection = new HashTable<AnimalKey, Animal>(1000);

                switch (fileExtension)
                {
                    case ".txt":
                        hashTable = cfl.LoadFromTextFile(filePath);
                        break;
                    case ".bin":
                        hashTable = cfl.LoadFromBinaryFile(filePath);
                        break;
                    case ".json":
                        hashTable = cfl.LoadFromJsonFile(filePath);
                        break;
                    case ".xml":
                        hashTable = cfl.LoadFromXmlFile(filePath);
                        break;
                    default:
                        MessageBox.Show("Неподдерживаемый формат");
                        break;
                }
            }
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
