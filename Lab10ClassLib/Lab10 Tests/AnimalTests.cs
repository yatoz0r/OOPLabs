using Lab10ClassLib;

namespace Lab10_Tests
{
    [TestClass]
    public class AnimalTests
    {
        [TestMethod]
        public void AnimalDefaultConstructor()
        {
            Animal animal = new Animal();

            Assert.IsNotNull(animal.Name);
            Assert.IsTrue(animal.Age >= 1);
        }

        [TestMethod]
        public void AnimalParameterizedConstructor()
        {
            string testName = "TestAnimal";
            int testAge = 5;

            Animal animal = new Animal(testName, testAge);

            Assert.AreEqual(testName, animal.Name);
            Assert.AreEqual(testAge, animal.Age);
        }

        [TestMethod]
        public void AnimalEquals()
        {
            Animal animal1 = new Animal("TestAnimal", 3);
            Animal animal2 = new Animal("TestAnimal", 3);

            Assert.IsTrue(animal1.Equals(animal2));
        }

        [TestMethod]
        public void AnimalCompareTo()
        {
            Animal animal1 = new Animal("TestAnimal1", 3);
            Animal animal2 = new Animal("TestAnimal2", 5);

            Assert.IsTrue(animal1.CompareTo(animal2) < 0);
            Assert.IsTrue(animal2.CompareTo(animal1) > 0);
            Assert.IsTrue(animal1.CompareTo(animal1) == 0); 
        }

        [TestMethod]
        public void AnimalNonVirtShow()
        {
            Animal animal = new Animal("TestAnimal", 3);

            string expectedOutput = $"Имя: TestAnimal, Возраст: 3";
            var stringWriter = new System.IO.StringWriter();
            Console.SetOut(stringWriter);
            animal.NonVirtShow();
            string actualOutput = stringWriter.ToString().Trim();

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void AnimalRandomInit()
        {
            Animal animal = new Animal();

            animal.RandomInit();

            Assert.IsNotNull(animal.Name);
            Assert.IsTrue(animal.Age >= 1);
        }

    }
}
