////
namespace H09FindingAndSorting
{
    using System;
    using System.Linq;

    public class SortingArray
    {
        public int[] SortInAscendingOrder(int[] array)
        {
            int[] sortedArray = (int[])array.Clone();
            Array.Sort(sortedArray);
            Array.Reverse(sortedArray);
            return sortedArray;
        }

        public int[] SortInDescendingOrder(int[] array)
        {
            int[] sortedArray = (int[])array.Clone();
            Array.Sort(sortedArray);
            return sortedArray;
        }
    }
}
