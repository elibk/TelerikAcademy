namespace H05HashedSet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using H04HashTable;

    public class HashedSet<T> : IEnumerable<T>
    {
        private HashTable<T, bool> set;

        public HashedSet(int capacity = 16)
        {
            this.set = new HashTable<T, bool>(capacity);
        }

        public int Count
        {
            get
            {
                return this.set.Count;
            }
        }

        public int Capacity
        {
            get
            {
                return this.set.Capacity;
            }
        }

        public void Add(T value)
        {
            this.set.Add(value, true);
        }

        public void Remove(T value)
        {
            this.set.Remove(value);
        }

        public void Clear()
        {
            this.set.Clear();
        }

        public T Find(T value)
        {
            return this.set.FindPair(value).Key;
        }

        public bool Contains(T key)
        {
            return this.set.Contains(key);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.set)
            {
                yield return item.Key;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Union(HashedSet<T> otherSet)
        {
            foreach (var item in otherSet)
            {
                if (!this.Contains(item))
                {
                    this.Add(item);
                }
            }
        }

        public void Intersect(HashedSet<T> otherSet)
        {
            var newSet = new HashTable<T, bool>(this.Capacity);
            foreach (var item in this)
            {
                if (otherSet.Contains(item))
                {
                    newSet.Add(item, true);
                }
            }

            this.set = newSet;
        }
    }
}
