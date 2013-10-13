namespace H01PriorityQueue.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PriorityQueueTest
    {
        [TestMethod]
        public void Enqueue_AddOneElement()
        {
            PriorityQueue<int> queue = new PriorityQueue<int>();
            queue.Enqueue(25);
            Assert.AreEqual(1, queue.Count);
        }

        [TestMethod]
        public void Enqueue_AddFiveElements()
        {
            PriorityQueue<int> queue = new PriorityQueue<int>();
            queue.Enqueue(25);
            queue.Enqueue(13);
            queue.Enqueue(23);
            queue.Enqueue(33);
            queue.Enqueue(45);
            
            Assert.AreEqual(45, queue.Peek());
            Assert.AreEqual(5, queue.Count);
        }

        [TestMethod]
        public void Dequeue_RemoveRoot()
        {
            PriorityQueue<int> queue = new PriorityQueue<int>();
            queue.Enqueue(25);
            queue.Enqueue(13);
            queue.Enqueue(23);
            queue.Enqueue(33);
            queue.Enqueue(45);

            Assert.AreEqual(45, queue.Dequeue());
            Assert.AreEqual(4, queue.Count);
            Assert.AreEqual(33, queue.Peek());
        }
    }
}