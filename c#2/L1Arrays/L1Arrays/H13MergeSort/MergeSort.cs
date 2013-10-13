using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H13MergeSort
{
    class MergeSort
    {
        private static int[] MergeSortAlg(int[] array)
        {
            if (array.Length <= 1)
            { 
                return array; 
            }
               
            int middle = array.Length / 2;
            int[] left = new int[middle];
            int[] right = new int[array.Length - middle];
            for (int i = 0; i < middle; i++)
            {
                left[i] = array[i];
                right[i] = array[i + middle];
            }
           
            left = MergeSortAlg(left);
            right = MergeSortAlg(right);

            int leftptr = 0;
            int rightptr = 0;

            int[] sorted = new int[array.Length];
            for (int k = 0; k < array.Length; k++)
            {
                if (rightptr == right.Length || ((leftptr < left.Length) && (left[leftptr] <= right[rightptr])))
                {
                    sorted[k] = left[leftptr];
                    leftptr++;
                }
                else if (leftptr == left.Length || ((rightptr < right.Length) && (right[rightptr] <= left[leftptr])))
                {
                    sorted[k] = right[rightptr];
                    rightptr++;
                }
            }
            return sorted;
        }

        private static int[] BubbleSort(int[] array)
        {
            bool isSorted = true;
            //int[] sortedArray = new int[array.Length];
            int tempValue = 0;

            do
            {
                isSorted = true;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        tempValue = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = tempValue;
                        isSorted = false;
                    }
                }
            } while (isSorted == false);


            return array;
        }

        static void Main(string[] args)
        {
            int[] array = {1,4,1,3,8,5,9,2 };
            //array = MergeSortAlg(array);
            array = BubbleSort(array);
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
