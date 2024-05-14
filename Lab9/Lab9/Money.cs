using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    public class Money
    {

        public Money() : this(0, 0) { }
        public Money(int rubles) : this(rubles, 0) { }

        public Money(int rubles, int kopeeks)
        {
            this.Rubles = rubles;
            this.Kopeeks = kopeeks;
            count++;
        }
        public int Rubles
        {
            get => this.rubles;
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Рубли не могут быть отрицательными");
                    this.rubles = 0;
                }
                else
                    this.rubles = value;
            }
        }

        public int Kopeeks
        {
            get => this.kopeeks;
            set
            {
                
                if (value < 0)
                {
                    Console.WriteLine("Копейкм не могут быть отрицательными");
                    this.kopeeks = 0;
                }
                else
                    this.kopeeks = value;
                if (value > 99)
                    Adjustment(this.rubles, value);
            }
        }



        public void Adjustment(int rub, int kop)
        {
            int totalMoney = (rub * 100) + kop;
            this.Rubles = totalMoney / 100;
            this.Kopeeks = totalMoney % 100;
        }
        
        // Метод класса
        public void SubstractKopeeks(int kopeeks)
        {
            int totalKopeeks = this.Rubles * 100 + this.Kopeeks - kopeeks;
            if(totalKopeeks < 0)
            {
                Console.WriteLine("Разница меньше нуля");
                this.Rubles = 0;
                this.Kopeeks = 0;
            }
            this.Rubles = 0;
            this.Kopeeks = totalKopeeks;
        }

        // Статический метод
        public static Money SubstractKopeeks(Money money, int kopeks)
        {
            int totalKopeeks = (money.rubles * 100) + money.kopeeks - kopeks;
            Money newMoney = new Money();
            if (totalKopeeks < 0)
            {
                Console.WriteLine("Разница меньше нуля");
                newMoney.Rubles = 0;
                newMoney.Kopeeks = 0;
            }
            newMoney.Kopeeks = totalKopeeks;
            return newMoney;
        }
        public void PrintMoney() =>  Console.WriteLine($"Сумма: {Rubles} руб. {Kopeeks} коп.");

        //Перегруженная ToString для вывода объекта класса
        public override string ToString()
        {
            return $"Сумма: {Rubles} руб. {Kopeeks} коп.";
        }

        public static int GetCount() => count;

        public void ReadMoney()
        {
            Console.WriteLine("Введите рубли");
            bool check = false;
            do
            {
                try
                {
                    Rubles = Convert.ToInt32(Console.ReadLine());
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
            Console.WriteLine("Введите копейки");
            check = false;
            do
            {
                try
                {
                    Kopeeks = Convert.ToInt32(Console.ReadLine());
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
        }
        
        // Перегруженные методы
        // Унарные операции
        public static Money operator --(Money money)
        {
            return new Money(money.Rubles, --money.Kopeeks);
        }
        public static Money operator ++(Money money)
        {
            return new Money(money.Rubles, ++money.Kopeeks);
        }

        // Операции приведения
        public static implicit operator int(Money money)
        {
            return money.Rubles;
        }

        public static explicit operator bool(Money money)
        {
            return money.Rubles != 0 || money.Kopeeks != 0;
        }

        // Бинарные операции 
        public static Money operator -(Money m1, Money m2)
        {
            int totalKopeks1 = m1.Rubles * 100 + m1.Kopeeks;
            int totalKopeks2 = m2.Rubles * 100 + m2.Kopeeks;
            Money newMoney = new Money();
            newMoney.Kopeeks = (totalKopeks1 - totalKopeks2);
            return newMoney;
        }

        // Оператор увеличения копеек для объекта Money и целого числа
        public static Money operator +(Money m, int kopeks)
        {
            int totalKopeeks = m.Rubles * 100 + m.Kopeeks + kopeks;
            Money newMoney = new Money();
            newMoney.Kopeeks = totalKopeeks;
            return newMoney;
        }

        public static Money operator +(Money m1, Money m2)
        {
            int totalKopeks1 = m1.Rubles * 100 + m1.Kopeeks;
            int totalKopeks2 = m2.Rubles * 100 + m2.Kopeeks;
            Money newMoney = new Money();
            newMoney.Kopeeks = (totalKopeks1 + totalKopeks2);
            return newMoney;
        }
        public static Money operator /(Money m, int size)
        {
            int totalKopeeks = m.Rubles * 100 + m.Kopeeks;
            Money newMoney = new Money();
            newMoney.Kopeeks = (totalKopeeks / size);
            return newMoney;
        }

        private int rubles;

        private int kopeeks;

        static int count = 0;

    }
}
