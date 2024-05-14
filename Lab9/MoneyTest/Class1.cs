using Lab9;

namespace MoneyTest
{
    [TestClass]
    public class MoneyArrayTests
    {
        [TestMethod]
        public void MoneyArrayDefaultConstructorEmptyArray()
        {
            MoneyArray moneyArray = new MoneyArray();

            Assert.AreEqual(0, moneyArray.Size);
        }

        [TestMethod]
        public void MoneyArrayParameterizedConstructor()
        {
            int expectedSize = 5;

            MoneyArray moneyArray = new MoneyArray(expectedSize);

            Assert.AreEqual(expectedSize, moneyArray.Size);
        }

        [TestMethod]
        public void MoneyArrayNegativeSizeInConstructor()
        {
            int negativeSize = -5;

            MoneyArray moneyArray = new MoneyArray(negativeSize);

            Assert.AreEqual(0, moneyArray.Size);
        }

        [TestMethod]
        public void MoneyArrayConstructorWithSize()
        {
            int size = 3;

            MoneyArray moneyArray = new MoneyArray(size);

            Assert.AreEqual(size, moneyArray.Size);
        }

        [TestMethod]
        public void MoneyArrayConstructorWithParams()
        {
            Money money1 = new Money(10);
            Money money2 = new Money(20);
            Money money3 = new Money(30);

            MoneyArray moneyArray = new MoneyArray(money1, money2, money3);

            Assert.AreEqual(3, moneyArray.Size);
            Assert.AreEqual(money1, moneyArray[0]);
            Assert.AreEqual(money2, moneyArray[1]);
            Assert.AreEqual(money3, moneyArray[2]);
        }

        [TestMethod]
        public void DisplayArrEmptyArray()
        {
            MoneyArray moneyArray = new MoneyArray();

            string output = CaptureConsoleOutput(() => moneyArray.DisplayArr());

            Assert.AreEqual("Массив пуст.", output.Trim());
        }

        [TestMethod]
        public void DisplayArrNonEmptyArray()
        {
            Money money1 = new Money(10);
            Money money2 = new Money(20);
            MoneyArray moneyArray = new MoneyArray(money1, money2);

            string output = CaptureConsoleOutput(() => moneyArray.DisplayArr());

            Assert.AreEqual("Сумма: 10 руб. 0 коп.\r\nСумма: 20 руб. 0 коп.", output.Trim());
        }

        [TestMethod]
        public void GetSetIndexValidIndex()
        {
            Money money1 = new Money(10);
            Money money2 = new Money(20);
            MoneyArray moneyArray = new MoneyArray(money1, money2);

            Money retrievedMoney = moneyArray[1];
            moneyArray[0] = new Money(30);
            Money checkArr2 = moneyArray[0];

            Assert.AreEqual(money2, retrievedMoney);
            Assert.AreEqual(checkArr2, moneyArray[0]);
        }

        [TestMethod]
        public void GetSetIndexInvalidIndex()
        {
            MoneyArray moneyArray = new MoneyArray();
            Assert.ThrowsException<IndexOutOfRangeException>(() => moneyArray[-1]);
            Assert.ThrowsException<IndexOutOfRangeException>(() => moneyArray[0] = new Money());
        }

        [TestMethod]
        public void AverageMoneyNullArray()
        {
            MoneyArray moneyArray = null;
            Money? averageMoney = MoneyArray.AverageMoney(moneyArray);
            Assert.IsNull(averageMoney);
        }

        [TestMethod]
        public void AverageMoneyMoneyArrayIsEmpty()
        {
            MoneyArray arr = new MoneyArray();
            Money? result = MoneyArray.AverageMoney(arr);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void AverageMoneyReturnCorrectAverage()
        {
            MoneyArray arr = new MoneyArray(new Money(10, 50),
                new Money(5, 25));
            Money? result = MoneyArray.AverageMoney(arr);

            Assert.IsNotNull(result);
            Assert.AreEqual(7, result.Rubles);
            Assert.AreEqual(87, result.Kopeeks); 
        }

        //Метод для перехвата консольного вывода
        private string CaptureConsoleOutput(Action action)
        {
            using (var consoleOutput = new StringWriter())
            {
                Console.SetOut(consoleOutput);
                action.Invoke();
                return consoleOutput.ToString().Trim();
            }
        }

    }
}
