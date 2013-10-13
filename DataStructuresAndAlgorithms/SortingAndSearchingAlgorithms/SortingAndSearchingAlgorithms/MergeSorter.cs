namespace SortingAndSearchingAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            T[] sortedList = MergeSort(collection.ToArray());
            
            collection.Clear();
            for (int i = 0; i < sortedList.Length; i++)
            {
                collection.Add(sortedList[i]);
            }
        }

        private T[] MergeSort(T[] array) 
        {
            if (array.Length <= 1)
            {
                return array;
            }

            int middle = array.Length / 2;
            T[] left = new T[middle];
            T[] right = new T[array.Length - middle];
            for (int i = 0; i < middle; i++)
            {
                left[i] = array[i];
            }

            for (int i = 0; i < right.Length; i++)
            {
                right[i] = array[middle + i];
            }

            left = MergeSort(left);
            right = MergeSort(right);

            int leftptr = 0;
            int rightptr = 0;

            T[] sorted = new T[array.Length];
            for (int k = 0; k < array.Length; k++)
            {
                if (rightptr == right.Length || ((leftptr < left.Length) && (left[leftptr].CompareTo(right[rightptr]) <= 0)))
                {
                    sorted[k] = left[leftptr];
                    leftptr++;
                }
                else if (leftptr == left.Length || ((rightptr < right.Length) && (right[rightptr].CompareTo(left[leftptr])) <= 0))
                {
                    sorted[k] = right[rightptr];
                    rightptr++;
                }
            }
            return sorted;
        }
    }
}
