namespace H03BiDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class BiDictionary<K1, K2, T>
    {
        private MultiDictionary<K1, T> dict;
        private MultiDictionary<K2, T> otherDict;
        private MultiDictionary<Tuple<K1, K2>, T> duoDict;

        public BiDictionary()
        {
            this.dict = new MultiDictionary<K1, T>(true);
            this.otherDict = new MultiDictionary<K2, T>(true);
            this.duoDict = new MultiDictionary<Tuple<K1, K2>, T>(true);
        }

        public void Add(K1 firstKey, K2 secondKey, T value) 
        {
            this.dict.Add(firstKey, value);
            this.otherDict.Add(secondKey, value);
            this.duoDict.Add(new Tuple<K1, K2>(firstKey, secondKey), value);
        }

        public ICollection<T> FindByFirsKey(K1 key)
        {
            return this.dict[key];
        }

        public ICollection<T> FindBySecondKey(K2 key)
        {
            return this.otherDict[key];
        }

        public ICollection<T> FindByBothKeys(K1 firstKey, K2 secondKey)
        {
            return this.duoDict[new Tuple<K1, K2>(firstKey, secondKey)];
        }
    }
}
