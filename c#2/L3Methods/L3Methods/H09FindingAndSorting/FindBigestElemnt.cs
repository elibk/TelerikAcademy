////
namespace H09FindingAndSorting
{
    using System;
    using System.Linq;

   public class FindBigestElemnt
    {
       private static void Main(string[] args)
        {
            int[] array = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
            int start = 2; 
            Console.WriteLine("Array:");
            PrintArray(array);
            int biggestElemnt = FindBiggest(array);
            Console.WriteLine("Biggest element:{0}.", biggestElemnt);

            SortingArray sort = new SortingArray { };

            int[] arrayDecendingOrder = sort.SortInDescendingOrder(array);
            Console.WriteLine("Array sort in decending order:");
            PrintArray(arrayDecendingOrder);               
            biggestElemnt = FindBiggest(arrayDecendingOrder, start);
            Console.WriteLine("Biggest element between index {0} and index {1} inclusive is:{2}.", start, array.Length - 1, biggestElemnt);

            int[] arrayAscendingOrder = sort.SortInAscendingOrder(array);
            biggestElemnt = FindBiggest(arrayAscendingOrder, start);
            Console.WriteLine("Array sort in ascending order:");
            PrintArray(arrayAscendingOrder);
            Console.WriteLine("Biggest element between index {0} and index {1} inclusive is:{2}.", start, array.Length - 1, biggestElemnt);
        }

        private static void PrintArray(int[] array)
        {
            Console.WriteLine(String.Join(", ",array)); 
        }

        private static int FindBiggest(int[] array, int start = 0)
        {
            int biggest = array[start];

            for (int i = start; i < array.Length; i++)
            {
                if (array[i] > biggest)
                {
                    biggest = array[i];
                }
            }

            return biggest;
        }
    }
}
