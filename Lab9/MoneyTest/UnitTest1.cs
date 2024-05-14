using Lab9;

namespace MoneyTest
{
    [TestClass]
    public class MoneyTests
    {
        [TestMethod]
        public void MoneyConstructorWithNoParameters()
        {
            Money money = new Money();
            Assert.AreEqual(0, money.Rubles);
            Assert.AreEqual(0, money.Kopeeks);
        }

        [TestMethod]
        public void MoneyConstructorWithRublesParameter()
        {
            Money money = new Money(10);
            Assert.AreEqual(10, money.Rubles);
            Assert.AreEqual(0, money.Kopeeks);
        }

        [TestMethod]
        public void MoneyConstructorWithRublesAndKopeeksParameters()
        {
            Money money = new Money(10, 50);
            Assert.AreEqual(10, money.Rubles);
            Assert.AreEqual(50, money.Kopeeks);
        }

        [TestMethod]
        public void MoneyConstructorWithNegativeRubles()
        {
            Money money = new Money(-10);
            Assert.AreEqual(0, money.Rubles);
            Assert.AreEqual(0, money.Kopeeks);
        }

        [TestMethod]
        public void MoneyConstructorWithNegativeKopeeks()
        {
            Money money = new Money(10, -50);
            Assert.AreEqual(10, money.Rubles);
            Assert.AreEqual(0, money.Kopeeks);
        }

        [TestMethod]
        public void SubstractKopeeksWhenKopeeksIsPositive()
        {
            Money money = new Money(10, 50);
            money.SubstractKopeeks(30);
            Assert.AreEqual(10, money.Rubles);
            Assert.AreEqual(20, money.Kopeeks);
        }

        [TestMethod]
        public void SubstractKopeeksWhenKopeeksIsNegative()
        {
            Money money = new Money(10, 50);
            money.SubstractKopeeks(-30);
            Assert.AreEqual(10, money.Rubles);
            Assert.AreEqual(80, money.Kopeeks);
        }

        [TestMethod]
        public void SubstractKopeeksStaticWhenKopeeksIsPositive()
        {
            Money money = new Money(10, 50);
            Money result = Money.SubstractKopeeks(money, 30);
            Assert.AreEqual(10, result.Rubles);
            Assert.AreEqual(20, result.Kopeeks);
        }

        [TestMethod]
        public void SubstractKopeeksStaticWhenKopeeksIsNegativee()
        {
            Money money = new Money(10, 50);
            Money result = Money.SubstractKopeeks(money, -30);
            Assert.AreEqual(10, result.Rubles);
            Assert.AreEqual(80, result.Kopeeks);
        }

        [TestMethod]
        public void AdditionTest()
        {
            Money money1 = new Money(10, 50);
            Money money2 = new Money(5, 25);
            Money result = money1 + money2;
            Assert.AreEqual(15, result.Rubles);
            Assert.AreEqual(75, result.Kopeeks);
        }

        [TestMethod]
        public void MoneyOperatorAdditionWithInteger()
        {
            Money money = new Money(10, 50);
            Money result = money + 30;

            Assert.AreEqual(10, result.Rubles);
            Assert.AreEqual(80, result.Kopeeks);
        }


        [TestMethod]
        public void SubtractionTest()
        {
            Money money1 = new Money(15, 75);
            Money money2 = new Money(5, 25);
            Money result = money1 - money2;
            Assert.AreEqual(10, result.Rubles);
            Assert.AreEqual(50, result.Kopeeks);
        }

        [TestMethod]
        public void DivisionTest()
        {
            Money money = new Money(10, 50);
            int coefficient = 2;
            Money result = money / coefficient;
            Assert.AreEqual(5, result.Rubles);
            Assert.AreEqual(25, result.Kopeeks);
        }

        [TestMethod]
        public void MoneyOperatorDecrement()
        {
            Money money = new Money(10, 50);
            money--;
            Assert.AreEqual(10, money.Rubles);
            Assert.AreEqual(49, money.Kopeeks);
        }

        [TestMethod]
        public void MoneyOperatorIncrement()
        {
            Money money = new Money(10, 50);
            money++;
            Assert.AreEqual(10, money.Rubles);
            Assert.AreEqual(51, money.Kopeeks);
        }

        [TestMethod]
        public void ImplicitConversionToInt()
        {
            Money money = new Money(100, 50); 
            int result = money; 
            Assert.AreEqual(100, result); 
        }

        [TestMethod]
        public void ExplicitConversionToBool()
        {
            Money money = new Money(0, 50); 
            bool result = (bool)money; 
            Assert.IsTrue(result); 
        }

        [TestMethod]
        public void ExplicitConversionToBool2()
        {
            Money money = new Money(0, 0);
            bool result = (bool)money; 
            Assert.IsFalse(result); 
        }

        [TestMethod]
        public void Adjustment()
        {
            Money money = new Money();
            money.Adjustment(5, 175);
            Assert.AreEqual(6, money.Rubles); 
            Assert.AreEqual(75, money.Kopeeks);
        }

        [TestMethod]
        public void AdjustmentNegativeKopeeks()
        {
            Money money = new Money();
            money.Adjustment(10, -50);
            Assert.AreEqual(9, money.Rubles); 
            Assert.AreEqual(50, money.Kopeeks);
        }

        [TestMethod]
        public void AdjustmentZeroRubles()
        {
            Money money = new Money();
            money.Adjustment(0, 100);

            Assert.AreEqual(1, money.Rubles);
            Assert.AreEqual(0, money.Kopeeks);
        }

    }
}