namespace SortingAndSearchingAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
       

        public void Sort(IList<T> collection)
        {
             List<T> sortedList =  new List<T>();
             QuickSort(ref sortedList, collection);
             collection.Clear();
             for (int i = 0; i < sortedList.Count; i++)
             {
                 collection.Add(sortedList[i]);
             }
        }

        private void QuickSort(ref List<T> sortedCollection, IList<T> collection) 
        {
            T pivot = default(T);

            if (collection.Count <= 1)
            {
                sortedCollection.AddRange(collection);

                return;
            }
            else
            {
                pivot = collection[collection.Count / 2];
                collection.Remove(pivot);
                List<T> less = new List<T>();
                List<T> greater = new List<T>();

                for (int i = collection.Count - 1; i >= 0; i--)
                {
                    int result = collection[i].CompareTo(pivot);
                    if (result > 0)
                    {
                        greater.Add(collection[i]);
                    }
                    else
                    {
                        less.Add(collection[i]);
                    }
                }

                QuickSort(ref sortedCollection, less);
                sortedCollection.Add(pivot);
                QuickSort(ref sortedCollection, greater);
            }
        }
    }
}
