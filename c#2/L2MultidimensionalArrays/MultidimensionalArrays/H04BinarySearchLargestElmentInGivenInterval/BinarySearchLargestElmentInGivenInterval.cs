////
namespace H04BinarySearchLargestElmentInGivenInterval
{
    using System;
    using System.Linq;

    public class BinarySearchLargestElmentInGivenInterval
    {
       private static void Main(string[] args)
        {
            int[] array = { 3, 5, 6, 2, 3, 4, 2, 1, 7 };
            int k = 1;

            array = Sort(array);
            PrintArray(array);

            int searchResult = BinSearch(array, k);
            PrintResult(searchResult, array);
        }

        private static int BinSearch(int[] array, int k)
        {
            return Array.BinarySearch(array, k);
        }

        private static int[] Sort(int[] array)
        {
           Array.Sort(array);
           return array;
        }

        private static void PrintArray(int[] array)
        {
            foreach (var number in array)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
        }

        private static void PrintResult(int searchResult, int[] array)
        {
            if (searchResult >= 0)
            {
                Console.WriteLine("Element {0} found inder index {1}.", array[searchResult], searchResult);
            }
            else if (searchResult == -1)
            {
                Console.WriteLine("There isn't found element which is <= K.");
            }
            else
            {
                searchResult = (searchResult * -1) - 2;
                Console.WriteLine("Element {0} found inder index {1}.", array[searchResult], searchResult);
            }
        }
    }
}
