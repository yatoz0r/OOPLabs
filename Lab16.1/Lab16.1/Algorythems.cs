using Lab10ClassLib;
using Lab12Hash;

namespace Lab16._1
{
    public class Algorythems
    {
        public void UpdateListBox(ListBox listBox1, HashTable<AnimalKey, Animal> hashTable)
        {
            listBox1.Items.Clear();
            foreach (var item in hashTable)
            {
                listBox1.Items.Add(item.ToString());
            }
        }

        public bool CheckKey(AnimalKey key, TextBox KeyTextBox2, HashTable<AnimalKey, Animal> hashTable)
        {
            if (!IsTextBoxInt(KeyTextBox2))
                MessageBox.Show("Текст в поле Возраст не является целым числом.");
            else if (hashTable.isEmpty)
            {
                MessageBox.Show("Коллекция пуста");
                return false;
            }
            else if (!hashTable.Contains(key))
            {
                MessageBox.Show("Не найден элемент");
            }
            return true;
        }
        public bool IsTextBoxInt(TextBox textBox)
        {
            int number;
            return int.TryParse(textBox.Text, out number);
        }

        public bool CheckEmpty(TextBox textBox)
        {
            if (textBox.Text == "")
                return false;
            return true;
        }

        public void FilterCollection(string type, string filed, HashTable<AnimalKey, Animal> hashTable)
        {
            List<Element<AnimalKey, int>> filteredCollection = new List<Element<AnimalKey, int>>();

            switch (type)
            {
                case "Mammal":
                    if (filed == "Age")
                    {
                        filteredCollection = hashTable.Where(x => x.Value.GetType() == typeof(Mammal))
                .Select(x => new Element<AnimalKey, int>(x.Key, x.Value.Age))
                .ToList();
                    }
                    else
                    {
                        filteredCollection = hashTable.Where(x => x.Value.GetType() == typeof(Mammal))
                    .Select(x => new Element<AnimalKey, int>(x.Key, x.Value.Weight))
                    .ToList();
                    }
                    break;
                case "Bird":
                    if (filed == "Age")
                    {
                        filteredCollection = hashTable.Where(x => x.Value.GetType() == typeof(Bird))
                .Select(x => new Element<AnimalKey, int>(x.Key, x.Value.Age))
                .ToList();
                    }
                    else
                    {
                        filteredCollection = hashTable.Where(x => x.Value.GetType() == typeof(Bird))
                        .Select(x => new Element<AnimalKey, int>(x.Key, x.Value.Weight))
                        .ToList();
                    }
                    break;
                case "Artiodactyl":
                    if (filed == "Age")
                    {
                        filteredCollection = hashTable.Where(x => x.Value.GetType() == typeof(Artiodactyl))
                    .Select(x => new Element<AnimalKey, int>(x.Key, x.Value.Age))
                    .ToList();
                    }
                    else
                    {
                        filteredCollection = hashTable.Where(x => x.Value.GetType() == typeof(Artiodactyl))
                    .Select(x => new Element<AnimalKey, int>(x.Key, x.Value.Weight))
                    .ToList();
                    }
                    break;
            }
            var form3 = new FilterListBoxForm();
            form3.UpdateFilteredCollection(filteredCollection);
            form3.ShowDialog();
        }

    }
}
