using Lab10ClassLib;
using Lab12Hash;
using Lab16._1.Serialization;
using System.Collections;
using System.Windows.Forms;

namespace Lab16._1
{
    
    public class CollectionManager
    {
        BinaryDump<HashTable<AnimalKey, Animal>> binDump = new BinaryDump<HashTable<AnimalKey, Animal>>();
        TextDump<HashTable<AnimalKey, Animal>> textDump = new TextDump<HashTable<AnimalKey, Animal>>();
        JSONDump<HashTable<AnimalKey, Animal>> jsonDump = new JSONDump<HashTable<AnimalKey, Animal>>();
        XMLDump<HashTable<AnimalKey, Animal>> xmlDump = new XMLDump<HashTable<AnimalKey, Animal>>();
        public void SaveCollection(SaveFileDialog saveFileDialog, HashTable<AnimalKey, Animal> hashTable)
        {
            string selectedSaveType = "";
            using (var saveDialog = new SaveAsDialogForm())
            {
                if(saveDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
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
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                    string filePath = saveFileDialog.FileName;
                    switch (selectedSaveType)
                    {
                        case "Text":
                            textDump.Save(filePath, hashTable);
                            break;
                        case "Bin":
                            binDump.Save(filePath, hashTable);
                            break;
                        case "JSON":
                            jsonDump.Save(filePath, hashTable);
                            break;
                        case "XML":
                            xmlDump.Save(filePath, hashTable);
                            break;
                    }

                    MessageBox.Show("Коллекция успешно сохранена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                

            }
        }

        public HashTable<AnimalKey, Animal> LoadCollection(OpenFileDialog openFileDialog)
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|Binary files (*.bin)|*.bin|JSON files (*.json)|*.json|XML files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1; // Устанавливаем фильтр по умолчанию
            var hashTable = new HashTable<AnimalKey, Animal>();
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return null;
            }
            
            string filePath = openFileDialog.FileName;

            // Определяем тип файла и вызываем соответствующий метод загрузки
            string fileExtension = Path.GetExtension(filePath).ToLower();
            var loadedCollection = new HashTable<AnimalKey, Animal>(1000);

            switch (fileExtension)
            {

                case ".txt":
                    hashTable = textDump.Load(filePath);
                    break;
                case ".bin":
                    hashTable = binDump.Load(filePath);
                    break;
                case ".json":
                    hashTable = jsonDump.Load(filePath);
                    break;
                case ".xml":
                    hashTable = xmlDump.Load(filePath);
                    break;
                default:
                    MessageBox.Show("Неподдерживаемый формат");
                    break;
            }
                
            return hashTable;
        }

    }

}
