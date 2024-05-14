using Lab10ClassLib;
namespace Lab10
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AverageAgeOfAnimalsNoValidAgeProvided()
        {
            Animal[] animals = new Animal[]
            {
            new Animal { Age = -5 },
            new Animal { Age = -3 },
            new Animal { Age = 0 }
            };

            double result = Requests.AverageAgeOfAnimals(animals);
            Assert.AreEqual(0.0, result);
        }

        [TestMethod]
        public void CountOfMammalsMammalsExist()
        {
            Animal[] animals = new Animal[]
            {
            new Mammal { Age = 3 },
            new Bird { Age = 2 },
            new Mammal { Age = 5 }
            };

            int result = Requests.CountOfMammals(animals);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void OldestMammalNotMammalsExist()
        {
            Animal[] animals = new Animal[]
            {
            new Bird { Age = 2 },
            new Bird { Age = 4 },
            new Bird { Age = 1 }
            };

            Animal? result = Requests.OldestMammal(animals);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void OldestMammalMammalsExist()
        {
            Animal[] animals = new Animal[]
            {
            new Mammal { Age = 3 },
            new Bird { Age = 2 },
            new Mammal { Age = 5 }
            };

            Animal? result = Requests.OldestMammal(animals);
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Age);
        }

        [TestMethod]
        public void YoungiestMammalNotMammalsExist()
        {
            Animal[] animals = new Animal[]
            {
            new Bird { Age = 2 },
            new Bird { Age = 4 },
            new Bird { Age = 1 }
            };
            Animal? result = Requests.YoungiestMammal(animals);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void YoungiestMammalMammalsExist()
        {
            Animal[] animals = new Animal[]
            {
            new Mammal { Age = 3 },
            new Bird { Age = 2 },
            new Mammal { Age = 5 }
            };
            Animal? result = Requests.YoungiestMammal(animals);
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Age);
        }

        [TestMethod]
        public void BinarySearchByAgeTargetIsNull()
        {
            List<Animal> animalsList = new List<Animal>
        {
            new Mammal { Age = 3 },
            new Bird { Age = 2 },
            new Mammal { Age = 5 }
        };

            Animal? result = Requests.BinarySearchByAge(animalsList, null);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void BinarySearchByAgeTargetExists()
        {
            List<Animal> animalsList = new List<Animal>
        {
            new Mammal { Age = 3 },
            new Bird { Age = 2 },
            new Mammal { Age = 5 }
        };

            Animal? result = Requests.BinarySearchByAge(animalsList, 2);
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Age);
        }

        [TestMethod]
        public void BinarySearchByAgeTargetDoesNotExist()
        {
            List<Animal> animalsList = new List<Animal>
        {
            new Mammal { Age = 3 },
            new Bird { Age = 2 },
            new Mammal { Age = 5 }
        };

            Animal? result = Requests.BinarySearchByAge(animalsList, 4);
            Assert.IsNull(result);
        }
    }
}