using Lab10ClassLib;
using Lab12Hash;

namespace Lab16._1
{
    public interface ISerialization<T>
    {
        public void Save(string filePath, T serializationObj);

        public T Load(string filePath);
    }
}
