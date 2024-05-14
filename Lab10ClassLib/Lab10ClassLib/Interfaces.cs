
using System.Collections;


namespace Lab10ClassLib
{
    public interface IInit
    {
        void Init();
        void RandomInit();
        void Show();
    }
    public class SortByAge : IComparer
    {
        int IComparer.Compare(object? obj1, object? obj2)
        {
            if (obj1 is null || obj2 is null)
                return 1;

            Animal animal1 = (Animal)obj1;
            Animal animal2 = (Animal)obj2;

            if (animal1.Age > animal2.Age)
                return 1;
            if (animal1.Age < animal2.Age)
                return -1;
            else
                return 0;
        }
    }
}
