using Lab12Hash;

namespace TestHash
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestElementCreationWithoutNext()
        {
            var element = new Element<int, string>(1, "value");
            Assert.AreEqual(1, element.Key);
            Assert.AreEqual("value", element.Value);
            Assert.IsNull(element.NextElement);
        }

        [TestMethod]
        public void TestElementCreationWithNext()
        {
            var next = new Element<int, string>(2, "next");
            var element = new Element<int, string>(1, "value", next);
            Assert.AreEqual(1, element.Key);
            Assert.AreEqual("value", element.Value);
            Assert.AreEqual(next, element.NextElement);
        }

        [TestMethod]
        public void TestElementToString()
        {
            var element = new Element<int, string>(1, "value");
            Assert.AreEqual("Ключ - 1:Значение - value", element.ToString());
        }
        
        [TestMethod]
        public void TestElementToString2()
        {
            var element = new Element<int, string>(0,null); ;
            Assert.AreEqual(string.Empty, element.ToString());
        }

        [TestMethod]
        public void TestElementCreationWithNullValues()
        {
            var element = new Element<int?, string>(null, null);
            Assert.IsNull(element.Key);
            Assert.IsNull(element.Value);
            Assert.IsNull(element.NextElement);
        }

        [TestMethod]
        public void TestElementCreationWithNullKey()
        {
            var element = new Element<int?, string>(null, "value");
            Assert.IsNull(element.Key);
            Assert.AreEqual("value", element.Value);
            Assert.IsNull(element.NextElement);
        }

        [TestMethod]
        public void TestElementCreationWithNullValue()
        {
            var element = new Element<int, string?>(1, null);
            Assert.AreEqual(1, element.Key);
            Assert.IsNull(element.Value);
            Assert.IsNull(element.NextElement);
        }

        [TestMethod]
        public void TestEmptyHashTableCreation()
        {
            var hashTable = new HashTable<int, string>();
            Assert.AreEqual(0, hashTable.Capacity);
            Assert.IsNull(hashTable.table);
        }

        [TestMethod]
        public void TestHashTableCreationWithCapacity()
        {
            var hashTable = new HashTable<int, string>(10);
            Assert.AreEqual(10, hashTable.Capacity);
            Assert.IsNotNull(hashTable.table);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestHashTableCreationWithNegativeCapacity()
        {
            var hashTable = new HashTable<int, string>(-1);
        }

        [TestMethod]
        public void TestHashTableCreationFromOtherHashTable()
        {
            var otherHashTable = new HashTable<int, string>(10);
            otherHashTable.Add(1, "value1");
            otherHashTable.Add(2, "value2");
            var hashTable = new HashTable<int, string>(otherHashTable);
            Assert.AreEqual(10, hashTable.Capacity);
            Assert.AreEqual(4, hashTable.Count);
            Assert.AreEqual("value1", hashTable[1].Value);
            Assert.AreEqual("value2", hashTable[2].Value);
        }

        [TestMethod]
        public void TestAddElementToEmptyHashTable()
        {
            var hashTable = new HashTable<int, string>(10);
            hashTable.Add(1, "value");
            Assert.AreEqual(1, hashTable.Count);
            Assert.AreEqual("value", hashTable[1].Value);
        }

        [TestMethod]
        public void TestAddElementToHashTableWithCollision()
        {
            var hashTable = new HashTable<int, string>(2);
            hashTable.Add(1, "value1");
            hashTable.Add(3, "value3");
            hashTable.Add(5, "value5");
            Assert.AreEqual(3, hashTable.Count);
            Assert.AreEqual("value1", hashTable[1].Value);
            Assert.AreEqual("value3", hashTable[3].Value);
            Assert.AreEqual("value5", hashTable[5].Value);
        }

        [TestMethod]
        public void TestAddElementWithExistingKey()
        {
            var hashTable = new HashTable<int, string>(10);
            hashTable.Add(1, "value1");
            hashTable.Add(1, "value2");
            Assert.AreEqual(1, hashTable.Count);
            Assert.AreEqual("value1", hashTable[1].Value);
        }

        [TestMethod]
        public void TestRemoveElementFromHashTable()
        {
            var hashTable = new HashTable<int, string>(10);
            hashTable.Add(1, "value1");
            hashTable.Add(2, "value2");
            hashTable.Remove(1);
            Assert.AreEqual(1, hashTable.Count);
            Assert.IsNull(hashTable[1]);
            Assert.AreEqual("value2", hashTable[2].Value);
        }

        [TestMethod]
        public void TestFindElementInHashTable()
        {
            var hashTable = new HashTable<int, string>(10);
            hashTable.Add(1, "value1");
            hashTable.Add(2, "value2");
            Assert.AreEqual("value1", hashTable[1].Value);
            Assert.AreEqual("value2", hashTable[2].Value);
            Assert.IsNull(hashTable[3]);
        }

        [TestMethod]
        public void TestAddElement()
        {
            var hashTable = new HashTable<int, string>(10);
            hashTable.Add(new Element<int, string>(1, "value"));
            Assert.AreEqual(1, hashTable.Count);
            Assert.AreEqual("value", hashTable[1].Value);
        }

        [TestMethod]
        public void TestContainsElement()
        {
            var hashTable = new HashTable<int, string>(10);
            hashTable.Add(new Element<int, string>(1, "value"));
            var item = new Element<int, string>(1, "value");
            Assert.IsTrue(hashTable.Contains(item));
        }

        [TestMethod]
        public void TestRemoveElement()
        {
            var hashTable = new HashTable<int, string>(10);
            hashTable.Add(new Element<int, string>(1, "value"));
            var item = new Element<int, string>(1, "value");
            hashTable.Remove(item);
            Assert.AreEqual(0, hashTable.Count);
            Assert.IsNull(hashTable[1]);
        }
        [TestMethod]
        public void TestRemoveElement1()
        {
            var hashTable = new HashTable<int, string>();
            var item = new Element<int, string>(1, "value");
            hashTable.Remove(item);
            Assert.IsTrue(hashTable.Remove(item));
        }
        

        [TestMethod]
        public void TestCopyTo()
        {
            var hashTable = new HashTable<int, string>(10);
            hashTable.Add(new Element<int, string>(1, "value1"));
            hashTable.Add(new Element<int, string>(2, "value2"));
            var array = new Element<int, string>[hashTable.Count];
            hashTable.CopyTo(array, 0);
            Assert.AreEqual("value1", array[0].Value);
            Assert.AreEqual("value2", array[1].Value);
        }

        [TestMethod]
        public void TestClear()
        {
            var hashTable = new HashTable<int, string>(10);
            hashTable.Add(new Element<int, string>(1, "value"));
            hashTable.Clear();
            Assert.AreEqual(0, hashTable.Count);
            Assert.IsNull(hashTable[1]);
        }

        [TestMethod]
        public void TestContainsElementNotFound()
        {
            var hashTable = new HashTable<int, string>(10);
            hashTable.Add(new Element<int, string>(1, "value"));
            var item = new Element<int, string>(2, "value");
            Assert.ThrowsException<Exception>(() => hashTable.Contains(item));
        }

        [TestMethod]
        public void TestPrintEmptyHashTable()
        {
            var hashTable = new HashTable<int, string>(10);
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                hashTable.Print();
                var output = writer.ToString().Trim();
                Assert.AreEqual("", output);
            }
        }

        [TestMethod]
        public void TestPrintHashTable()
        {
            var hashTable = new HashTable<int, string>(10);
            hashTable.Add(new Element<int, string>(1, "value1"));
            hashTable.Add(new Element<int, string>(2, "value2"));
            hashTable.Add(new Element<int, string>(3, "value3"));
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                hashTable.Print();
                var output = writer.ToString().Trim();
                Assert.AreEqual("Ключ - 1:Значение - value1\r\nКлюч - 2:Значение - value2\r\nКлюч - 3:Значение - value3", output);
            }
        }

        [TestMethod]
        public void TestShallowCopyHashTable()
        {
            var hashTable = new HashTable<int, string>(10);
            hashTable.Add(new Element<int, string>(1, "value1"));
            hashTable.Add(new Element<int, string>(2, "value2"));
            var copy = (HashTable<int, string>)hashTable.ShallowCopy();
            Assert.AreEqual(hashTable.Capacity, copy.Capacity);
            Assert.AreEqual(hashTable.Count, copy.Count);
            Assert.AreEqual("value1", copy[1].Value);
            Assert.AreEqual("value2", copy[2].Value);
            Assert.AreSame(hashTable.table, copy.table);
        }

        [TestMethod]
        public void TestCloneHashTable()
        {
            var hashTable1 = new HashTable<int, string>(10);
            hashTable1.Add(new Element<int, string>(1, "value1"));
            hashTable1.Add(new Element<int, string>(2, "value2"));
            var clone = (HashTable<int, string>)hashTable1.Clone();
            Assert.AreEqual(hashTable1.Capacity, clone.Capacity);
            Assert.AreEqual(hashTable1.Count + 2, clone.Count);
            Assert.AreEqual("value1", clone[1].Value);
            Assert.AreEqual("value2", clone[2].Value);
            Assert.AreNotSame(hashTable1.table, clone.table);
        }

        [TestMethod]
        public void TestGetIndex()
        {
            var hashTable = new HashTable<int, string>();
            int index = hashTable.GetIndex(1);
            Assert.AreEqual(-1, index);
        }

        [TestMethod]
        public void TestAddCollection()
        {
            var hashTable = new HashTable<int, string>(10);
            var collection = new List<string> { "value1", "value2", "value3" };
            hashTable.Add(collection);
            Assert.AreEqual(3, hashTable.Count);
        }

    }
}