using Lab10ClassLib;
using Lab12Hash;

namespace Lab14
{
    public static class ExtencionMethods
    {
        //На выборку данных по условию
        public static IEnumerable<Element<AnimalKey, Animal>> SelectAnimal(this HashTable<AnimalKey, Animal> collection, Func<Element<AnimalKey, Animal>, bool> predicate)
        {
            var subset = collection.Where(predicate);
            return subset;
        }
        //Агрегирование данных
        public static int AverageAnimal(this HashTable<AnimalKey, Animal> collection, Func<Element<AnimalKey, Animal>, bool> predicate)
        {
            IEnumerable<Element<AnimalKey, Animal>> filteredElements = collection.Where(predicate);
            IEnumerable<Animal> filteredAnimals = filteredElements.Select(element => element.Value);
            int averageWeight = (int)filteredAnimals.Select(animal => animal.Weight).Average();
            return averageWeight;
        }
        //Сортировка 
        public static List<Animal> SortAnimal(this HashTable<AnimalKey, Animal> collection, Func<Animal, int> sortByFunc)
        {
            var comparer = Comparer<Animal>.Create((animal1, animal2) => sortByFunc(animal1).CompareTo(sortByFunc(animal2)));
            var sortedList = collection.OrderBy(x => x.Value, comparer).ToList();

            // Возвращаем список значений
            return sortedList.Select(x => x.Value).ToList();
        }
        //Группировка данных
        public static IEnumerable<IGrouping<int, Animal>> GroupAnimal(this HashTable<AnimalKey, Animal> collection, Func<Animal, int> predicate)
        {
            var subset = collection.Select(x => x.Value).GroupBy(predicate);
            return subset;
        }
    }
}
