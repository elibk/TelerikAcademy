using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DynamicListImplementation.Test
{
    [TestClass]
    public class DynamicListTest
    {
        [TestMethod]
        public void Add_AddOneNumber()
        {
            DynamicList<int> list = new DynamicList<int>();
            list.Add(6);

            Assert.IsTrue(list.Count == 1);
        }

        [TestMethod]
        public void Add_AddFiveNumbers()
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 0; i < 5; i++)
            {
                list.Add(6);
            }
           
            Assert.IsTrue(list.Count == 5);
        }

        [TestMethod]
        public void RemoveByIndex_RemoveNumberInTheMiddle()
        {
            DynamicList<int> list = new DynamicList<int>();

            list.Add(0);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            int actual = list.RemoveByIndex(3);
            Assert.AreEqual(3, actual);
            Assert.IsTrue(list.Count == 4);
        }

        [TestMethod]
        public void RemoveByIndex_RemoveNumberInTheBegining()
        {
            DynamicList<int> list = new DynamicList<int>();

            list.Add(10);
            list.Add(11);
            list.Add(12);
            list.Add(13);
            list.Add(14);

            int actual = list.RemoveByIndex(0);
            Assert.AreEqual(10, actual);
            Assert.IsTrue(list.Count == 4);
        }

        [TestMethod]
        public void RemoveByIndex_RemoveNumberInTheEnd()
        {
            DynamicList<int> list = new DynamicList<int>();

            list.Add(10);
            list.Add(11);
            list.Add(12);
            list.Add(13);
            list.Add(14);

            int actual = list.RemoveByIndex(4);
            Assert.AreEqual(14, actual);
            Assert.IsTrue(list.Count == 4);
        }

        [TestMethod]
        public void RemoveLast_RemoveNumber()
        {
            DynamicList<int> list = new DynamicList<int>();

            list.Add(10);
            list.Add(11);
            list.Add(12);
            list.Add(13);
            list.Add(14);

            int actual = list.RemoveLast();
            Assert.AreEqual(14, actual);
            Assert.IsTrue(list.Count == 4);
        }

        [TestMethod]
        public void RemoveByIndex_RemoveHeadAndTail()
        {
            DynamicList<int> list = new DynamicList<int>();

            list.Add(10);

            int actual = list.RemoveLast();
            Assert.AreEqual(10, actual);
            Assert.IsTrue(list.Count == 0);
        }

        [TestMethod]
        public void RemoveByIndex_RemoveHead()
        {
            DynamicList<int> list = new DynamicList<int>();

            list.Add(10);
            list.Add(11);

            int actual = list.RemoveByIndex(0);
            Assert.AreEqual(10, actual);
            Assert.IsTrue(list.Count == 1);
        }

        [TestMethod]
        public void Remove_RemoveHead()
        {
            DynamicList<int> list = new DynamicList<int>();

            list.Add(10);
            list.Add(11);

            int actual = list.RemoveByIndex(0);
            Assert.AreEqual(10, actual);
            Assert.IsTrue(list.Count == 1);
        }

        [TestMethod]
        public void Remove_RemoveHeadAndLeaveEmptyList()
        {
            DynamicList<int> list = new DynamicList<int>();

            list.Add(10);
            

            int actual = list.RemoveByIndex(0);
            Assert.AreEqual(10, actual);
            Assert.IsTrue(list.Count == 0);
        }

        [TestMethod]
        public void Insert_InsertHead()
        {
            DynamicList<int> list = new DynamicList<int>();

            list.Add(10);
            list.Add(11);

            list.Insert(0, 1);
            
            Assert.IsTrue(list.Count == 3);
        }

        [TestMethod]
        public void Insert_InsertInTheMiddle()
        {
            DynamicList<int> list = new DynamicList<int>();

            list.Add(10);
            list.Add(11);

            list.Insert(1, 1);

            Assert.IsTrue(list.Count == 3);
        }
    }
}
