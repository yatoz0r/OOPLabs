using Lab6;

namespace Lab6Tests
{
    [TestClass]
    public class TasksTests
    {
        [TestMethod]
        public void CheckIntValidInput()
        {
            string input = "42";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            Tasks obj = new Tasks();
            int result = obj.CheckInt("");

            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void CheckIntInvalidInputThenValidInput()
        {

            string invalidInput = "string";
            string validInput = "42";
            StringReader stringReader = new StringReader($"{invalidInput}\n{validInput}");
            Console.SetIn(stringReader);

            Tasks obj = new Tasks();
            int result = obj.CheckInt("");

            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void CheckIntMultipleInvalidInputsThenValidInput()
        {
            string invalidInput1 = "string";
            string invalidInput2 = "43,5";
            string validInput = "42";
            StringReader stringReader = new StringReader($"{invalidInput1}\n{invalidInput2}\n{validInput}");
            Console.SetIn(stringReader);

            Tasks obj = new Tasks();
            int result = obj.CheckInt("");

            Assert.AreEqual(42, result);
        }
        
        [TestMethod]
        public void CheckCharReturnCorrectChar()
        {

            string input = "A";
            string expectedOutput = "A";

            using (StringReader sr = new StringReader(input))
            {
                Console.SetIn(sr);
                Tasks obj = new Tasks();
                char result = obj.CheckChar("");

                Assert.AreEqual(expectedOutput[0], result);
            }
        }

        [TestMethod]
        public void CheckCharRetryUntilSingleCharacterIsEntered()
        {

            string input = "AB\nC";
            string expectedOutput = "C";

            using (StringReader sr = new StringReader(input))
            {
                Console.SetIn(sr);
                Tasks obj = new Tasks();
                char result = obj.CheckChar("");

                Assert.AreEqual(expectedOutput[0], result);
            }
        }

        [TestMethod]
        public void CheckStringReturnCorrectString()
        {
            string input = "Hello";
            string expectedOutput = "Hello";

            using (StringReader sr = new StringReader(input))
            {
                Console.SetIn(sr);
                Tasks obj = new Tasks();
                string result = obj.CheckString("");

                Assert.AreEqual(expectedOutput, result);
            }
        }

        [TestMethod]
        public void CheckStringRetryUntilNonEmptyStringIsEntered()
        {
            string input = "\n \t   \nABC";
            string expectedOutput = "ABC";

            using (StringReader sr = new StringReader(input))
            {
                Console.SetIn(sr);
                Tasks obj = new Tasks();
                string result = obj.CheckString("");

                Assert.AreEqual(expectedOutput, result);
            }
        }

        [TestMethod]
        public void MakeArrayWhenGivenSizeReturnArrayWithCorrectSize()
        {
            int size = 5;
            Tasks obj = new Tasks();

            using (StringReader sr = new StringReader("A\nB\nC\nD\nE\n"))
            {
                Console.SetIn(sr);
                char[] result = obj.MakeArray(size);

                Assert.AreEqual(5, result.Length);
            }
        }

        [TestMethod]
        public void MakeArrayWhenZeroSizeReturnEmptyArray()
        {
            int size = 0;
            Tasks obj = new Tasks();

            char[] result = obj.MakeArray(size);

            Assert.AreEqual(0, result.Length);
        }

        [TestMethod]
        public void MakeArrayWhenGivenNegativeSizeThrowOverflowException()
        {
            int size = -3;
            Tasks obj = new Tasks();

            Assert.ThrowsException<OverflowException>(() => obj.MakeArray(size));
        }

        [TestMethod]
        public void MakeRandomArrayReturnArrayWithCorrectSize()
        {
            int size = 5;
            Tasks obj = new Tasks();

            char[] result = obj.MakeRandomArray(size);

            Assert.AreEqual(size, result.Length);
        }

        [TestMethod]
        public void MakeRandomArrayReturnArrayWithValidSymbols()
        {
            int size = 10;
            Tasks obj = new Tasks();
            string validSymbols = "abcdefghijklmnoprstuvwxyzABCDEFGHIJKLMNOPRSTUVWXYZ0123456789";

            char[] result = obj.MakeRandomArray(size);

            Assert.IsTrue(result.All(c => validSymbols.Contains(c.ToString())));
        }

        [TestMethod]
        public void MakeRandomArrayZeroSizeReturnEmptyArray()
        {
            int size = 0;
            Tasks obj = new Tasks();

            char[] result = obj.MakeRandomArray(size);

            Assert.AreEqual(0, result.Length);
        }

        [TestMethod]
        public void DeleteDigitalsReturnArrayWithoutDigitals()
        {
            char[] inputArray = { 'a', '1', 'b', '2', 'c', '3' };
            Tasks obj = new Tasks();

            char[] resultArray = obj.DeleteDigitals(inputArray);

            CollectionAssert.AreEqual(new char[] { 'a', 'b', 'c' }, resultArray);
        }

        [TestMethod]
        public void DeleteDigitalsWhenGivenArrayWithoutDigitalsReturnSameArray()
        {
            char[] inputArray = { 'a', 'b', 'c' };
            Tasks obj = new Tasks();

            char[] resultArray = obj.DeleteDigitals(inputArray);

            CollectionAssert.AreEqual(inputArray, resultArray);
        }

        [TestMethod]
        public void DeleteDigitalsWhenGivenEmptyArrayReturnEmptyArray()
        {
            char[] inputArray = { };
            Tasks obj = new Tasks();

            char[] resultArray = obj.DeleteDigitals(inputArray);

            CollectionAssert.AreEqual(inputArray, resultArray);
        }

        [TestMethod]
        public void ReverseWordsPrintReversedAndSortedWords()
        {
            string inputSentence = "Hello world! How are you today?";
            string expectedOutput = "world Hello!you today How are?";
            Tasks obj = new Tasks();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                obj.ReverseWords(inputSentence);

                Assert.AreEqual(expectedOutput, sw.ToString().Trim());
            }
        }

        [TestMethod]
        public void ReverseWordsWhenGivenEmptySentenceNotPrintAnything()
        {
            string inputSentence = "";
            string expectedOutput = "";
            Tasks obj = new Tasks();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);;
                obj.ReverseWords(inputSentence);
                Assert.AreEqual(expectedOutput, sw.ToString().Trim());
            }
        }

        [TestMethod]
        public void ReverseWordsWhenGivenNullSentenceNotPrintAnything()
        {
            string inputSentence = "";
            string expectedOutput = "";
            Tasks obj = new Tasks();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                obj.ReverseWords(inputSentence);
                Assert.AreEqual(expectedOutput, sw.ToString().Trim());
            }
        }
    }
}
