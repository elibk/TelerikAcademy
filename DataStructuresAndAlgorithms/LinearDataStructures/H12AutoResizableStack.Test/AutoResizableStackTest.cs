////
namespace H12AutoResizableStack.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AutoResizableStackTest
    {
        [TestMethod]
        public void Push_PushOneElement()
        {
            AutoResizableStack<int> stack = new AutoResizableStack<int>();

            stack.Push(10);

            Assert.IsTrue(stack.Count == 1);
        }

        [TestMethod]
        public void Push_PushTwoElements()
        {
            AutoResizableStack<int> stack = new AutoResizableStack<int>();

            stack.Push(10);
            stack.Push(11);

            Assert.IsTrue(stack.Count == 2);
        }

        [TestMethod]
        public void Push_PushFiveElements()
        {
            AutoResizableStack<int> stack = new AutoResizableStack<int>();

            stack.Push(10);
            stack.Push(11);
            stack.Push(12);
            stack.Push(13);
            stack.Push(14);

            Assert.IsTrue(stack.Count == 5);
            Assert.IsTrue(stack.Capacity == 8);
        }

        [TestMethod]
        public void Pop_OneOfMany()
        {
            AutoResizableStack<int> stack = new AutoResizableStack<int>();

            stack.Push(10);
            stack.Push(11);
            stack.Push(12);
            stack.Push(13);
            stack.Push(14);

            int actual = stack.Pop();

            Assert.AreEqual(14, actual);
            Assert.IsTrue(stack.Count == 4);
        }

        [TestMethod]
        public void Pop_OneOfOne()
        {
            AutoResizableStack<int> stack = new AutoResizableStack<int>();

            stack.Push(10);

            int actual = stack.Pop();

            Assert.AreEqual(10, actual);
            Assert.IsTrue(stack.Count == 0);
        }

        [TestMethod]
        public void Peek_OneOfOne()
        {
            AutoResizableStack<int> stack = new AutoResizableStack<int>();

            stack.Push(10);

            int actual = stack.Peek();

            Assert.AreEqual(10, actual);
            Assert.IsTrue(stack.Count == 1);
        }
    }
}
