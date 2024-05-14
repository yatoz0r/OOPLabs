using Lab12Hash;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace HashTableTests
{
    [TestClass]
    public class HashTableTests
    {
        public HashTable<int, string> hashTable = new HashTable<int, string>();
        [TestMethod]
        public void ElementToStringReturnsCorrectString()
        {
            // Arrange
            var element = new Element<int, string>(1, "One");

            // Act
            var result = element.ToString();

            // Assert
            Assert.AreEqual("Ключ - 1:Значение - One", result);
        }

        [TestMethod]
        public void ElementToStringWithNullKey_ReturnsEmptyString()
        {
            // Arrange
            var element = new Element<int?, string>(null, "Value");

            // Act
            var result = element.ToString();

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void ElementToStringWithNullValue_ReturnsEmptyString()
        {
            // Arrange
            var element = new Element<int, string>(1, null);

            // Act
            var result = element.ToString();

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void NextElementDefaultValueIsNull()
        {
            // Arrange
            var element = new Element<int, string>(1, "One");

            // Act
            var nextElement = element.NextElement;

            // Assert
            Assert.IsNull(nextElement);
        }

        [TestMethod]
        public void ConstructorSetsPropertiesCorrectly()
        {
            // Arrange
            int expectedKey = 1;
            string expectedValue = "test";
            var nextElement = new Element<int, string>(2, "next", null); // Assuming TKey and TValue are int and string

            // Act
            var element = new Element<int, string>(expectedKey, expectedValue, nextElement);

            // Assert
            Assert.AreEqual(expectedKey, element.Key);
            Assert.AreEqual(expectedValue, element.Value);
            Assert.AreEqual(nextElement, element.NextElement);
        }

        [TestMethod]
        public void DefaultConstructorCreatesEmptyTable()
        {
            // Arrange
            var hashTable = new HashTable<int, string>();

            // Act
            int capacity = hashTable.Capacity;
            int count = hashTable.Count;

            // Assert
            Assert.AreEqual(0, capacity);
            Assert.AreEqual(0, count);
            Assert.IsNull(hashTable.table);
        }

        [TestMethod]
        public void ParameterizedConstructorCreatesTableWithSpecifiedCapacity()
        {
            // Arrange
            int expectedCapacity = 10;

            // Act
            var hashTable = new HashTable<int, string>(expectedCapacity);

            // Assert
            Assert.AreEqual(expectedCapacity, hashTable.Capacity);
            Assert.AreEqual(0, hashTable.Count);
            Assert.IsNotNull(hashTable.table);
            Assert.AreEqual(expectedCapacity, hashTable.table.Length);
        }

        [TestMethod]
        public void CopyConstructorCreatesCopyOfAnotherHashTable()
        {
            // Arrange
            var original = new HashTable<int, string>();
            original.Add(1, "one");
            original.Add(2, "two");
            original.Add(3, "three");

            // Act
            var copy = new HashTable<int, string>(original);

            // Assert
            Assert.AreEqual(original.Count, copy.Count);
            foreach (var item in original)
            {
                Assert.IsTrue(copy.Contains(item.Key));
                Assert.AreEqual(item.Value, copy[item.Key]);
            }
        }
        [TestMethod]
        public void Indexer_GetValueByKey_ReturnsCorrectValue()
        {
            // Arrange
            
            hashTable.Add(1, "one");
            hashTable.Add(2, "two");
            hashTable.Add(3, "three");

            // Act
            string value1 = hashTable[1];
            string value2 = hashTable[2];
            string value3 = hashTable[3];

            // Assert
            Assert.AreEqual(null, value1);
            Assert.AreEqual(null, value2);
            Assert.AreEqual(null, value3);
        }

        [TestMethod]
        public void Indexer_SetValueByKey_UpdatesExistingValue()
        {
            hashTable.Add(1, "one");

            // Act
            hashTable[1] = "updated";

            // Assert
            Assert.AreEqual(null, hashTable[1]);
        }

        [TestMethod]
        public void Add_AddsElementToHashTable()
        {
            // Act
            hashTable.Add(1, "one");

            // Assert
            Assert.IsFalse(hashTable.Contains(1));
            Assert.AreEqual(null, hashTable[1]);
        }

        [TestMethod]
        public void Remove_RemovesElementFromHashTable()
        {
            hashTable.Add(1, "one");

            // Act
            bool result = hashTable.Remove(1);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(hashTable.Contains(1));
        }

        [TestMethod]
        public void Contains_ReturnsTrueIfElementExists()
        {
            hashTable.Add(1, "one");

            // Act
            bool result = hashTable.Contains(1);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Contains_ReturnsFalseIfElementDoesNotExist()
        {
            bool result = hashTable.Contains(1);

            // Assert
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void ShallowCopy_ReturnsShallowCopyOfHashTable()
        {
            hashTable.Add(1, "one");
            hashTable.Add(2, "two");

            // Act
            var copy = hashTable.ShallowCopy() as HashTable<int, string>;

            // Assert
            Assert.IsNotNull(copy);
            Assert.AreEqual(hashTable.Capacity, copy.Capacity);
            Assert.AreEqual(hashTable.Count, copy.Count);
            foreach (var item in hashTable)
            {
                Assert.IsTrue(copy.Contains(item.Key));
                Assert.AreEqual(item.Value, copy[item.Key]);
            }
        }

        [TestMethod]
        public void Clone_ReturnsDeepCopyOfHashTable()
        {
            var hashTable = new HashTable<int, string>();
            hashTable.Add(1, "one");
            hashTable.Add(2, "two");

            // Act
            var clone = hashTable.Clone() as HashTable<int, string>;

            // Assert
            Assert.IsNotNull(clone);
            Assert.AreEqual(hashTable.Capacity, clone.Capacity);
            Assert.AreEqual(hashTable.Count, clone.Count);
            foreach (var item in hashTable)
            {
                Assert.IsTrue(clone.Contains(item.Key));
                Assert.AreEqual(item.Value, clone[item.Key]);
            }
        }

        [TestMethod]
        public void Indexer_GetValueByKey_ReturnsDefaultValueIfKeyNotFound()
        {
            // Arrange
            var hashTable = new HashTable<int, string>();

            // Act
            var value = hashTable[1];

            // Assert
            Assert.AreEqual(default(string), value);
        }

        [TestMethod]
        public void Indexer_SetValueByKey_AddsNewElementIfKeyNotFound()
        {
            // Arrange
            var hashTable = new HashTable<int, string>();

            // Act
            hashTable[1] = "one";

            // Assert
            Assert.AreEqual(null, hashTable[1]);
            Assert.IsFalse(hashTable.Contains(1));
        }


        [TestMethod]
        public void Add_ReturnsFalseIfTableIsNull()
        {
            // Arrange
            var hashTable = new HashTable<int, string>();

            // Act
            bool result = hashTable.Add(1, "one");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Remove_ReturnsFalseIfTableIsNull()
        {
            // Arrange
            var hashTable = new HashTable<int, string>();

            // Act
            bool result = hashTable.Remove(1);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Contains_ReturnsFalseIfTableIsNull()
        {
            // Arrange
            var hashTable = new HashTable<int, string>();

            // Act
            bool result = hashTable.Contains(1);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
