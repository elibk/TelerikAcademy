////Sorting an array means to arrange its elements in increasing order. 
////Write a program to sort an array. Use the "selection sort" algorithm:
////Find the smallest element, move it at the first position, 
////find the smallest from the rest, move it at the second position, etc.
namespace H7SortingAnArray
{
    using System;
    using System.Linq;

    public class SortingAnArray
    {
        private static void Main(string[] args)
        {
            int[] array = { 8, 7, 6, 5, 2, -1, 6, 4, -8, 8 };
            int[] sortArray = new int[array.Length];
            int smallerNum = array[0];
            int indexSmaller = 0;

            // writte Array
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            for (int position = 0; position < array.Length; position++)
            {
                smallerNum = array[position];               
                
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] <= smallerNum)
                    {
                        smallerNum = array[i];
                        indexSmaller = i;
                    }
                }

                array[indexSmaller] = int.MaxValue;
                sortArray[position] = smallerNum;
            }

            // writte sorted Array
            foreach (var item in sortArray)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}
