using Lab10ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_Tests
{
    [TestClass]
    public class MammalTests
    {
        [TestMethod]
        public void MammalDefaultConstructor()
        {
            Mammal mammal = new Mammal();

            Assert.IsNotNull(mammal.Name);
            Assert.IsTrue(mammal.Age >= 1);
            Assert.IsNotNull(mammal.HasFur);
        }

        [TestMethod]
        public void MammalParameterizedConstructor()
        {
            string testName = "TestMammal";
            int testAge = 5;
            bool testHasFur = true;

            Mammal mammal = new Mammal(testName, testAge, testHasFur);

            Assert.AreEqual(testName, mammal.Name);
            Assert.AreEqual(testAge, mammal.Age);
            Assert.AreEqual(testHasFur, mammal.HasFur);
        }

        [TestMethod]
        public void ShowHasFurIsTrue()
        {
            Mammal instance = new Mammal();
            instance.HasFur = true;
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                instance.Show();
                string result = sw.ToString().Trim();
                Assert.IsTrue(result.Contains("Млекопитающее"));
                Assert.IsTrue(result.Contains("С мехом"));
            }
        }

        [TestMethod]
        public void ShowHasFurIsFalse()
        {
            Mammal instance = new Mammal();
            instance.HasFur = false;
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                instance.Show();
                string result = sw.ToString().Trim();
                Assert.IsTrue(result.Contains("Млекопитающее"));
                Assert.IsTrue(result.Contains("Без меха"));
            }
        }

        [TestMethod]
        public void ShowBaseShowIsCalled()
        {
            Mammal instance = new Mammal();
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                instance.Show();
                string result = sw.ToString().Trim();
                Assert.IsFalse(result.Contains("Базовый метод Show"));
            }
        }

        [TestMethod]
        public void MammalNonVirtShow()
        {
            Mammal mammal = new Mammal("TestMammal", 3, false);

            string expectedOutput = $"Имя: TestMammal, Возраст: 3\r\nМлекопитающее\r\nБез меха";
            var stringWriter = new System.IO.StringWriter();
            Console.SetOut(stringWriter);
            mammal.NonVirtShow();
            string actualOutput = stringWriter.ToString().Trim();

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void MammalInit()
        {
            Mammal mammal = new Mammal();

            var input = new System.IO.StringReader("TestMammal\n3\ntrue\n");
            Console.SetIn(input);
            mammal.Init();

            Assert.AreEqual("TestMammal", mammal.Name);
            Assert.AreEqual(3, mammal.Age);
            Assert.IsTrue(mammal.HasFur);
        }

        [TestMethod]
        public void MammalRandomInit()
        {
            Mammal mammal = new Mammal();

            mammal.RandomInit();

            Assert.IsNotNull(mammal.Name);
            Assert.IsTrue(mammal.Age >= 1);
            Assert.IsNotNull(mammal.HasFur);
        }

        [TestMethod]
        public void MammalClone()
        {
            Mammal original = new Mammal("TestMammal", 3, true);

            Mammal clone = (Mammal)original.Clone();

            Assert.AreEqual("КлонTestMammal", clone.Name);
            Assert.AreEqual(3, clone.Age);
            Assert.AreEqual(true, clone.HasFur);
            Assert.AreNotSame(original, clone);
        }

        [TestMethod]
        public void MammalShallowCopy()
        {
            Mammal original = new Mammal("TestMammal", 3, true);

            Mammal copy = (Mammal)original.ShallowCopy();

            Assert.AreEqual(original.Name, copy.Name);
            Assert.AreEqual(original.Age, copy.Age);
            Assert.AreEqual(original.HasFur, copy.HasFur);
            Assert.AreNotSame(original, copy);
        }

    }
}
