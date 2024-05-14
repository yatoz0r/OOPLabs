using System;
using Lab9;


class Program
{
    static void Main()
    {
        int input = 0;

        do
        {
            Console.WriteLine("1. Задание 1");
            Console.WriteLine("2. Задание 2");
            Console.WriteLine("3. Задание 3");
            Console.WriteLine("4. Выход");
            Console.Write("Выберите действие ");
            bool check = false;
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
        switch (input)
            {
                case 1:
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                case 3:
                    Task3();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Неправильный ввод");
                    break;
            }
        } while (input != 4);
    }

    static void Task1()
    {
        var money = new Money();
        money.ReadMoney();

        Console.WriteLine();
        money.PrintMoney();
        Console.WriteLine();

        Console.WriteLine("Количество копеек, которое надо удалить");
        bool check = false;
        int kopeeks = 0;
        do
        {
            try
            {
                kopeeks = Convert.ToInt32(Console.ReadLine());
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
        Console.WriteLine();

        Console.WriteLine($"Метод класса {money.Rubles} руб {money.Kopeeks} коп - {kopeeks} коп");
        money.SubstractKopeeks(kopeeks);
        money.PrintMoney();
        Console.WriteLine();

        Console.WriteLine($"Статический метод {money.Rubles} руб {money.Kopeeks} коп - {kopeeks} коп");
        Money.SubstractKopeeks(money, kopeeks).PrintMoney();
        Console.WriteLine();

        Console.WriteLine("Вызвано объектов");
        int count = Money.GetCount();
        Console.WriteLine(count);
        Console.WriteLine();
    }

    static void Task2()
    {
        var money1 = new Money();
        money1.ReadMoney();
        var money2 = new Money();
        money2.ReadMoney();
        money1.PrintMoney();
        money2.PrintMoney();

        Console.WriteLine("Проверка унарных операций ++ & --");
        Console.WriteLine($"Операция -- {--money1} Операция ++ {++money1}");
        Console.WriteLine();

        Console.WriteLine("Проверка операций приведения типов");
        int rubles = money1;
        bool check = (bool)money1;
        Console.WriteLine("Рублей: " + rubles);
        Console.WriteLine("Сумма не ноль: " + check);
        Console.WriteLine();

        Console.WriteLine("Проверка бинарных операций");
        Console.WriteLine("Операция -");
        Money resultSub = money1 - money2;
        resultSub.PrintMoney();
        Console.WriteLine("Операция +");
        Money resultAddition = money1 + 70;
        resultAddition.PrintMoney();
        Console.WriteLine();
    }

    static void Task3()
    {
        var array1 = new MoneyArray(true);
        Console.WriteLine("Array 1:");
        array1.DisplayArr();

        Console.WriteLine();

        var array2 = new MoneyArray(5);
        Console.WriteLine("Array 2:");
        array2.DisplayArr();

        Console.WriteLine();

        var array3 = new MoneyArray(
            new Money(25, 55),
            new Money(58, 76),
            new Money(1, 0)
        );
        Console.WriteLine("Array 3:");
        array3.DisplayArr();

        Console.WriteLine();

        Console.WriteLine("Элемент под 3 номером: " + array3[2]);
        Console.WriteLine("Изменение значений на 1000,75 под 3 номер:");
        array3[2] = new Money(1000, 75);
        array3.DisplayArr();
        MoneyArray.AverageMoney(array3);
    }
}