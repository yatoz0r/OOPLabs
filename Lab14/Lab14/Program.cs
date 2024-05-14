using Lab10ClassLib;
using Lab12Hash;


namespace Lab14
{ 
    public class Preogram 
    {
        static Random rnd = new Random();
        public static int Input(string stringToUser)
        {
            int input = 0;
            bool check = false;
            Console.Write(stringToUser);
            do
            {
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    check = true;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Не может быть отрицательным");
                    check = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный формат");
                    check = false;
                }
            } while (!check);

            return input;
        }

        public static Dictionary<int, Queue<Animal>> CreateRandomDictonary(int sizeDictionary, int sizeQueue)
        {

            var zoo = new Dictionary<int, Queue<Animal>>();
            for (int i = 1; i <= sizeDictionary; i++)
            {
                var section = new Queue<Animal>();
                for (int j = 0; j < sizeQueue; j++)
                {
                    int item = rnd.Next(1, 4);
                    switch (item)
                    {
                        case 1:
                            section.Enqueue(new Mammal());
                            break;
                        case 2:
                            section.Enqueue(new Bird());
                            break;
                        case 3:
                            section.Enqueue(new Artiodactyl());
                            break;
                    }
                }
                zoo.Add(i, section);
            }
            return zoo;
        }

        public static HashTable<AnimalKey, Animal> CreateRandomHash(int size)
        {
            var hashTable = new HashTable<AnimalKey, Animal>(size);
            for (int i = 1; i <= size; i++)
            {
                int item = rnd.Next(1, 4);
                switch (item)
                {
                    case 1:
                        var mammal = new Mammal();
                        var mammalKey = new AnimalKey(mammal.Name, mammal.Age);
                        hashTable.Add(mammalKey,mammal);
                        break;
                    case 2:
                        var bird = new Bird();
                        var birdKey = new AnimalKey(bird.Name, bird.Age);
                        hashTable.Add(birdKey, bird);
                        break;
                    case 3:
                        var artiodactyl = new Artiodactyl();
                        var artiodactylKey = new AnimalKey(artiodactyl.Name, artiodactyl.Age);
                        hashTable.Add(artiodactylKey, artiodactyl);
                        break;
                }
            }
            return hashTable;
        }
        //Выборка данных
        public static void LinqQueue1(Dictionary<int, Queue<Animal>> zoo)
        {
            Console.WriteLine("\nВывод животных, чей возраст меньше 10 (LINQ): \n");
            var subset = from key in zoo.Keys
                         from Animal animal in zoo[key]
                         where animal is Animal value
                         && (animal.Age > 10)
                         select animal;
            foreach (Animal s in subset)
                Console.WriteLine(s);
        }
        public static void ExtensionQueue1(Dictionary<int, Queue<Animal>> zoo)
        {
            Console.WriteLine("\nВывод организаций, чей возраст меньше 10 (Методы расширения): \n");
            var subsetMethod = zoo.Values.SelectMany(animal => animal.Where(animal => animal is Animal value &&
                (animal.Age > 10)).Select(animal => animal));
            foreach (Animal s in subsetMethod)
                Console.WriteLine(s);
        }
        //Получение счетчика (количества объектов с заданным параметром).
        static void LinqQueue2(Dictionary<int, Queue<Animal>> zoo)
        {
            int subset = (from key in zoo.Keys
                          from Animal animal in zoo[key]
                          where animal is Bird value
                          select animal).Count();
            Console.Write("\nКол-во птиц в зоопарке (LINQ): " + subset);
        }
        static void ExtensionQueue2(Dictionary<int, Queue<Animal>> zoo)
        {
            int subsetMethod = zoo.Values.SelectMany(animal => animal.Where(animal => animal is Bird value)).Count();
            Console.Write("\nКол-во птиц в зоопарке (Методы расширения): " + subsetMethod);
        }
        //Использование операций над множествами (пересечение, объединение, разность)
        static void LinqQueue3(Dictionary<int, Queue<Animal>> zoo)
        {
            Console.WriteLine("\nОбъединение парнокопытных и млекопитающих(С помощью Linq): \n");
            var subset = (from key in zoo.Keys
                          from Animal animal in zoo[key]
                          where animal is Artiodactyl value
                          select animal).Union
                         (from key in zoo.Keys
                          from animal in zoo[key]
                          where animal is Mammal value
                          select animal);
            foreach (Animal s in subset)
                Console.WriteLine(s);
        }
        static void ExtensionQueue3(Dictionary<int, Queue<Animal>> zoo)
        {
            Console.WriteLine("\nОбъединение парнокопытных и млекопитающих (Методы расширения): \n");
            var subsetMammal = zoo.Values.SelectMany(mammal => mammal.Where(mammal => mammal is Mammal));
            var subsetArtiodactyl = zoo.Values.SelectMany(artiod => artiod.Where(artiod => artiod is Artiodactyl));
            var unionSubsets = subsetMammal.Union(subsetArtiodactyl);
            foreach (Animal s in unionSubsets)
                Console.WriteLine(s);
        }
        //агрегирование данных
        static void LinqQueue4(Dictionary<int, Queue<Animal>> zoo)
        {
            int subset = (int)(from key in zoo.Keys
                          from Animal animal in zoo[key]
                          where animal is Mammal value
                          select animal.Weight).Average();
            Console.Write("\nСредний вес животных заданного вида в зоопарке (LINQ): " + subset);
        }
        static void ExtensionQueue4(Dictionary<int, Queue<Animal>> zoo)
        {
            int subsetMethod = (int)zoo.Values.SelectMany(mammal => mammal.Where(mammal => mammal is Mammal)).Select(mammal => mammal.Weight).Average();
            Console.Write("\nСредний вес животных заданного вида в зоопарке (Методы расширения): " + subsetMethod);
        }
        //Группировка данных
        static void LinqQueue5(Dictionary<int, Queue<Animal>> zoo)
        {
            Console.WriteLine("\nГруппировка по возрасту (LINQ): \n");
            var subset = (from key in zoo.Keys
                          from Animal animal in zoo[key]
                          group animal by animal.Age into a
                          select new { Age = a.Key, Count = a.Count() }).ToList();
            foreach (var item in subset)
                Console.WriteLine(item.Age + " - " + item.Count);
        }
        static void ExtensionQueue5(Dictionary<int, Queue<Animal>> zoo)
        {
            Console.WriteLine("\nГруппировка по возрасту (Методы расширения): \n");
            var subsetMethod = zoo.Values.SelectMany(animal => animal)
                .GroupBy(animal => animal.Age)
                .Select(a => new { Age = a.Key, Count = a.Count() }).ToList();
            foreach (var item in subsetMethod)
                Console.WriteLine(item.Age + " - " + item.Count);
        }


