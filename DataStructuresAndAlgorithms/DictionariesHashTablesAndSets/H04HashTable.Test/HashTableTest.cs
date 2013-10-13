namespace H04HashTable.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HashTableTest
    {
        [TestMethod]
        public void Add_OneItem()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Add("Pesho", 6);

            Assert.IsTrue(hashTable.Count == 1);
        }

        [TestMethod]
        public void Add_ThirdteenItems()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Add("Pessfsho", 6);
            hashTable.Add("Pesdfsho1", 6);
            hashTable.Add("Peqeqwsho2", 6);
            hashTable.Add("Peawsho3", 6);
            hashTable.Add("Pesqddho4", 6);
            hashTable.Add("Pwdesho5", 6);
            hashTable.Add("Pescszho6", 6);
            hashTable.Add("Pesaaho7", 6);
            hashTable.Add("Pezxcsho8", 6);
            hashTable.Add("Pesqwdho9", 6);
            hashTable.Add("Pescscho10", 6);
            hashTable.Add("Pescsaaho11", 6);
            hashTable.Add("Pesadaho12", 6);
            hashTable.Add("Pesadwho13", 6);

            Assert.IsTrue(hashTable.Count == 14);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Add_DuplicatedKeys()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Add("Gosho", 5);
            hashTable.Add("Gosho", 6);
        }

        [TestMethod]
        public void Setter_SetValue()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Add("Gosho", 5);

            hashTable["Gosho"] = 4;

            Assert.AreEqual(4, hashTable["Gosho"]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Setter_SetValueNotExistingKey()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable["Gosho"] = 4;
        }

        [TestMethod]
        public void Clear_ClearTable()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Add("Pesdfsho1", 6);
            hashTable.Add("Peqeqwsho2", 6);
            hashTable.Add("Peawsho3", 6);
            hashTable.Add("Pesqddho4", 6);
            hashTable.Add("Pwdesho5", 6);
            hashTable.Add("Pescszho6", 6);
            hashTable.Add("Pesaaho7", 6);
            hashTable.Add("Pezxcsho8", 6);
            hashTable.Add("Pesqwdho9", 6);
            hashTable.Add("Pescscho10", 6);

            hashTable.Clear();

            Assert.IsTrue(hashTable.Count == 0);
        }

        [TestMethod]
        public void Enimerator_ForEach()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Add("Pesdfsho1", 6);
            hashTable.Add("Peqeqwsho2", 6);
            hashTable.Add("Peawsho3", 6);
            hashTable.Add("Pesqddho4", 6);
            hashTable.Add("Pwdesho5", 6);
            hashTable.Add("Pescszho6", 6);
            hashTable.Add("Pesaaho7", 6);
            hashTable.Add("Pezxcsho8", 6);
            hashTable.Add("Pesqwdho9", 6);
            hashTable.Add("Pescscho10", 6);

            int count = 0;

            foreach (var item in hashTable)
            {
                count++;
            }

            Assert.IsTrue(count == hashTable.Count);
        }

        [TestMethod]
        public void Find_FindItem()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();

            hashTable.Add("Pesdfsho1", 6);
            hashTable.Add("Peqeqwsho2", 6);
            hashTable.Add("Peawsho3", 16);
            hashTable.Add("Pesqddho4", 6);
            hashTable.Add("Pwdesho5", 26);
            hashTable.Add("Pescszho6", 6);
            hashTable.Add("Pesaaho7", 56);
            hashTable.Add("Pezxcsho8", 6);
            hashTable.Add("Pesqwdho9", 16);
            hashTable.Add("Pescscho10", 6);

            var actual = hashTable.Find("Pesaaho7");

            Assert.AreEqual(56, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Find_FindNotExistingItem()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();

            hashTable.Add("Pesdfsho1", 6);
            hashTable.Add("Peqeqwsho2", 6);
            hashTable.Add("Peawsho3", 16);
            hashTable.Add("Pesqddho4", 6);
            hashTable.Add("Pwdesho5", 26);
            hashTable.Add("Pescszho6", 6);
            hashTable.Add("Pesaaho7", 56);
            hashTable.Add("Pezxcsho8", 6);
            hashTable.Add("Pesqwdho9", 16);
            hashTable.Add("Pescscho10", 6);

            hashTable.Find("scdsd");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Remove_RemoveItem()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();

            hashTable.Add("Pesdfsho1", 6);
            hashTable.Add("Peqeqwsho2", 6);
            hashTable.Add("Peawsho3", 16);
            hashTable.Add("Pesqddho4", 6);
            hashTable.Add("Pwdesho5", 26);
            hashTable.Add("Pescszho6", 6);
            hashTable.Add("Pesaaho7", 56);
            hashTable.Add("Pezxcsho8", 6);
            hashTable.Add("Pesqwdho9", 16);
            hashTable.Add("Pescscho10", 6);

            var found = hashTable.Find("Pesdfsho1");
            Assert.IsTrue(found == 6);
            Assert.IsTrue(hashTable.Count == 10);
            hashTable.Remove("Pesdfsho1");
            Assert.IsTrue(hashTable.Count == 9);
            hashTable.Find("Pesdfsho1");
        }

        [TestMethod]
        public void Values_ResturnValues()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            int[] values = { 6, 6, 16, 6, 26, 6, 56, 6, 16, 6 };
            hashTable.Add("Pesdfsho1", values[0]);
            hashTable.Add("Peqeqwsho2", values[1]);
            hashTable.Add("Peawsho3", values[2]);
            hashTable.Add("Pesqddho4", values[3]);
            hashTable.Add("Pwdesho5", values[4]);
            hashTable.Add("Pescszho6", values[5]);
            hashTable.Add("Pesaaho7", values[6]);
            hashTable.Add("Pezxcsho8", values[7]);
            hashTable.Add("Pesqwdho9", values[8]);
            hashTable.Add("Pescscho10", values[9]);

            var actual = hashTable.Values;

            CollectionAssert.AreEquivalent(values, actual);
        }

        [TestMethod]
        public void Keys_ResturnKeys()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            int[] values = { 6, 6, 16, 6, 26, 6, 56, 6, 16, 6 };
            string[] keys =
            {
                "afdvcav",
                "vaev",
                "vavav",
                "DVDgvfd",
                "DEvfv",
                "EDcsvdv",
                "EfcDcd",
                "EDfcdcv",
                "EDfvrvedfv",
                "wadScds",
            };
            hashTable.Add(keys[0], values[0]);
            hashTable.Add(keys[1], values[1]);
            hashTable.Add(keys[2], values[2]);
            hashTable.Add(keys[3], values[3]);
            hashTable.Add(keys[4], values[4]);
            hashTable.Add(keys[5], values[5]);
            hashTable.Add(keys[6], values[6]);
            hashTable.Add(keys[7], values[7]);
            hashTable.Add(keys[8], values[8]);
            hashTable.Add(keys[9], values[9]);

            var actual = hashTable.Keys;

            CollectionAssert.AreEquivalent(keys, actual);
        }
    }
}
