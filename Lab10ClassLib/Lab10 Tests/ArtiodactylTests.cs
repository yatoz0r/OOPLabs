using Lab10ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_Tests
{
    [TestClass]
    public class ArtiodactylTests
    {

        [TestMethod]
        public void ArtiodactylDefaultConstructor()
        {
            Artiodactyl artiodactyl = new Artiodactyl();

            Assert.IsNotNull(artiodactyl.Name);
            Assert.IsTrue(artiodactyl.Age >= 1);
            Assert.IsNotNull(artiodactyl.HasFur);
            Assert.IsTrue(artiodactyl.NumberOfFingers == 2 || artiodactyl.NumberOfFingers == 4);
        }

        [TestMethod]
        public void ArtiodactylParameterizedConstructor()
        {
            string testName = "TestArtiodactyl";
            int testAge = 5;
            bool testHasFur = true;
            int testNumberOfFingers = 4;

            Artiodactyl artiodactyl = new Artiodactyl(testName, testAge, testHasFur, testNumberOfFingers);

            Assert.AreEqual(testName, artiodactyl.Name);
            Assert.AreEqual(testAge, artiodactyl.Age);
            Assert.AreEqual(testHasFur, artiodactyl.HasFur);
            Assert.AreEqual(testNumberOfFingers, artiodactyl.NumberOfFingers);
        }

        [TestMethod]
        public void ArtiodactylNonVirtShow()
        {
            Artiodactyl artiodactyl = new Artiodactyl("TestArtiodactyl", 3, false, 4);

            string expectedOutput = $"Имя: TestArtiodactyl, Возраст: 3\r\nБез меха\r\nПарнокопытное\r\nКол-во пальцев: 4";
            var stringWriter = new System.IO.StringWriter();
            Console.SetOut(stringWriter);
            artiodactyl.NonVirtShow();
            string actualOutput = stringWriter.ToString().Trim();

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void ArtiodactylInit()
        {
            Artiodactyl artiodactyl = new Artiodactyl();

            var input = new System.IO.StringReader("TestArtiodactyl\n3\ntrue\n4\n");
            Console.SetIn(input);
            artiodactyl.Init();

            Assert.AreEqual("TestArtiodactyl", artiodactyl.Name);
            Assert.AreEqual(3, artiodactyl.Age);
            Assert.IsTrue(artiodactyl.HasFur);
            Assert.AreEqual(4, artiodactyl.NumberOfFingers);
        }

        [TestMethod]
        public void ArtiodactylRandomInit()
        {
            Artiodactyl artiodactyl = new Artiodactyl();

            artiodactyl.RandomInit();

            Assert.IsNotNull(artiodactyl.Name);
            Assert.IsTrue(artiodactyl.Age >= 1);
            Assert.IsNotNull(artiodactyl.HasFur);
            Assert.IsTrue(artiodactyl.NumberOfFingers == 2 || artiodactyl.NumberOfFingers == 4);
        }

        [TestMethod]
        public void ArtiodactylClone()
        {
            Artiodactyl original = new Artiodactyl("TestArtiodactyl", 3, true, 4);

            Artiodactyl clone = (Artiodactyl)original.Clone();

            Assert.AreEqual("КлонTestArtiodactyl", clone.Name);
            Assert.AreEqual(3, clone.Age);
            Assert.AreEqual(true, clone.HasFur);
            Assert.AreEqual(4, clone.NumberOfFingers);
            Assert.AreNotSame(original, clone);
        }

        [TestMethod]
        public void ArtiodactylShallowCopy()
        {
            Artiodactyl original = new Artiodactyl("TestArtiodactyl", 3, false, 2);

            Artiodactyl copy = (Artiodactyl)original.ShallowCopy();

            Assert.AreEqual(original.Name, copy.Name);
            Assert.AreEqual(original.Age, copy.Age);
            Assert.AreEqual(original.HasFur, copy.HasFur);
            Assert.AreEqual(original.NumberOfFingers, copy.NumberOfFingers);
            Assert.AreNotSame(original, copy);
        }
    }
}
