

namespace Lab10ClassLib
{
    [Serializable]
    public class Bird : Animal
    {
        bool canFly;

        public bool CanFly
        {
            get => canFly;
            set
            {
                if (value.GetType() == typeof(bool))
                {
                    canFly = (bool)value;
                }
                else
                {
                    throw new ArgumentException("Неверный тип");
                }
            }
        }

        public Bird() => RandomInit();

        public Bird(string name, int age, int weight, bool canFly) : base(name, age, weight)
        {
            CanFly = canFly;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine("Птица");
            if (CanFly)
                Console.WriteLine("Умеет летать");
            else
                Console.WriteLine("Не умеет летать");
        }

        public new void NonVirtShow()
        {
            Console.WriteLine($"Имя: {Name}, Возраст: {Age}");
            Console.WriteLine("Птица");
            if (CanFly)
                Console.WriteLine("Умеет летать");
            else
                Console.WriteLine("Не умеет летать");
        }
        public override void Init()
        {
            base.Init();

            Console.Write("Умеет ли летать? (true/false): ");
            CanFly = Convert.ToBoolean( Console.ReadLine());
        }

        public override void RandomInit()
        {
            base.RandomInit();
            Random random = new Random();
            canFly = random.Next(0, 2) == 1;
        }

        public virtual object Clone() // Полное копирование
        {
            return new Bird("Клон" + Name, Age, Weight, CanFly);
        }

        public virtual Animal ShallowCopy() // Поверхностное копирование
        {
            return (Bird)this.MemberwiseClone();
        }
    }
}
