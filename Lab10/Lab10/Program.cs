using Lab10;
using Lab10ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

class Program1
{
    static Animal[] MenuArray(Animal[] animals)
    {
        Console.Clear();
        Console.WriteLine("Заполнение массива");
        Console.WriteLine("1. Случайное заполнение\n" +
                          "2. Ввод с клавиатуры\n" +
                          "3. Назад");
        Console.Write("Выберите действие >>");
        do
        {
            choice = 0;
            do
            {
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
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
            switch (choice)
            {
                case 1:
                    animals = RandomAnimalArray();
                    Console.WriteLine("Создан случаный массив животных");
                    DisplayVirtual(animals);
                    break;
                case 2:
                    animals = AnimalArray();
                    DisplayVirtual(animals);
                    break;
                case 3:
                    return animals;
                default:
                    Console.WriteLine("Неверный ввод");
                    break;
            }


        } while (choice != 3);
        return animals;
    }
    static Animal[] RandomAnimalArray()
    {
        Console.WriteLine("Введите размер массива: ");
        int size = 0;
        do
        {
            try
            {
                size = Convert.ToInt32(Console.ReadLine());
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
        Animal[] animals = new Animal[size];
        for (int i = 0; i < size; i++)
        {
            var rnd = new Random();
            int item = rnd.Next(1, 4);
            switch (item)
            {
                case 1:
                    animals[i] = new Animal(); break;
                case 2:
                    animals[i] = new Mammal(); break;
                case 3:
                    animals[i] = new Artiodactyl(); break;
                case 4:
                    animals[i] = new Bird(); break;
            }
        }
        return animals;
    }

    static Animal MenuTypeProducts()
    {
        var animal = new Animal();
        
        Console.WriteLine("Выберите тип товара. Если не выберите - случайный выбор");
        do
        {
            choice = 0;
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
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
        switch (choice)
        {
            case 1:
                animal = new Animal();
                animal.Init();
                break;
            case 2:
                animal = new Mammal();
                animal.Init();
                break;

            case 3:
                animal = new Artiodactyl();
                animal.Init();
                break;

            case 4:
                animal = new Bird();
                animal.Init();
                break;

            default:
                Console.WriteLine("Случайный выбор");
                var random = new Random();
                int randomChoice = random.Next(1, 5);

                switch (randomChoice)
                {
                    case 1:
                        animal = new Animal();
                        animal.Init();
                        break;
                    case 2:
                        animal = new Mammal();
                        animal.Init();
                        break;
                    case 3:
                        animal = new Artiodactyl();
                        animal.Init();
                        break;
                    case 4:
                        animal = new Bird();
                        animal.Init();
                        break;
                }
                break;

        }
        Console.WriteLine("Созданный массив:\n" + animal);
        return animal;
    }

    static Animal[] AnimalArray()
    {
        Console.WriteLine("Введите размер массива: ");
        int size = Convert.ToInt32(Console.ReadLine());
        Animal[] animals = new Animal[size];
        for (int i = 0; i < size; i++)
        {
            animals[i] = MenuTypeProducts();

        }

        return animals;
    }

    static void DisplayIInit()
    {
        Console.WriteLine("\tИнтерфейс IInit: ");
        IInit[] initObj = new IInit[]
           {
            new Animal(),
            new Mammal(),
            new Artiodactyl(),
            new Bird(),
            new Class()
           };

        Console.WriteLine("Создан IInit из 5 объектов классов Animal, Mammal, Artiodactyl, Bird, Class");

        int count = 1;
        foreach (var item in initObj)
        {
            Console.WriteLine($"Создается объект {count++}: {item.GetType()}");
            item.RandomInit();
            item.Show();
            Console.WriteLine();
        }
    }

    static void DisplaySortByIComparable()
    {
        Animal[] animal = RandomAnimalArray();

        Array.Sort(animal);
        Console.WriteLine("Отсортированный массив: ");
        DisplayVirtual(animal);
    }

    static void DisplaySortByICompare()
    {
        Animal[] animal = RandomAnimalArray();

        Array.Sort(animal, new SortByAge());
        Console.WriteLine("Отсортированный массив по цене: ");
        DisplayVirtual(animal);


    }

    static void DisplayVirtual(Animal[] animals)
    {
        if (animals is null || animals.Length == 0)
        {
            Console.WriteLine("Массив товаров пуст.");
            return;
        }
        int count = 1;
        foreach (var animal in animals)
        {
            Console.WriteLine(count++);
            animal.Show();
            Console.WriteLine();
        }
    }


    static void DisplayNonVirtual(Animal[] animals)
    {
        if (animals is null || animals.Length == 0)
        {
            Console.WriteLine("Массив пустой");
            return;
        }
        int count = 1;
        foreach (Animal animal in animals)
        {
            Console.WriteLine(count++);
            animal.NonVirtShow();
            Console.WriteLine();
        }
    }

    static void DisplayAvgAge(Animal[] animals)
    {
        Console.WriteLine($"Средний возраст животных: " + Requests.AverageAgeOfAnimals(animals));
    }

    static void DisplayCountAnimals(Animal[] animals)
    {
        Console.WriteLine($"Количество млекопитющих: " + Requests.CountOfMammals(animals));
    }

    static void DisplayOldAndYoung(Animal[] animals)
    {
        Animal? max = Requests.OldestMammal(animals);
        Animal? min = Requests.YoungiestMammal(animals);
        if (min is null || max is null)
            Console.WriteLine("Млекопитающих в Животных нет.");
        else
            Console.WriteLine($"Имена самых старых и молодых животных: {max.Name} {max.Age}, {min.Name} {min.Age}");
    }

    static void DisplayBinarySearch(Animal[] animals)
    {
        var listOfAnimals = new List<Animal>(animals);

        listOfAnimals.Sort((x, y) => x.Age.CompareTo(y.Age));

        Console.Write("Введите возраст животного для поиска: ");
        int age = 0;
        bool flag = false;
        try
        {
            age = Convert.ToInt32(Console.ReadLine());
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
        var result = Requests.BinarySearchByAge(listOfAnimals, age);

        if (result is not null)
            Console.WriteLine("Найденное животное:\n" + result);
        else
            Console.WriteLine("Животное не найдено");

    }

    static void DisplayClone()
    {
        Animal originalAnimal = new("Оригинал", 5);

        Console.WriteLine("\nОригинальное животное:\n");
        originalAnimal.Show();

        Animal clonedAnimal = (Animal)originalAnimal.Clone();
        Console.WriteLine("Полное копирование:\n");
        clonedAnimal.Show();

        Animal shallowCopiedAnimal = originalAnimal.ShallowCopy();
        Console.WriteLine("Поверхностное копирование:\n");
        shallowCopiedAnimal.Show();
        Console.WriteLine("\n\n");

        originalAnimal.Check.Add("Новый атрибут");

        Console.WriteLine("После изменений:");
        Console.WriteLine("Оригинальное животное:\n");
        originalAnimal.Show();

        Console.WriteLine("Полное копирование:\n");
        clonedAnimal.Show();

        Console.WriteLine("Поверхностное копирование:\n");
        shallowCopiedAnimal.Show();
    }

    static void RequestsMenu(Animal[] animals)
    {
        Console.Clear();
        Console.WriteLine("Запросы");
        Console.WriteLine("1. Средний возраст животных\n" +
                          "2. Количество животных \n" +
                          "3. Самое старое и молодое животное\n" +
                          "4. Бинарный поиск по возрасту животного\n" +
                          "5. Назад");
        do
        {
            do
            {
                choice = 0;
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
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
            switch (choice)
            {
                case 1:
                    DisplayAvgAge(animals);
                    break;
                case 2:
                    DisplayCountAnimals(animals);
                    break;
                case 3:
                    DisplayOldAndYoung(animals);
                    break;
                case 4:
                    DisplayBinarySearch(animals);
                    break;
                case 5:
                    choice = 5;
                    break;
                default:
                    Console.WriteLine("Неверный ввод");
                    break;

            }
        } while (choice != 5);
        choice = 0;
    }

    static void ShowMenu(Animal[] animals)
    {
        Console.Clear();
        Console.WriteLine("1. Виртуальный метод\n" +
                          "2. Невиртуальный\n" +
                          "3. Назад");
        do
        {
            do
            {
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
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
            switch (choice)
            {
                case 1:
                    DisplayVirtual(animals);
                    break;
                case 2:
                    DisplayNonVirtual(animals);
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Неверный ввод");
                    break;
            }
        } while (choice != 3);
    }

    static void Menu()
    {
        Animal[] animals = Array.Empty<Animal>();
        do
        {
            choice = 0;
            Console.Clear();
            Console.WriteLine("1. Создание массива животных\n" +
                              "2. Вывод массива\n" +
                              "3. Выполнить запросы\n" +
                              "4. Задание 3\n" +
                              "5. Выход");
            Console.Write("Выберите действие >>");
            do
            {
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
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
            switch (choice)
            {
                case 1:
                    animals = MenuArray(animals);
                    break;
                case 2:
                    ShowMenu(animals);
                    break;
                case 3:
                    RequestsMenu(animals);
                    break;
                case 4:
                    DisplayIInit();
                    Console.WriteLine("ICOMPARABLE:");
                    DisplaySortByIComparable();
                    Console.WriteLine("ICOMPARE:");
                    DisplaySortByICompare();
                    Console.WriteLine("КЛОНИРОВАНИЕ:");
                    DisplayClone();
                    Console.ReadLine();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Неверынй ввод");
                    break;
            }
        } while (choice != 5);
    }

    static void Main()
    {
        Menu();
    }

    static int choice = 0;
    static bool check = false;
}


