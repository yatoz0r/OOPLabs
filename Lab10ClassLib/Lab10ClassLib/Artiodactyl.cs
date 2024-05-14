

namespace Lab10ClassLib
{
    [Serializable]
    public class Artiodactyl: Mammal
    {
        int numberOfFingers;

        public int NumberOfFingers
        {
            get => numberOfFingers;
            set
            {
                if(value != 2 || value != 4)
                {
                    Console.WriteLine("Неверное кол-во пальцев(2 или 4)");
                }
                numberOfFingers = value;
            }
        }

        public Artiodactyl() => RandomInit();
        public Artiodactyl(string name, int age, int weight, bool hasFur, int numberOfHooves) : base(name, age, weight, hasFur)
        {
            NumberOfFingers = numberOfHooves;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine("Парнокопытное");
            Console.WriteLine($"Кол-во пальцев: {NumberOfFingers}");
        }

        public new void NonVirtShow()
        {
            Console.WriteLine($"Имя: {Name}, Возраст: {Age}");
            if (HasFur)
                Console.WriteLine("С мехом");
            else
                Console.WriteLine("Без меха");
            Console.WriteLine("Парнокопытное");
            Console.WriteLine($"Кол-во пальцев: {NumberOfFingers}");
        }
        public override void Init()
        {
            base.Init();

            Console.Write("Введите кол-во копыт: ");
            NumberOfFingers = Convert.ToInt32(Console.ReadLine());
        }

        public override void RandomInit()
        {
            base.RandomInit();
            int[] possibleValues = { 2, 4 };
            numberOfFingers = possibleValues[random.Next(0, possibleValues.Length)];
        }

        public virtual object Clone() // Полное копирование
        {
            return new Artiodactyl("Клон" + Name, Age, Weight, HasFur, NumberOfFingers);
        }

        public virtual Animal ShallowCopy() // Поверхностное копирование
        {
            return (Artiodactyl)this.MemberwiseClone();
        }
    }
}
