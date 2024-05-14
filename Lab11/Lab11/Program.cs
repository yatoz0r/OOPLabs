using Lab10ClassLib;
using Lab11;
using System.Diagnostics;

public class Program
{
    public static string MessureTimeList<T>(List<T> list, T obj)
    {
        bool result;
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        result = list.Contains(obj);
        stopWatch.Stop();
        if (result)
            return $"Элемент найден за {stopWatch.Elapsed.TotalMilliseconds} мс";
        else
            return $"Элемент не найден. Время - {stopWatch.Elapsed.TotalMilliseconds} мс";
    }
    public static string MessureTimeDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey key)
    {
        bool result;
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        result = dictionary.ContainsKey(key);
        stopWatch.Stop();
        if (result)
            return $"Элемент найден за {stopWatch.Elapsed.TotalMilliseconds} мс";
        else
            return $"Элемент не найден. Время - {stopWatch.Elapsed.TotalMilliseconds} мс";
    }
    public static string MessureTimeDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TValue value)
    {
        bool result;
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        result = dictionary.ContainsValue(value);
        stopWatch.Stop();
        if (result)
            return $"Элемент найден за {stopWatch.Elapsed.TotalMilliseconds} мс";
        else
            return $"Элемент не найден. Время - {stopWatch.Elapsed.TotalMilliseconds} мс"; ;   
    }
    static void Main()
    {
        var test = new TestCollections();
        test.RandomInit();
        Console.WriteLine("Поиск элементов в List<Animal>:");
        Console.WriteLine("Поиск первого элемента: " + MessureTimeList(test.listT, (Animal)test.listT[0].Clone()));
        Console.WriteLine("Поиск среднего элемента: " + MessureTimeList(test.listT, (Animal)test.listT[test.listT.Count /2].Clone()));
        Console.WriteLine("Поиск последнего элемента: " + MessureTimeList(test.listT, (Animal)test.listT[test.listT.Count - 1].Clone()));
        Console.WriteLine("Поиск невходящего элемента: " + MessureTimeList(test.listT, new Animal()));
        Console.WriteLine("\n");

        Console.WriteLine("Поиск элементов в List<string>:");
        Console.WriteLine("Поиск первого элемента: " + MessureTimeList(test.listS, test.listS[0]));
        Console.WriteLine("Поиск среднего элемента: " + MessureTimeList(test.listS, test.listS[test.listT.Count / 2]));
        Console.WriteLine("Поиск последнего элемента: " + MessureTimeList(test.listS, test.listS[test.listT.Count - 1]));
        Console.WriteLine("Поиск невходящего элемента: " + MessureTimeList(test.listS, ""));
        Console.WriteLine("\n");

        Console.WriteLine("Поиск элементов по ключу в Dictionary<Animal,Mammal>:");
        Console.WriteLine("Поиск первого элемента: " + MessureTimeDictionary(test.dicKV, (Animal)test.dicKV.Keys.ToArray()[0].Clone()));
        Console.WriteLine("Поиск среднего элемента: " + MessureTimeDictionary(test.dicKV, (Animal)test.dicKV.Keys.ToArray()[test.listT.Count / 2].Clone()));
        Console.WriteLine("Поиск последнего элемента: " + MessureTimeDictionary(test.dicKV, (Animal)test.dicKV.Keys.ToArray()[test.listT.Count - 1].Clone()));
        Console.WriteLine("Поиск невходящего элемента: " + MessureTimeDictionary(test.dicKV, new Animal()));
        Console.WriteLine("\n");

        Console.WriteLine("Поиск элементов по ключу в Dictionary<string,Mammal>:");
        Console.WriteLine("Поиск первого элемента: " + MessureTimeDictionary(test.dicSV, test.dicSV.Keys.ToArray()[0]));
        Console.WriteLine("Поиск среднего элемента: " + MessureTimeDictionary(test.dicSV, test.dicSV.Keys.ToArray()[test.listT.Count / 2]));
        Console.WriteLine("Поиск последнего элемента: " + MessureTimeDictionary(test.dicSV, test.dicSV.Keys.ToArray()[test.listT.Count - 1]));
        Console.WriteLine("Поиск невходящего элемента: " + MessureTimeDictionary(test.dicSV, ""));
        Console.WriteLine("\n");

        Console.WriteLine("Поиск значения элемента в Dictionary<string,Mammal>:");
        Console.WriteLine("Поиск первого элемента: " + MessureTimeDictionary(test.dicSV, (Mammal)test.dicSV.Values.ToArray()[0].Clone()));
        Console.WriteLine("Поиск среднего элемента: " + MessureTimeDictionary(test.dicSV, (Mammal)test.dicSV.Values.ToArray()[test.listT.Count / 2].Clone()));
        Console.WriteLine("Поиск последнего элемента: " + MessureTimeDictionary(test.dicSV, (Mammal)test.dicSV.Values.ToArray()[test.listT.Count - 1].Clone()));
        Console.WriteLine("Поиск невходящего элемента: " + MessureTimeDictionary(test.dicSV, new Mammal()));
        Console.WriteLine("\n");
    }
}