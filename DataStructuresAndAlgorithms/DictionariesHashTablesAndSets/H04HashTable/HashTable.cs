namespace H04HashTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        private const int InitialCapacity = 16;
        private const double PercentMaxFullCapacity = 0.75;
        private LinkedList<KeyValuePair<K, V>>[] dict;
        private int count;

        public HashTable(int capacity = InitialCapacity)
        {
            if (capacity < 16)
            {
                throw new ArgumentException(string.Format("Value for capacity can not be less than '{0}'.", InitialCapacity));
            }

            this.dict = new LinkedList<KeyValuePair<K, V>>[capacity];
            this.count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public int Capacity
        {
            get
            {
                return this.dict.Length;
            }
        }

        public K[] Keys
        {
            get
            {
                K[] keys = new K[this.count];
                int index = 0;
                foreach (var item in this)
                {
                    keys[index++] = item.Key;
                }

                return keys;
            }
        }

        public V[] Values
        {
            get
            {
                V[] values = new V[this.count];
                int index = 0;
                foreach (var item in this)
                {
                    values[index++] = item.Value;
                }

                return values;
            }
        }

        public V this[K index]
        {
            get
            {
                return this.Find(index);
            }

            set
            {
                var itemIndex = index.GetHashCode() % this.dict.Length;

                if (this.dict[itemIndex] == null)
                {
                    throw new IndexOutOfRangeException("The HashTable does not contain key " + index);
                }

                foreach (var item in this.dict[itemIndex])
                {
                    if (item.Key.Equals(index))
                    {
                        this.dict[itemIndex].Remove(item);
                        this.dict[itemIndex].AddLast(new KeyValuePair<K, V>(index, value));
                        return;
                    }
                }
            }
        }

        public void Add(K key, V value)
        {
            if (this.count == (int)(this.dict.Length * PercentMaxFullCapacity))
            {
                this.Resize();
            }

            var itemIndex = Math.Abs(key.GetHashCode() % this.dict.Length);

            if (this.dict[itemIndex] == null)
            {
                this.dict[itemIndex] = new LinkedList<KeyValuePair<K, V>>();
            }

            var newItem = new KeyValuePair<K, V>(key, value);

            foreach (var item in this.dict[itemIndex])
            {
                if (item.Key.Equals(key))
                {
                    throw new InvalidOperationException("Item with key " + key + " already exists int the HashTable.");
                }
            }
            
            this.dict[itemIndex].AddLast(newItem);

            this.count++;
        }

        public void Remove(K key)
        {
            var itemIndex = Math.Abs(key.GetHashCode() % this.dict.Length);

            if (this.dict[itemIndex] == null)
            {
                throw new InvalidOperationException("The HashTable does not contain key " + key);
            }

            bool isItemRemoved = false;
            foreach (var item in this.dict[itemIndex])
            {
                if (item.Key.Equals(key))
                {
                    this.dict[itemIndex].Remove(item);
                    this.count--;
                    return;
                }
            }

            if (!isItemRemoved)
            {
                throw new InvalidOperationException("The HashTable does not contain key " + key);
            }
        }

        public V Find(K key)
        {
            return this.FindPair(key).Value;
        }

        public bool Contains(K key)
        {
            var itemIndex = Math.Abs(key.GetHashCode() % this.dict.Length);

            if (this.dict[itemIndex] == null)
            {
                return false;
            }

            foreach (var item in this.dict[itemIndex])
            {
                if (item.Key.Equals(key))
                {
                    return true;
                }
            }

            return false;
        }

        public KeyValuePair<K, V> FindPair(K key)
        {
            var itemIndex = Math.Abs(key.GetHashCode() % this.dict.Length);

            if (this.dict[itemIndex] == null)
            {
                throw new InvalidOperationException("The HashTable does not contain key " + key);
            }

            foreach (var item in this.dict[itemIndex])
            {
                if (item.Key.Equals(key))
                {
                    return item;
                }
            }

            throw new InvalidOperationException("The HashTable does not contain key " + key);
        }

        private void Resize()
        {
            var newCapacity = this.dict.Length * 2;
            var newDict = new LinkedList<KeyValuePair<K, V>>[newCapacity];

            for (int i = 0; i < this.dict.Length; i++)
            {
            }

            foreach (var list in this.dict)
            {
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        var itemIndex = Math.Abs(item.Key.GetHashCode() % newCapacity);

                        if (newDict[itemIndex] == null)
                        {
                            newDict[itemIndex] = new LinkedList<KeyValuePair<K, V>>();
                        }

                        newDict[itemIndex].AddLast(new KeyValuePair<K, V>(item.Key, item.Value));
                    }
                }
            }

            this.dict = newDict;
        }

        public void Clear()
        {
            this.dict = new LinkedList<KeyValuePair<K, V>>[InitialCapacity];
            this.count = 0;
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (var list in this.dict)
            {
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        yield return item;
                    }
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
