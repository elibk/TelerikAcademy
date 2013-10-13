namespace SortingAndSearchingAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int index = 0; index < collection.Count - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(collection, index, collection.Count - 1);
                Swap(ref collection , index, minElementIndex);
            }
        }

        private static int FindMinElementIndex(IList<T> arr, int startIndex, int endIndex)
       
        {
            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            return minElementIndex;
        }

        private static void Swap(ref IList<T> collection, int xIndex, int yIndex)
        {
            T oldX = collection[xIndex];
            collection[xIndex] = collection[yIndex];
            collection[yIndex] = oldX;
        }
    }
}
