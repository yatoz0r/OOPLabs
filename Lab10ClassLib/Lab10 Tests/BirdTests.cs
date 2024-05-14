using Lab10ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_Tests
{
    [TestClass]
    public class BirdTests
    {
        [TestMethod]
        public void BirdDefaultConstructor()
        {
            Bird bird = new Bird();

            Assert.IsNotNull(bird.Name);
            Assert.IsTrue(bird.Age >= 1);
            Assert.IsNotNull(bird.CanFly);
        }

        [TestMethod]
        public void BirdParameterizedConstructor()
        {
            string testName = "TestBird";
            int testAge = 5;
            bool testCanFly = true;

            Bird bird = new Bird(testName, testAge, testCanFly);

            Assert.AreEqual(testName, bird.Name);
            Assert.AreEqual(testAge, bird.Age);
            Assert.AreEqual(testCanFly, bird.CanFly);
        }


        [TestMethod]
        public void ShowCanFlyIsTrue()
        {
            Bird instance = new Bird();
            instance.CanFly = true;
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                instance.Show();
                string result = sw.ToString().Trim();
                Assert.IsTrue(result.Contains("Птица"));
                Assert.IsTrue(result.Contains("Умеет летать"));
            }
        }

        [TestMethod]
        public void ShowCanFlyIsFalse()
        {
            Bird instance = new Bird();
            instance.CanFly = false;
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                instance.Show();
                string result = sw.ToString().Trim();
                Assert.IsTrue(result.Contains("Птица"));
                Assert.IsTrue(result.Contains("Не умеет летать"));
            }
        }

        [TestMethod]
        public void ShowBaseShowIsCalled()
        {
            Bird instance = new Bird();
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                instance.Show();
                string result = sw.ToString().Trim();
                Assert.IsFalse(result.Contains("Базовый метод Show"));
            }
        }

        [TestMethod]
        public void BirdNonVirtShow()
        {
            Bird bird = new Bird("TestBird", 3, false);

            string expectedOutput = $"Имя: TestBird, Возраст: 3\r\nПтица\r\nНе умеет летать";
            var stringWriter = new System.IO.StringWriter();
            Console.SetOut(stringWriter);
            bird.NonVirtShow();
            string actualOutput = stringWriter.ToString().Trim();

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void BirdInit()
        {
            Bird bird = new Bird();

            var input = new System.IO.StringReader("TestBird\n3\ntrue\n");
            Console.SetIn(input);
            bird.Init();

            Assert.AreEqual("TestBird", bird.Name);
            Assert.AreEqual(3, bird.Age);
            Assert.IsTrue(bird.CanFly);
        }

        [TestMethod]
        public void BirdRandomInit()
        {
            Bird bird = new Bird();

            bird.RandomInit();

            Assert.IsNotNull(bird.Name);
            Assert.IsTrue(bird.Age >= 1);
            Assert.IsNotNull(bird.CanFly);
        }

        [TestMethod]
        public void BirdClone()
        {
            Bird original = new Bird("TestBird", 3, true);

            Bird clone = (Bird)original.Clone();

            Assert.AreEqual("КлонTestBird", clone.Name);
            Assert.AreEqual(3, clone.Age);
            Assert.AreEqual(true, clone.CanFly);
            Assert.AreNotSame(original, clone); 
        }

        [TestMethod]
        public void BirdShallowCopy()
        {
            Bird original = new Bird("TestBird", 3, false);

            Bird copy = (Bird)original.ShallowCopy();

            Assert.AreEqual(original.Name, copy.Name);
            Assert.AreEqual(original.Age, copy.Age);
            Assert.AreEqual(original.CanFly, copy.CanFly);
            Assert.AreNotSame(original, copy);
        }
    }
}
