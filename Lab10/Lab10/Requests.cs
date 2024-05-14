using Lab10ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    public class Requests
    {
        // Средний возраст заданных животных
        public static double AverageAgeOfAnimals(Animal[] animals)
        {
            var selectedAnimals = animals.Where(a => a.Age > 0).ToList();

            if (selectedAnimals.Count == 0)
                return 0.0;

            double averageAge = selectedAnimals.Average(a => a.Age);

            return averageAge;
        }

        // Количество заданных животных
        public static int CountOfMammals(Animal[] animals)
        {
            int count = 0;

            foreach (var animal in animals)
            {
                if (animal is Mammal)
                {
                    count++;
                }
            }

            return count;
        }

        // Самое старое млекопитающее
        public static Animal? OldestMammal(Animal[] animals)
        {
            Animal? max = null;
            if (animals is null || animals.Length == 0)
            {
                Console.WriteLine("Массив товаров пуст");
                return max;
            }

            foreach (var item in animals)
            {
                if (item is Mammal && (max is null || item.Age > max.Age))
                    max = item;
            }
            return max;
        }

        // Самое молодое млекопитающее
        public static Animal? YoungiestMammal(Animal[] animals)
        {
            Animal? min = null;
            if (animals is null || animals.Length == 0)
            {
                Console.WriteLine("Массив животных пуст");
                return min;
            }

            foreach (var item in animals)
            {
                if (item is Mammal && (min is null || item.Age < min.Age))
                    min = item;
            }
            return min;
        }

        public static Animal? BinarySearchByAge(List<Animal> animalsList, int? target)
        {
            /*animalsList.Sort();*/
            if (target is null) return null;
            int left = 0;
            int right = animalsList.Count - 1;
            while (left <= right)
            {
                int mid = (right + left) / 2;
                int comparison = animalsList[mid].Age.CompareTo(target);

                if (comparison == 0)
                    return animalsList[mid];
                if (comparison < 0)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return null; // Объект не найден
        }

    }
}
