namespace H05HashedSet.Test
{
    using System;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HashedSetTest
    {
        [TestMethod]
        public void Union_Test()
        {
            HashedSet<int> set = new HashedSet<int>();
            HashedSet<int> otherSet = new HashedSet<int>();

            set.Add(1);
            set.Add(2);
            set.Add(3);

            otherSet.Add(3);
            otherSet.Add(4);
            otherSet.Add(5);

            set.Union(otherSet);

            StringBuilder actual = new StringBuilder();
            foreach (var item in set)
            {
                actual.Append(item + " ");
            }

            string expected = "1 2 3 4 5 ";

            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        public void Intersect_Test()
        {
            HashedSet<int> set = new HashedSet<int>();
            HashedSet<int> otherSet = new HashedSet<int>();

            set.Add(1);
            set.Add(2);
            set.Add(3);

            otherSet.Add(3);
            otherSet.Add(4);
            otherSet.Add(5);

            set.Intersect(otherSet);

            StringBuilder actual = new StringBuilder();
            foreach (var item in set)
            {
                actual.Append(item + " ");
            }

            string expected = "3 ";

            Assert.AreEqual(expected, actual.ToString());
        }
    }
}
