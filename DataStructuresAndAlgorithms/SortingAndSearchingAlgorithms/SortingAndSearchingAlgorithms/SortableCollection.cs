namespace SortingAndSearchingAlgorithms
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (var itemInColection in this.items)
            {
                if (itemInColection.CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            int arrayMiddle = this.items.Count / 2,
                arrayStart = 0,
                arrayEnd = this.items.Count - 1,
                arrayLen = this.items.Count;

            while (arrayStart != arrayEnd)
            {
                if (this.items[arrayMiddle].CompareTo(item) < 0)
                {
                    arrayStart = arrayMiddle + 1;
                }
                else if (this.items[arrayMiddle].CompareTo(item) > 0)
                {
                    arrayEnd = arrayMiddle - 1;
                }
                else
                {
                    break;
                }

                arrayLen = arrayStart + arrayEnd + 1;
                arrayMiddle = arrayLen / 2;
            }
            if (arrayStart == arrayEnd)
            {
                if (this.items[arrayMiddle].CompareTo(item) == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public void Shuffle()
        {
            var rand = new Random();
            for (int i = this.items.Count - 1; i > 0; i--)
            {
                int n = rand.Next(i + 1);
                T temp = this.items[i];
                this.items[i] = this.items[n];
                this.items[n] = temp;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
