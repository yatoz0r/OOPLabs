using System;
using MakeArray;

namespace Tasks
{
    class TaskClass
    {
        const int minVal = -100;
        const int maxVal = 100;
        const int minSize = 1;
        const int maxSize = 100;
        ArrayClass obj = new ArrayClass();
        public int[] AppendElemsToStart(int[] arr)
        {
            
            int k = obj.CheckInt("Введите число элементов для добавления(1-100): ", minSize, maxSize);
            int[] newArr = new int[arr.Length + k];
            Console.Write("Введите элементы: ");
            for (int i = 0; i < k; i++)
                newArr[i] = obj.CheckInt("", minVal, maxVal);
            for (int j = 0; j < arr.Length; j++)
                newArr[j + k] = arr[j];
            return newArr;
        }

        public int[,] EraseK1K2(int[,] arr)
        {
            
            int k1 = obj.CheckInt("Введите 1 строку для удаления: ", 1, arr.GetLength(0));
            int k2 = obj.CheckInt("Введите 2 строку для удаления: ", 1, arr.GetLength(0));
            int startIndex = k1 - 1;
            int endIndex = k2 - 1;
            int[,] newArr = new int[arr.GetLength(0) - (endIndex - startIndex + 1), arr.GetLength(1)];
            int x = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (i < startIndex || i > endIndex)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                        newArr[x, j] = arr[i, j];
                    x++;
                }
            }
            return newArr;
        }
        public int[][] AddString(int[][] arr)
        {
            
            int n = obj.CheckInt("Куда вставить строку ", 1, arr.Length + 1);
            int[][] newArr = new int[arr.Length + 1][];
            int Columns = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == n - 1)
                {
                    Columns = obj.CheckInt("Введите кол-во столбцов(от 1 до 5): ", 1, 5);
                    newArr[i] = new int[Columns];
                }
                else
                {
                    Columns = arr[i].Length;
                    newArr[i] = new int[Columns];
                }
                for (int j = 0; j < Columns; j++)
                {
                    if (i == n - 1)
                    {
                        newArr[i][j] = obj.CheckInt("Введите элемент: ", minVal, maxVal);
                    }
                    else
                        newArr[i][j] = arr[i][j];
                }

            }
            for (int i = n; i < newArr.Length; i++)
            {
                Columns = arr[i - 1].Length;
                newArr[i] = new int[Columns];
                for (int j = 0; j < Columns; j++)
                    newArr[i][j] = arr[i - 1][j];
            }
            return newArr;
        }

        void PrintCase(int checkNum)
        {
            if (checkNum == 4)
            {
                Console.Clear();
                return;
            }
            ArrayClass obj = new ArrayClass();
            TaskClass newObj = new TaskClass();
            Console.Clear();
            Console.WriteLine("1. Случайное заполнение");
            Console.WriteLine("2. Заполнение вручную");
            int what;
            int arrSize = 0;
            int arrSizeCol;
            int arrSizeString;
            int[] arr1 = new int[0];
            int[,] arr2 = new int[0,0];
            int[][] arr3 = new int [0][]; 
            switch (checkNum)
            {
                case 1:
                    Console.WriteLine("3. Вставить в начало K элементов");
                    Console.WriteLine("4. Назад");
                    do
                    {
                        what = obj.CheckInt("Выберите действие>>", 1, 4);
                        switch (what)
                        {
                            case 1:
                                arrSize = obj.CheckInt("Размер массива(1-100): ", 1, 100);
                                arr1 = obj.MakeRandomArray(arrSize);
                                obj.PrintArray(arr1);
                                break;
                            case 2:
                                arrSize = obj.CheckInt("Размер массива(1-100): ", 1, 100);
                                arr1 = obj.MakeArray(arrSize);
                                obj.PrintArray(arr1);
                                break;
                            case 3:
                                if (arr1.Length == 0)
                                {
                                    Console.WriteLine("Заполните массив!");
                                    break;
                                }
                                arr1 = newObj.AppendElemsToStart(arr1);
                                obj.PrintArray(arr1);
                                break;
                            case 4:
                                what = 4;
                                Console.Clear();
                                break;
                        }
                    } while (what != 4);
                    break;
                case 2:
                    Console.WriteLine("3. Удалить строки");
                    Console.WriteLine("4. Назад");
                    do
                    {
                        what = obj.CheckInt(">>", 1, 4);
                        switch (what) 
                        { 
                            case 1:
                                arrSizeString = obj.CheckInt("Размер строки(1-100): ", 1, 100);
                                arrSizeCol = obj.CheckInt("Размер столбца(1-100): ", 1, 100);
                                arr2 = obj.MakeRandomArray(arrSizeCol, arrSizeString);
                                obj.PrintArray(arr2);
                                break;
                            case 2:
                                arrSizeString = obj.CheckInt("Размер строки(1-100): ", 1, 100);
                                arrSizeCol = obj.CheckInt("Размер столбца(1-100): ", 1, 100);
                                arr2 = obj.MakeArray(arrSizeString, arrSizeCol);
                                obj.PrintArray(arr2);
                                break;
                            case 3:
                                if (arr2.Length == 0)
                                {
                                    Console.WriteLine("Заполните массив!");
                                    break;
                                }
                                arr2 = newObj.EraseK1K2(arr2);
                                obj.PrintArray(arr2);
                                break;
                            case 4:
                                what = 4;
                                Console.Clear();
                                break;
                        }
                    } while (what != 4);
                    break;
                case 3:
                    Console.WriteLine("3. Добавить строку");
                    Console.WriteLine("4. Назад");
                    do
                    {
                        what = obj.CheckInt("Выберите действие>>", 1, 4);
                        switch (what)
                        {
                            case 1:
                                arr3 = obj.MakeRandomArray();
                                obj.PrintArray(arr3);
                                break;
                            case 2:
                                arr3 = obj.MakeArray();
                                obj.PrintArray(arr3);
                                break;
                            case 3:
                                if (arr3.Length == 0)
                                {
                                    Console.WriteLine("Заполните массив!");
                                    break;
                                }
                                arr3 = newObj.AddString(arr3);
                                obj.PrintArray(arr3);
                                break;
                            case 4:
                                what = 4;
                                Console.Clear();
                                break;
                        }
                    } while (what != 4);
                    break;
            }
        }
        public void Menu()
        {
            
            int check = 0;

            do
            {
                Console.WriteLine("1. Одномерный массив");
                Console.WriteLine("2. Двумерный массив");
                Console.WriteLine("3. Рванный массив");
                Console.WriteLine("4. Выход");
                check = obj.CheckInt(">>", 1, 4);
                PrintCase(check);

            } while (check != 4);

        }
    }

}