namespace H01PriorityQueue
{
    using System;
    using System.Linq;

    public class PriorityQueue<T>
        where T : IComparable
    {
        private BinaryMaxHeap<T> heap = new BinaryMaxHeap<T>();

        public int Count
        {
            get
            {
                return this.heap.Count;
            }
        }

        public bool Contains(T element)
        {
            return this.heap.Contains(element);
        }

        public void Clear(T element)
        {
            this.heap = new BinaryMaxHeap<T>();
        }

        public void Enqueue(T newElement)
        {
            this.heap.AddElement(newElement);
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new IndexOutOfRangeException("The Queue is empty.");
            }

            return this.heap.GetTheRoot();
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new IndexOutOfRangeException("The Queue is empty.");
            }

            return this.heap.Root;
        }
    }
}