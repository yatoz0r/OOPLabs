using Lab10ClassLib;
using Lab12Hash;
using MemoryPack;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace Lab16._1
{
    [Serializable]
    [MemoryPackable]
    public partial class CollectionManager
    {
#pragma warning disable SYSLIB0011
        JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            //для полиморфизма, чтобы могла обращаться к атрибутам дочерних классов
            TypeNameHandling = TypeNameHandling.All,
            //разбивает файл из одной строки, чтобы норм было
            Formatting = Formatting.Indented
        };
        public void SaveToTextFile(string filePath, HashTable<AnimalKey, Animal> collection)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var element in collection)
                {
                    writer.WriteLine($"{element}");
                }
            }
        }

        public HashTable<AnimalKey, Animal> LoadFromTextFile(string filePath)
        {
            HashTable<AnimalKey, Animal> collection = new HashTable<AnimalKey, Animal>();

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found", filePath);
            }

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
                collection.Add(key, value);
            }

            return collection;
        }


        public async Task SaveToTextFileAsync(string filePath, HashTable<AnimalKey, Animal> collection)
        {
           await Task.Run(() => SaveToTextFile(filePath, collection));
        }


        public void SaveToBinaryFile(string filePath, HashTable<AnimalKey, Animal> collection)
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            using (FileStream fileStream = new(filePath, FileMode.Create))
            {
                binFormatter.Serialize(fileStream, collection);
            }
        }

        public HashTable<AnimalKey, Animal> LoadFromBinaryFile(string filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                return (HashTable<AnimalKey, Animal>)formatter.Deserialize(stream);
            }
        }

        public async void SaveToBinaryFileAsync(string filePath, HashTable<AnimalKey, Animal> collection)
        {
            await Task.Run(() => SaveToBinaryFile(filePath, collection));
        }

        public void SaveToJsonFile(string filePath, HashTable<AnimalKey, Animal> collection)
        {
            
            string json = JsonConvert.SerializeObject(collection, settings);
            File.WriteAllText(filePath, json);
        }

        public HashTable<AnimalKey, Animal> LoadFromJsonFile(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return (HashTable<AnimalKey, Animal>)JsonConvert.DeserializeObject(json, settings);
        }

        public async void SaveToJsonFileAsync(string filePath, HashTable<AnimalKey, Animal> collection)
        {
            await Task.Run(() => SaveToJsonFile(filePath, collection));
        }

        public void SaveToXmlFile(string filePath, HashTable<AnimalKey, Animal> collection)
        {
            XmlSerializer serializer = new XmlSerializer(collection.GetType());
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(stream, collection);
            }
        }

        public HashTable<AnimalKey, Animal> LoadFromXmlFile(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(HashTable<AnimalKey, Animal>));
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                return (HashTable<AnimalKey, Animal>)serializer.Deserialize(stream);
            }
        }

        public async void SaveToXmlFileAsync(string filePath, HashTable<AnimalKey, Animal> collection)
        {
            await Task.Run(() => SaveToTextFile(filePath, collection));
        }

    }
#pragma warning disable SYSLIB0011
}
