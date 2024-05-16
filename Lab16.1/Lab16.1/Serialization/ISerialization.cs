using Lab10ClassLib;
using Lab12Hash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab16._1
{
    public interface ISerialization<T>
    {
        public void Save(string filePath, T serializationObj);

        public T Load(string filePath);
    }
}
