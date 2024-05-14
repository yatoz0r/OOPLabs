

namespace Lab10ClassLib
{
    [Serializable]

    public class Mammal: Animal
    {
        bool hasFur;

        public bool HasFur
        {
            get => hasFur;
            set
            {
                if (value.GetType() == typeof(bool))
                {
                    hasFur = (bool)value;
                }
                else
                {
                    throw new ArgumentException("Неверный тип");
                }
            }
        }

        public Mammal() => RandomInit();
        public Mammal(string name, int age, int weight, bool hasFur) : base(name, age, weight)
        {
            HasFur = hasFur;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine("Млекопитающее");
            if (HasFur)
                Console.WriteLine("С мехом");
            else
                Console.WriteLine("Без меха");
        }
        public new void NonVirtShow()
        {
            Console.WriteLine($"Имя: {Name}, Возраст: {Age}");
            Console.WriteLine("Млекопитающее");
            if (HasFur)
                Console.WriteLine("С мехом");
            else
                Console.WriteLine("Без меха");
        }

        public override void Init()
        {
            base.Init();

            Console.Write("Есть ли мех? (true/false): ");
            HasFur = Convert.ToBoolean(Console.ReadLine());
        }

        public override void RandomInit()
        {
            base.RandomInit();
            hasFur = random.Next(0, 2) == 1;
        }

        public virtual object Clone() // Полное копирование
        {
            return new Mammal("Клон" + Name, Age, Weight, HasFur);
        }

        public virtual Animal ShallowCopy() // Поверхностное копирование
        {
            return (Mammal)this.MemberwiseClone();
        }
    }
}
