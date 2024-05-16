using Lab10ClassLib;
using Lab12Hash;
using System.Runtime.Serialization.Formatters.Binary;

#pragma warning disable SYSLIB0011
namespace Lab16._1.Serialization
{
    public class BinaryDump<T> : ISerialization<T> where T : class
    {
        public T Load(string filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                return (T)formatter.Deserialize(stream);
            }
        }

        public void Save(string filePath, T serializationObj)
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            using (FileStream fileStream = new(filePath, FileMode.Create))
            {
                binFormatter.Serialize(fileStream, serializationObj);
            }
        }

        public async void SaveAsync(string filePath, T collection)
        {
            await Task.Run(() => Save(filePath, collection));
        }
    }
}

