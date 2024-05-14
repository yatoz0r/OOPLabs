using Lab10ClassLib;

namespace Lab12Hash
{
    [Serializable]
    public class AnimalKey : Animal
    {
        public AnimalKey() { }
        public AnimalKey(string name, int age) : base(name, age) { }

        public override int GetHashCode()
        {
            int hash = base.GetHashCode();
            return HashCode.Combine(Name, Age, hash);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (AnimalKey)obj;
            return Name == other.Name && Age == other.Age;
        }

        public override string ToString()
        {
            return $"Имя: {Name}, Возраст: {Age} ";
        }
    }
}
