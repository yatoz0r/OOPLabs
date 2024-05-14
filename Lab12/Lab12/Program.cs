using Lab10ClassLib;
using Lab12Hash;
using System;
using System.Xml.Linq;
public class Program
{
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

    public static AnimalKey InputKey()
    {
        string name = "";
        int age = 1;
        var key = new AnimalKey(name, age);

        Console.WriteLine("Введите ключ");
        Console.WriteLine("Имя: ");
        name = Console.ReadLine();
        age = Input("Возраст: ");

        return key = new AnimalKey(name, age);

    }
    public static void Main()
    {
        var hashTable = new HashTable<AnimalKey, Animal>();
        int choice;

        do
        {
            Console.WriteLine("1. Создать хеш-таблицу\n" +
            "2. Вывести хеш-таблиц\n" +
            "3. Добавить элемент\n" +
            "4. Удалить элемент\n" +
            "5. Найти элемент\n" +
            "6. Вывод с помощью foreach\n" +
            "7. Клонирование\n" +
            "8. Очистить хеш-таблиц\n" +
            "9. Очистить консоль\n" +
            "0. Выход");
            choice = Input(">> ");
            switch (choice)
            {
                case 1:
                    int size = Input("Введите размер: ");
                    hashTable = RandomHashTable(size);
                    break;

                case 2:
                    if(hashTable == null)
                    {
                        Console.WriteLine("Путсая таблица");
                        break;
                    }

                    hashTable.Print();
                    break;

                case 3:
                    {
                        Random rnd = new Random();
                        var Key = InputKey();
                        Animal animal = new Animal();
                        animal.Name = Key.Name;
                        animal.Age = Key.Age;
                        animal.Weight = rnd.Next(1, 25);
                        if (hashTable.Add(Key, animal))
                            Console.WriteLine("Элемент добавлен");
                        else
                            Console.WriteLine("Не удалось добавить элемент");
                    }
                    break;

                case 4:
                    {

                        if (hashTable == null)
                        {
                            Console.WriteLine("Путсая таблица");
                            break;
                        }
                        var Key = InputKey();
                        if (hashTable.Remove(Key))
                            Console.WriteLine("Элемент удален");
                    }
                    break;

                case 5:
                    {

                        if (hashTable == null)
                        {
                            Console.WriteLine("Путсая таблица");
                            break;
                        }
                        var Key = InputKey();
                        if (hashTable.Contains(Key))
                        {
                            Console.WriteLine("Элемент найден в хеш таблице");
                            Console.WriteLine(hashTable[Key]);
                        }
                        else
                        {
                            Console.WriteLine("Элемент не найден");
                        }
                        
                    }
                    break;

                case 6:
                    {

                        if (hashTable == null)
                        {
                            Console.WriteLine("Путсая таблица");
                            break;
                        }
                        foreach (var item in hashTable)
                            Console.WriteLine(item);
                    }
                    break;

                case 7:
                    {

                        if (hashTable == null)
                        {
                            Console.WriteLine("Путсая таблица");
                            break;
                        }
                        var shallowClone = (HashTable<AnimalKey, Animal>)hashTable.ShallowCopy();
                        Console.WriteLine("Поверхностное клонирование выполнено");
                        shallowClone.Print();
                        var deepClone = (HashTable<AnimalKey, Animal>)hashTable.Clone();
                        Console.WriteLine("Глубокое клонирование выполнено");
                        deepClone.Print();
                        Console.WriteLine("Удаление элемента из основной таблицы\n");
                        Console.WriteLine("Изменение элемента: ");
                        var Key = InputKey();
                        var animal = new Animal("123", 123);
                        var animalKey = new AnimalKey("123", 123);
                        var animalEl = new Element<AnimalKey, Animal>(animalKey, animal);
                        hashTable[Key] = animalEl;
                        Console.WriteLine("Клоны после удаления\n");
                        Console.WriteLine("Поверхностное клонирование");
                        shallowClone.Print();
                        Console.WriteLine("Глубокое клонирование");
                        deepClone.Print();
                    }
                    break;
                case 8:
                    {

                        if (hashTable == null)
                        {
                            Console.WriteLine("Путсая таблица");
                            break;
                        }
                        hashTable.Clear();
                        Console.WriteLine("Хеш-таблица очищена");
                    }
                    break;
                case 9:
                    Console.Clear();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Введите заново");
                    break;
            }
            Console.WriteLine();
        } while (choice != 0);
    }

    static HashTable<AnimalKey, Animal> RandomHashTable(int size)
    {
        var hashTable = new HashTable<AnimalKey, Animal>(size);
        var animals = new Animal[size];
        /* var animKey = new AnimalKey("", 1);*/
        for (int i = 0; i < size; i++)
        {
            animals[i] = new Animal();
            var animKey = new AnimalKey(animals[i].Name, animals[i].Age);
            hashTable.Add(animKey, animals[i]);

        }
        return hashTable;
    }
}
