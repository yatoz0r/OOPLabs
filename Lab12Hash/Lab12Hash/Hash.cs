using Lab10ClassLib;
using System.Collections;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace Lab12Hash
{
    [Serializable]
    public class Element<TKey, TValue>
    {
        public TKey? Key { get; set; }
        public TValue? Value { get; set; }
        public Element<TKey, TValue>? NextElement { get; set; }
        public Element()
        {
            NextElement = null;
        }
        public Element(TKey? key, TValue? value, Element<TKey, TValue> next)
        {
            Key = key;
            Value = value;
            NextElement = next;
        }
        public Element(TKey? key, TValue? value)
        {
            Key = key;
            Value = value;
        }
        public override string ToString()
        {
            if (Key == null || Value == null)
                return string.Empty;
            return "Ключ - " + Key.ToString() + "|| " + "Значение - " + Value.ToString();
        }
    }
    [Serializable]
    public class HashTable<TKey, TValue> : ICollection<Element<TKey, TValue>>, IEnumerable<Element<TKey, TValue>>, ICloneable
    {
        public Element<TKey, TValue>[]? table;
        public int Capacity { get; }

        public bool isEmpty { get; private set; }

        public HashTable()
        {
            /*Должна быть пустая емкость и таблица null
             * но нужны костыли для работы сериализации и записи в различные форматы файлов в 16 лабе
             */
            Capacity = 10000;
            table = new Element<TKey, TValue>[Capacity];    
            isEmpty = true;
        }

        public HashTable(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("Некорректный размер");
            }
            Capacity = capacity;
            table = new Element<TKey, TValue>[capacity];
            isEmpty = true;
        }

        public HashTable(HashTable<TKey, TValue> otherCollection)
        {
            Capacity = otherCollection.Capacity;
            Count = otherCollection.Count;
            table = new Element<TKey, TValue>[Capacity];
            foreach (var item in otherCollection)
            {
                Add(item.Key, item.Value);
            }
            isEmpty = false;
        }

        #region ICollection implementation
        public int Count { get; private set; }
        public bool IsReadOnly => false;

        public virtual void Add(Element<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }
        public bool Contains(Element<TKey, TValue> item)
        {
            if (table == null || Capacity == 0 || item.Key == null)
            {
                throw new Exception("Пустая таблица или ключ");
            }
            int index = GetIndex(item.Key);
            if (table[index] == null)
                throw new Exception("Элемент с таким ключом не найден");
            var element = table[index];

            while (element != null)
            {
                if (element.Key.Equals(item.Key))
                    return true;
                element = element.NextElement;
            }
            throw new Exception("Элемент с таким ключом не найден");
        }

        public virtual bool Remove(Element<TKey, TValue> item)
        {
            if (item.Key == null || item.Value == null)
                throw new Exception("Пустой ключ/значение");
            Remove(item.Key);
            return true;
        }
        public void CopyTo(Element<TKey, TValue>[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            if (array.Length - arrayIndex < Count)
                throw new ArgumentException("Недостаточно места для копирования");

            foreach (var element in this)
                array[arrayIndex++] = element;
        }
        public void Clear()
        {
            table = null;
            Count = 0;
        }
        public IEnumerator<Element<TKey, TValue>> GetEnumerator()
        {
            if (table != null)
            {
                for (int i = 0; i < Capacity; ++i)
                {
                    Element<TKey, TValue>? current = table[i];
                    while (current != null && current.Key != null &&
                           current.Value != null)
                    {
                        yield return current;
                        current = current.NextElement;
                    }
                }
            }
        }
        // Древняя бесполезность 
        IEnumerator IEnumerable.GetEnumerator() 
        {
            return GetEnumerator();
        }
        #endregion
        public virtual Element<TKey, TValue> this[TKey key]
        {
            get
            {
                if (table == null || key == null)
                {
                    throw new ArgumentNullException("Key cannot be null");
                }

                int index = GetIndex(key);
                var currentElement = table[index];
                while (currentElement != null)
                {
                    if (currentElement.Key.Equals(key))
                    {
                        return currentElement;
                    }
                    currentElement = currentElement.NextElement;
                }

                return null;
            }
            set
            {
                if (table == null || key == null)
                {
                    throw new ArgumentNullException("Key cannot be null");
                }

                int index = GetIndex(key);
                var currentElement = table[index];
                var previousElement = table[index];

                while (currentElement != null)
                {
                    if (currentElement.Key.Equals(key))
                    {
                        currentElement.Value = value.Value;
                        return;
                    }
                    previousElement = currentElement;
                    currentElement = currentElement.NextElement;
                }

                if (value != null)
                {
                    if (table[index] == null)
                    {
                        table[index] = value;
                    }
                    else
                    {
                        previousElement.NextElement = value;
                    }
                    Count++;
                    isEmpty = false;
                }
            }
        }
        public int GetIndex(TKey key)
        {
            int index = Math.Abs(key.GetHashCode()) % Capacity;
            return index;
        }

        public virtual bool Add(TKey key, TValue value)
        {
            if (key == null || value == null)
            {
                Console.WriteLine("Пустой ключ или значение");
                return false;
            }
            if(Contains(key))
            {
                Console.WriteLine("Ключ уже существует");
                return false;
            }    
            int index = GetIndex(key);
            var newElement = new Element<TKey, TValue>(key, value);

            if (table[index] == null)
            {
                table[index] = newElement;
                Count++;
                return true;
            }
            var current = table[index];

            while (current.NextElement != null)
            {
                if (current.Key.Equals(key))
                {
                    Console.WriteLine("Данный ключ уже существует, вставка не возможна.");
                    return false;
                }

                current = current.NextElement;
            }
            current.NextElement = newElement;
            Count++;
            isEmpty = false;

            return true;
        }
    
        public virtual bool Remove(TKey key)
        {
            if (table == null || key == null)
            {
                Console.WriteLine("Пустая таблица или ключ");
                return false;
            }
            int index = GetIndex(key);
            var element = table[index];
            Element<TKey, TValue> previousElement = null;

            while (element != null)
            {
                if (element.Key.Equals(key))
                {
                    if (previousElement != null)
                        previousElement.NextElement = element.NextElement;
                    else
                        table[index] = element.NextElement;
                    Count--;
                    return true;
                }
                previousElement = element;
                element = element.NextElement;
            }
            Console.WriteLine("Элемент не найден");
            return false;

        }

        public virtual void Remove(IEnumerable<TKey> keys)
        {
            if (keys == null)
            {
                throw new ArgumentNullException(nameof(keys));
            }

            foreach (var key in keys)
            {
                Remove(key);
            }
        }

        public bool Contains(TKey key)
        {
            if (table == null || Capacity == 0 || key == null)
            {
                Console.WriteLine("Пустая таблица или ключ");
                return false;
            }
            int index = GetIndex(key);
            if (table[index] == null)
            {
                return false;
            }
            var element = table[index];

            while (element != null)
            {
                if (element.Key.Equals(key))
                    return true;
                element = element.NextElement;
            }
            return false;
        }
        public void Print()
        {
            if (table == null || Capacity == 0)
            {
                Console.WriteLine("Таблица пуста");
                return;
            }

            for (int i = 0; i < Capacity; i++)
            {


                if (table[i] == null)
                {
                    Console.WriteLine($"{i}: NULL");
                    continue;
                }
                var element = table[i];
                while (element != null)
                {
                    Console.WriteLine($"{i}--{element}");
                    element = element.NextElement;
                }
            }
        }
        
        public object ShallowCopy()
        {
            return (object)this.MemberwiseClone();
        }
        public object Clone()
        {
            return (object)new HashTable<TKey, TValue>(this);
        }

    }
}

