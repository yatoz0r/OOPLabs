using Lab10ClassLib;
using Lab12Hash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab16._1.Serialization
{
    public class TextDump<T>: ISerialization<T> where T: HashTable<AnimalKey, Animal>, new()
    {
        public T Load(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found", filePath);
            }

            var result = new T();

            foreach (string line in File.ReadLines(filePath))
            {
                // Разделяем строку на атрибуты
                string[] attributes = line.Split('|');
                if (attributes.Length < 2)
                {
                    throw new FormatException("Invalid file format");
                }

                // Парсим атрибуты элемента
                string[] keyAttributes = attributes[0].Split(',');
                if (keyAttributes.Length != 2)
                {
                    throw new FormatException("Invalid key format");
                }

                string[] animalAttributes = attributes[1].Split(',');
                if (animalAttributes.Length < 3)
                {
                    throw new FormatException("Invalid animal format");
                }

                // Получаем значения атрибутов
                string keyName = keyAttributes[0].Split(':')[1].Trim();
                int keyAge = int.Parse(keyAttributes[1].Split(':')[1].Trim());

                string animalName = animalAttributes[0].Split(':')[1].Trim();
                int animalAge = int.Parse(animalAttributes[1].Split(':')[1].Trim());
                int animalWeight = int.Parse(Regex.Match(animalAttributes[2].Split(':')[1].Trim(), @"\d+").Value);

                List<string> animalCheck = new List<string>();
                if (animalAttributes.Length > 3)
                {
                    string[] checkAttributes = animalAttributes[3].Split(':');
                    for (int i = 1; i < checkAttributes.Length; i++)
                    {
                        animalCheck.Add(checkAttributes[i].Trim());
                    }
                }

                AnimalKey key = new AnimalKey(keyName, keyAge);
                Animal value = new Animal(animalName, animalAge, animalWeight, animalCheck);
                result.Add(key, value);
            }

            return result;
        }

        public void Save(string filePath, T collection)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var element in collection)
                {
                    writer.WriteLine($"{element}");
                }
            }
        }
        public async Task SaveAsync(string filePath, T collection)
        {
            await Task.Run(() => Save(filePath, collection));
        }
    }
}
