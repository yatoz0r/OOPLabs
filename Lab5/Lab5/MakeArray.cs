using System;

namespace MakeArray
{
    class ArrayClass
    {
        const int minVal = -100;
        const int maxVal = 100;
        const int minSize = 1;
        const int maxSize = 100;
        Random rnd = new Random();

        public int CheckInt(string strToUser, int begInt, int endInt)
        {
            bool isOk = false;
            int num = minVal;
            do
            {
                Console.Write(strToUser);
                try
                {
                    string buf = Console.ReadLine();
                    num = Convert.ToInt32(buf);
                    if (num >= begInt && num <= endInt) 
                        isOk = true;
                    else
                    {
                        Console.WriteLine("Ошибка. Число не входит в интервал!");
                        isOk = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка. Неверный формат!");
                    isOk = false;
                }
            } while (!isOk);
            return num;
        }
        public int[] MakeRandomArray(int arrSize)
        {
            
            int[] rndArray = new int[arrSize];

            for (int i = 0; i < arrSize; i++)
                rndArray[i] = rnd.Next(minVal, maxVal);

            return rndArray;
        }

        public int[,] MakeRandomArray(int arrSizeColumns, int arrSizeString)
        {
            
            int[,] rndArray = new int[arrSizeString, arrSizeColumns];

            for (int i = 0; i < arrSizeString; i++)
            {
                for (int j = 0; j < arrSizeColumns; j++)
                    rndArray[i, j] = rnd.Next(minVal, maxVal);
            }

            return rndArray;
        }
        public int[][] MakeRandomArray()
        {
            
            int strings = CheckInt("Введите кол-во строк(от 1 до 100): ", minSize, maxSize);
            int[][] rndArray = new int[strings][];

            for (int i = 0; i < strings; i++)
            {
                int rndColumns = rnd.Next(2,7);
                rndArray[i] = new int[rndColumns];
                for (int j = 0; j < rndColumns; j++)
                    rndArray[i][j] = rnd.Next(minVal, maxVal);
            }
            return rndArray;
        }
        public int[] MakeArray(int arrSize)
        {
            int[] array = new int[arrSize];
            for(int i = 0; i < arrSize; i++)
            {
                array[i] = CheckInt("", minVal, maxVal);
            }
            return array;
        }
        public int[ , ] MakeArray(int arrSizeString, int arrSizeColumns)
        {
            int[ , ] array = new int[arrSizeString, arrSizeColumns];
            for (int i = 0; i < arrSizeString; i++)
            {
                for(int j = 0; j < arrSizeColumns; j++)
                    array[i, j] = CheckInt("", minVal, maxVal);
            }
            return array;
        }
        public int[][] MakeArray()
        {
            int strings = CheckInt("Введите кол-во строк(от 1 до 100): ", minSize, maxSize);
            int[][] array = new int[strings][];

            for (int i = 0; i < strings; i++)
            {
                int columns = CheckInt("Введите кол-во столбцов(от 2 до 5)", 2, 5);
                array[i] = new int[columns];
                for (int j = 0; j < columns; j++)
                    array[i][j] = CheckInt("", minVal, maxVal);
            }
            return array;
        }
        public void PrintArray(int[] arr)
        {
            if (arr.Length == 0)
                Console.WriteLine("Ошибка. Пустой массив!");
            else
            {
                for (int i = 0; i < arr.Length; i++)
                    Console.Write(arr[i] + " ");
                Console.WriteLine();
            }
        }
        public void PrintArray(int[,] arr)
        {
            if (arr.Length == 0)
                Console.WriteLine("Ошибка. Пустой массив!");
            else
            {
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    Console.Write((i + 1) + ": ");
                    for (int j = 0; j < arr.GetLength(1); j++)
                        Console.Write(arr[i, j] + " ");
                    Console.WriteLine();
                }
            }
        }
        public void PrintArray(int[][] arr)
        {
            if (arr.Length == 0)
                Console.WriteLine("Ошибка. Пустой массив!");
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = 0; j < arr[i].Length; j++)
                        Console.Write(arr[i][j] + " ");
                    Console.WriteLine();
                }
            }
        }
    }
}