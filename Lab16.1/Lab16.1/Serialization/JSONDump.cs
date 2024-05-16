using Newtonsoft.Json;

namespace Lab16._1.Serialization
{
    public class JSONDump<T> : ISerialization<T> where T : class
    {
        JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            //для полиморфизма, чтобы могла обращаться к атрибутам дочерних классов
            TypeNameHandling = TypeNameHandling.All,
            //разбивает файл из одной строки, чтобы норм было
            Formatting = Formatting.Indented
        };
        public T Load(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return (T)JsonConvert.DeserializeObject(json, settings);
        }

        public void Save(string filePath, T serializationObj)
        {
            string json = JsonConvert.SerializeObject(serializationObj, settings);
            File.WriteAllText(filePath, json);
        }

        public async void SaveAsync(string filePath, T collection)
        {
            await Task.Run(() => Save(filePath, collection));
        }
    }
}
