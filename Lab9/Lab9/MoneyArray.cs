using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    public class MoneyArray
    {
        public MoneyArray() : this(0) { }

        public MoneyArray(int size)
        {
            if (size < 0)
            {
                Console.WriteLine("Размер не может быть меньше 0");
                size = 0;
            }
            arr = new Money[size];
            var rnd = new Random();

            for(int i = 0; i < size; i++)
            {
                int rubles = rnd.Next(1000);
                int kopeks = rnd.Next(0, 99);
                arr[i] = new Money(rubles, kopeks);
            }
            count++;
        }

        public MoneyArray(bool c)
        {
            int size = 0;
            bool check = false;
            do
            {
                Console.WriteLine("Введите размер массива");
                try
                {
                    size = Convert.ToInt32(Console.ReadLine());
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
            arr = new Money[size];

            for(int i = 0; i < size; i++)
            {
                arr[i] = new Money();
                arr[i].ReadMoney();
            }
            count++;
        }

        public MoneyArray(params Money[] money)
        {
            arr = new Money[money.Length];

            for (int i = 0; i < money.Length; i++)
            {
                arr[i] = money[i];
            }
        }
        public void DisplayArr()
        {
            if (arr.Length == 0)
            {
                Console.WriteLine("Массив пуст.");
            }
            foreach (Money money in arr)
            {
                money.PrintMoney();
            }
        }

        public Money this[int index]
        {
            get
            {
                if (index < 0 || index >= arr.Length)
                    throw new IndexOutOfRangeException("Выход за границы");
                return arr[index];
            }
            set
            {
                if (index < 0 || index >= arr.Length)
                    throw new IndexOutOfRangeException("Выход за границы");
                arr[index] = value;
            }
        }

        public static Money? AverageMoney(MoneyArray arr)
        {
            if (arr == null || arr.Size == 0)
            {
                Console.WriteLine("Пустой массив");
                return null;
            }
            Money avgMoney = new Money();
            for (int i = 0; i < arr.Size; i++)
            {
                avgMoney += arr[i];
            }
            avgMoney /= arr.Size;
            Console.WriteLine($"Среднее значение: {avgMoney}");
            return avgMoney;

        }

        private Money[] arr;
        public int Size => arr.Length;

        private static int count = 0;
        public static int Count() => count;
    }
}
