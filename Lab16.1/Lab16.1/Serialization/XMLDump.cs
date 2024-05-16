using Lab10ClassLib;
using Lab12Hash;
using System;
using System.Xml.Serialization;

namespace Lab16._1.Serialization
{
    public class XMLDump<T> : ISerialization<T> where T : class
    {
        public T Load(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                return (T)serializer.Deserialize(stream);
            }
        }

        public void Save(string filePath, T serializationObj)
        {
            XmlSerializer serializer = new XmlSerializer(serializationObj.GetType());
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(stream, serializationObj);
            }
        }

        public async void SaveAsync(string filePath, T collection)
        {
            await Task.Run(() => Save(filePath, collection));
        }
    }
}
