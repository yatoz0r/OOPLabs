using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



namespace Lab6
{
    public class Tasks
    {
        public int CheckInt(string strToUser)
        {
            bool isOk = false;
            int num = 0;
            do
            {
                Console.Write(strToUser);
                try
                {
                    string buf = Console.ReadLine();
                    num = Convert.ToInt32(buf);
                    isOk = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка. Неверный формат!");
                    isOk = false;
                }
            } while (!isOk);
            return num;
        }
        public char CheckChar(string strToUser)
        {
            bool isOk = false;
            char value = ' ';
            do
            {
                Console.Write(strToUser);
                string buf = Console.ReadLine();
                if (buf.Length == 1)
                {
                    value = Convert.ToChar(buf);
                    isOk = true;
                }
                else
                {
                    Console.WriteLine("Ошибка. Введите 1 символ.");
                    isOk = false;
                }
            } while (!isOk);
            return value;
        }
        public string CheckString(string strToUser)
        {
            bool isOk = false;
            string value = "";
            do
            {
                Console.Write(strToUser);
                string buf = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(buf)) // проверка, что строка не является пустой или состоящей только из пробелов
                {
                    value = buf;
                    isOk = true;
                }
                else
                {
                    Console.WriteLine("Ошибка. Введите непустую строку.");
                    isOk = false;
                }
            } while (!isOk);
            return value;
        }
        public char[] MakeArray(int size)
        {
            char[] array = new char[size];
            Console.WriteLine("Введите элементы: ");
            for (int i = 0; i < size; i++)
            {
                array[i] = CheckChar("");
            }
            return array;
        }
        public char[] MakeRandomArray(int size)
        {
            string rndSymbols = "abcdefghijklmnoprstuvwxyzABCDEFGHIJKLMNOPRSTUVWXYZ0123456789";
            char[] array = new char[size];
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                int index = random.Next(rndSymbols.Length);
                array[i] = rndSymbols[index];
            }
            return array;
        }

        public void PrintArray(char[] array)
        {
            if (array.Length == 0)
                Console.WriteLine("Ошибка. Пустой массив!");
            else
            {
                foreach (char c in array)
                {
                    Console.Write(c);
                }
                Console.WriteLine();
            }
        }
        public char[] DeleteDigitals(char[] array)
        {
            int count = 0;
            foreach (char c in array)
            {
                if (!char.IsDigit(c))
                {
                    count++;
                }
            }

            char[] newArray = new char[count];

            int index = 0;
            foreach (char c in array)
            {
                if (!char.IsDigit(c))
                {
                    newArray[index] = c;
                    index++;
                }
            }

            return newArray;
        }
        public void ReverseWords(string toReverse)
        {
            char[] sentenceDelimiters = { '.', '!', '?' };
            char[] wordDelimitres = { ' ', ',', ';', ':' };
            string sentencePattern = @"([.!?]+)";
            string wordPattern = "([ ,;:]+)";
            string reversedAndSortedSentence = "";
            string[] sentences = Regex.Split(toReverse,sentencePattern);

            foreach (var sentence in sentences)
            {
                string[] words = Regex.Split(sentence, wordPattern);

                Array.Reverse(words);
                Array.Sort(words, (x, y) => y.CompareTo(x)); // сравниваем слова через лямбда функцию, для сортировки по убыванию

                reversedAndSortedSentence += string.Join(" ", words.Where(w => !string.IsNullOrWhiteSpace(w)));
                
            }
            Console.WriteLine(reversedAndSortedSentence);
        }
        public void Menu()
        {
            do {
                Console.WriteLine("1. Действия с Массивом;\n" +
                    "2. Действия со строками;\n" +
                    "3. Выход.");
                int choice = CheckInt("Выберите действие>>");
                int choice2 = 0;
                switch (choice)
                {
                    case 1:
                        char[] arr = { };
                        int size;
                        Console.Clear();
                        Console.WriteLine("1. Случайное заполнение;\n" +
                            "2. Заполнение вручную;\n" +
                            "3. Удалить числа.\n" +
                            "4. Назад");          
                        do
                        {
                            choice2 = CheckInt("Выберите действие>>");
                            switch (choice2)
                            {
                                case 1:
                                    size = CheckInt("Введите размер массива: ");
                                    arr = MakeRandomArray(size);
                                    PrintArray(arr);
                                    break;
                                case 2:
                                    size = CheckInt("Введите размер массива: ");
                                    arr = MakeArray(size);
                                    PrintArray(arr);
                                    break;
                                case 3:
                                    if (arr.Length == 0)
                                    {
                                        Console.WriteLine("Заполните массив!");
                                        break;
                                    }
                                    arr = DeleteDigitals(arr);
                                    PrintArray(arr);
                                    break;
                                case 4:
                                    Console.Clear();
                                    choice2 = 4;
                                    break;
                                default:
                                    Console.WriteLine("Ошибка. Введите корректное число.");
                                    break;
                            }
                        } while (choice2 != 4);
                        break;
                    case 2:
                        string ss = "";
                        Console.Clear();
                        Console.WriteLine("1. Заполненная строка;\n" +
                            "2. Ввести строку;\n" +
                            "3. Переврнуть слова в строке.\n" +
                            "4. Назад");
                        do
                        {
                            choice2 = CheckInt("Выберите действие>>");
                            switch (choice2)
                            {
                                case 1:
                                    ss = "Волшебство природы раскрывается перед глазами! Как такое возможно? Что делает этот уголок мира таким удивительным и загадочным?" +
                                        " Ответы скрываются в каждом углу, ждущие своих исследователей и открывающие двери к новым открытиям и приключениям!";
                                    Console.WriteLine(ss);
                                   break;
                                case 2:
                                    ss = CheckString("");
                                    break;
                                case 3:
                                    if (string.IsNullOrEmpty(ss))
                                    {
                                        Console.WriteLine("Заполните строку!");
                                        break;
                                    }
                                    ReverseWords(ss);
                                    break;
                                case 4:
                                    Console.Clear();
                                    choice2 = 4;
                                    break;
                                default:
                                    Console.WriteLine("Ошибка. Введите корректное число.");
                                    break;
                            }
                        } while (choice2 != 4);
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Ошибка. Введите корректное число.");
                        break;
                }
            } while(true);


        }
    }

}
