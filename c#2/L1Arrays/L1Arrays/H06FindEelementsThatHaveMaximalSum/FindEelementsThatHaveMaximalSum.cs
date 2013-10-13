////
namespace H06FindEelementsThatHaveMaximalSum
{
    using System;
    using System.Linq;

    public class FindEelementsThatHaveMaximalSum
    {
        private static void Main(string[] args)
        {
            Console.Write("Enter array's length:");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Of how many elemnts of array you want to know maximal sum:");
            int k = int.Parse(Console.ReadLine());
            ////int[] array = { 8, 7, 6, 5, 2, -1, 6, 4, -8, 8 };
            int[] array = new int[n];
            int[] sortArray = new int[k];
            int bigest = array[0];
            int indexSmaller = 0;

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("Element {0}:", i);
                array[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine();

            for (int position = 0; position < sortArray.Length; position++)
            {
                bigest = array[position];

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] >= bigest)
                    {
                        bigest = array[i];
                        indexSmaller = i;
                    }
                }

                array[indexSmaller] = int.MinValue;
                sortArray[position] = bigest;
            }

            int maxSum = 0;
            //// writte sorted Array
            Console.Write("{");
            foreach (var item in sortArray)
            {
                Console.Write(item + " ");
                maxSum += item;
            }

            Console.WriteLine("} with sum " + maxSum);
        }
    }
}
