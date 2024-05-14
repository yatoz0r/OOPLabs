using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab10ClassLib;

namespace Lab11
{
    public class TestCollections
    {
        public List<Animal> listT = new();
        public List<string> listS = new();
        public Dictionary<Animal, Mammal> dicKV = new();
        public Dictionary<string, Mammal> dicSV = new();
        public void RandomInit()
        {
            for (int i = 0; i < 1000; ++i)
            {
                var mammal = new Mammal();
                mammal.RandomInit();
                while (listT.Contains(mammal.BaseAnimal))
                {
                    mammal.RandomInit();
                }
                listS.Add(mammal.ToString());
                listT.Add(mammal.BaseAnimal);
                dicSV.Add(mammal.ToString(), mammal);
                dicKV.Add(mammal.BaseAnimal, mammal);
            }

        }

    }
}
