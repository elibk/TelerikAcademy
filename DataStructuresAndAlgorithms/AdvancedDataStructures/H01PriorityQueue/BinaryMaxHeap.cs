namespace H01PriorityQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class BinaryMaxHeap<T>
        where T : IComparable
    {
        private readonly List<T> tree = new List<T>();

        public int Count
        {
            get 
            {
                return this.tree.Count();
            }
        }

        public T Root
        {
            get
            {
                return this.tree[0];
            }
        }

        public bool Contains(T element)
        {
            return this.tree.Contains(element);
        }

        public void AddElement(T newElement)
        {
            this.tree.Add(newElement);
            this.FindPositionForTheLastElement();
        }

        private void Swap(int indexFirstValue, int indexSecondValue)
        {
            T temp = this.tree[indexFirstValue];
            this.tree[indexFirstValue] = this.tree[indexSecondValue];
            this.tree[indexSecondValue] = temp;
        }

        private void FindPositionForTheLastElement()
        {
            int currentIndex = this.tree.Count - 1;

            var isSearchContinue = true;
            while (isSearchContinue)
            {
                isSearchContinue = false;
                var parentIndex = this.GetParentIndex(currentIndex);
                if (parentIndex >= 0)
                {
                    if (this.tree[parentIndex].CompareTo(this.tree[currentIndex]) < 0)
                    {
                        this.Swap(currentIndex, parentIndex);
                        currentIndex = parentIndex;
                        isSearchContinue = true;
                    }
                }
            }
        }

        private int GetParentIndex(int currentIndex)
        {
            return (currentIndex - 1) / 2;
        }

        private int GetLeftChildIndex(int currentIndex)
        {
            var index = (2 * currentIndex) + 1;

            if (index >= this.tree.Count)
            {
                index = -1;
            }

            return index;
        }

        private int GetRightChildIndex(int currentIndex)
        {
            var index = (2 * currentIndex) + 2;

            if (index >= this.tree.Count)
            {
                index = -1;
            }

            return index;
        }

        private void FindNewRoot()
        {
            this.Swap(this.tree.Count - 1, 0);
            this.tree.RemoveAt(this.tree.Count - 1);
            int currentIndex = 0;
           
            var isSearchContinue = true;
            while (isSearchContinue)
            {
                isSearchContinue = false;
                var leftChildIndex = this.GetLeftChildIndex(currentIndex);
                var rightChildIndex = this.GetRightChildIndex(currentIndex);

                if (leftChildIndex > 0 && rightChildIndex > 0)
                {
                    if (this.tree[leftChildIndex].CompareTo(this.tree[currentIndex]) > 0 && (this.tree[rightChildIndex].CompareTo(this.tree[currentIndex]) > 0))
                    {
                        var biggerIndex = leftChildIndex;
                       
                        if (this.tree[rightChildIndex].CompareTo(this.tree[leftChildIndex]) > 0)
                        {
                            biggerIndex = rightChildIndex;
                        }

                        this.Swap(currentIndex, biggerIndex);
                        currentIndex = biggerIndex;
                        isSearchContinue = true;
                    }
                    else if (this.tree[leftChildIndex].CompareTo(this.tree[currentIndex]) > 0)
                    {
                        var biggerIndex = leftChildIndex;
                        this.Swap(currentIndex, biggerIndex);
                        currentIndex = biggerIndex;
                        isSearchContinue = true;
                    }

                    if (this.tree[rightChildIndex].CompareTo(this.tree[currentIndex]) > 0)
                    {
                        var biggerIndex = rightChildIndex;
                        this.Swap(currentIndex, biggerIndex);
                        currentIndex = biggerIndex;
                        isSearchContinue = true;
                    }
                }
                else if (leftChildIndex > 0)
                {
                    if (this.tree[leftChildIndex].CompareTo(this.tree[currentIndex]) > 0)
                    {
                        var biggerIndex = leftChildIndex;
                        this.Swap(currentIndex, biggerIndex);
                        currentIndex = biggerIndex;
                        isSearchContinue = true;
                    }
                }
                else if (rightChildIndex > 0)
                {
                    if (this.tree[rightChildIndex].CompareTo(this.tree[currentIndex]) > 0)
                    {
                        var biggerIndex = rightChildIndex;
                        this.Swap(currentIndex, biggerIndex);
                        currentIndex = biggerIndex;
                        isSearchContinue = true;
                    }
                }
            }
        }

        public T GetTheRoot()
        {
            T root = this.tree[0];

            this.FindNewRoot();
            
            return root;
        }
    }
}