

using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Lab10ClassLib
{
    [Serializable]
    [XmlInclude(typeof(Artiodactyl))]
    [XmlInclude(typeof(Bird))]
    [XmlInclude(typeof(Mammal))]
    [JsonDerivedType(typeof(Artiodactyl))]
    [JsonDerivedType(typeof(Bird))]
    [JsonDerivedType(typeof(Mammal))]
    public class Animal: IInit, ICloneable, IComparable
    {
        string name;
        int age;
        int weight;
        bool flag = false;
        public List<string> Check { get; set; }
        [NonSerialized]
        protected Random random = new Random();
        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Age
        {
            get => age;
            set
            {
                if (value < 1)
                    Console.WriteLine("Возраст не может быть меньше 1");
                age = value;
            }
        }

        public int Weight 
        {
            get => weight;
            set
            {
                if (value < 1)
                    Console.WriteLine("Вес не может быть меньше 1");
                weight = value;
            }
        }

        public Animal BaseAnimal { get => new Animal(Name, Age, Weight);  }


        public Animal()
        {
            Name = "Животное - " + random.Next(1, 100);
            Age = random.Next(1, 25);
            Weight = random.Next(1, 100);
            GenerateRandomAttributes();
        }

        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
            GenerateRandomAttributes();
        }
        public Animal(string name, int age, int weight)
        {
            Name = name;
            Age = age;
            Weight = weight;
            GenerateRandomAttributes();
        }
        public Animal(string name, int age, int weight, List<string> check)
        {
            Name = name;
            Age = age;
            Weight = weight;
            Check = check;
        }

        private void GenerateRandomAttributes()
        {
            int numberOfCheck = random.Next(1, 3); 
            Check = new List<string>();

            for (int i = 0; i < numberOfCheck; i++)
            {
                Check.Add($"Attribute{i + 1}");
            }
        }
        public virtual void Show()
        {
            Console.WriteLine($"Имя: {Name}, Возраст: {Age}, Вес {Weight} Аттрибут: {string.Join(", ", Check)}");
        }

        public void NonVirtShow()
        {
            Console.WriteLine($"Имя: {Name}, Возраст: {Age}, Вес {Weight}");
        }

        public virtual void Init()
        {
            Console.Write("Введите имя: ");
            Name = Console.ReadLine();

            Console.Write("Введите возраст: ");
            try
            {
                Age = Convert.ToInt32(Console.ReadLine());
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Не может быть отрицательным");
                flag = false;
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный формат");
                flag = false;
            }
        }

        public virtual void RandomInit()
        {
            Name = "Животное - " + random.Next(1, 100);
            Age = random.Next(1, 25);
            Weight = random.Next(1, 100);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Animal other = (Animal)obj;
            return Name == other.name && Age == other.age && Weight == other.weight;
        }

        public virtual object Clone() // Полное копирование
        {
            Animal clone = (Animal)MemberwiseClone();
            clone.Check = new List<string>(Check);
            return clone;
        }

        public virtual Animal ShallowCopy() // Поверхностное копирование
        {
            return (Animal)this.MemberwiseClone();
        }

        public int CompareTo(object? obj)
        {
            if (obj is null) return 1;
            else
            {
                var other = (Animal)obj;
                if (String.Compare(Name, other.Name) > 0)
                    return 1;
                else if (String.Compare(Name, other.Name) < 0)
                    return -1;
                if (Age > other.Age)
                    return 1;
                else if (Age < other.Age)
                    return -1;
                if(Weight > other.Weight)
                    return 1;
                else if(Weight < other.Weight)
                    return -1;
                return 0;
            }
        }
        public virtual string GetString()
        {
            var str = $"Имя: {Name}, Возраст: {Age}, Вес: {Weight} Аттрибут: {string.Join(", ", Check)}";
            return str;
        }
        public override string ToString()
        {
            return GetString();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Age, Weight);
        }
    }
}
