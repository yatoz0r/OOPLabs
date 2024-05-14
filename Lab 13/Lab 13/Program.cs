using Lab12Hash;
using Lab10ClassLib;

namespace Lab_13
{
    class Program
    {
        public static AnimalKey InputKey()
        {
            string name = "";
            int age = 1;
            var key = new AnimalKey(name, age);

            Console.WriteLine("Введите ключ");
            Console.WriteLine("Имя: ");
            name = Console.ReadLine();
            Console.WriteLine("Возраст: ");
            age = Convert.ToInt32(Console.ReadLine());

            return key = new AnimalKey(name, age);

        }
        static void Main()
        {
            var hashTable1 = new NewHashTable<AnimalKey, Animal>(5);
            var hashTable2 = new NewHashTable<AnimalKey, Animal>(5);

            var journal1 = new Journal();
            var journal2 = new Journal();

            hashTable1.CollectionCountChanged += new CollectionHandler(journal1.CollectionCountChanged);
            hashTable1.CollectionReferenceChanged += new CollectionHandler(journal1.CollectionReferenceChanged);

            hashTable1.CollectionReferenceChanged += new CollectionHandler(journal2.CollectionReferenceChanged);
            hashTable2.CollectionReferenceChanged += new CollectionHandler(journal2.CollectionReferenceChanged);

            var animals = new Animal[5];
            for (int i = 0; i < 5; i++)
            { 
                animals[i] = new Animal();
                var animalsKeys = new AnimalKey(animals[i].Name, animals[i].Age);
                hashTable1.Add(animalsKeys, animals[i]);
                hashTable2.Add(animalsKeys, animals[i]);


            }
            var key1 = new AnimalKey(animals[2].Name, animals[2].Age);
            var key2 = new AnimalKey(animals[1].Name, animals[1].Age);
            var key3 = new AnimalKey(animals[0].Name, animals[0].Age);

            hashTable1.Remove(key1);
            hashTable1.Remove(key2);
            hashTable2.Remove(key1);
            hashTable2.Remove(key2);

            var animal = new Animal("123", 123);
            var animalKey = new AnimalKey("123", 123);
            var animalEl = new Element<AnimalKey, Animal>(animalKey, animal);
            hashTable1[key3] = animalEl;
            hashTable2[key3] = animalEl;

            Console.WriteLine(journal1 + "\n\n" + journal2);
            Console.WriteLine("\tПервая хеш-таблица: ");
            hashTable1.Print();
            Console.WriteLine();
            Console.WriteLine("\tВторая хеш-таблица: ");
            hashTable2.Print();

            Console.ReadKey(true);
        }
    }
}