        //На выборку данных по условию.
        static void HashMethod1(HashTable<AnimalKey, Animal> hashTable)
        {
            Console.WriteLine("\nИмена всех птиц\n");
            var subset = hashTable.SelectAnimal(animal => animal.Value is Bird);
            foreach (var s in subset)
                Console.WriteLine(s);
        }
        //Агрегирование данных
        static void HashMethod2(HashTable<AnimalKey, Animal> hashTable)
        {
            Console.Write("Средний вес животных заданного вида в зоопарке: ");
            var subset = hashTable.AverageAnimal(animal => animal.Value is Mammal);
            Console.WriteLine(subset);
        }
        //Сортировка
        static void HashMethod3(HashTable<AnimalKey, Animal> hashTable)
        {
            Console.WriteLine("\nСортировка по возрасту животных\n");
            List<Animal> newHash = hashTable.SortAnimal(animal => animal.Age);
            foreach (var s in newHash)
                Console.WriteLine(s);
        }
        //Группировка данных
        static void HashMethod4(HashTable<AnimalKey, Animal> hashTable)
        {
            Console.WriteLine("\nГруппировка по возрасту\n");
            var subset = hashTable.GroupAnimal(animal => animal.Age).Select(a => new { Age = a.Key, Count = a.Count() }).ToList();

            foreach (var item in subset)
                Console.WriteLine(item.Age + " - " + item.Count);
        }

        static void Main(string[] args)
        {
            int dictonarySize = Input("Введите кол-во Зоопарков: ");
            int queueSize = Input("Введите кол-во секций: ");
            Dictionary<int, Queue<Animal>> zoo = CreateRandomDictonary(dictonarySize, queueSize);
            Console.WriteLine("\tЭлементы словаря: ");
            foreach (var key in zoo.Keys)
            {
                Console.WriteLine($"Ключ: {key}");
                Console.WriteLine("Элементы очереди");
                for (int i = 0; i < queueSize; ++i)
                {
                    var element = zoo[key].Dequeue();
                    Console.WriteLine(element);
                    zoo[key].Enqueue(element);
                }
            }
            Console.WriteLine("\n\n-------- 1 часть -------\n\n");

            LinqQueue1(zoo);
            ExtensionQueue1(zoo);

            LinqQueue2(zoo);
            ExtensionQueue2(zoo);

            LinqQueue3(zoo);
            ExtensionQueue3(zoo);

            LinqQueue4(zoo);
            ExtensionQueue4(zoo);

            LinqQueue5(zoo);
            ExtensionQueue5(zoo);

            Console.WriteLine("\n\n-------- 2 часть -------\n\n");
            int size = Input("Введите размер таблицы: ");
            HashTable<AnimalKey, Animal> hashTable = CreateRandomHash(size);
            Console.WriteLine("Созданная хеш-таблица:\n");
            hashTable.Print();
            HashMethod1(hashTable);
            HashMethod2(hashTable);
            HashMethod3(hashTable);
            HashMethod4(hashTable);
        }
    }
}
