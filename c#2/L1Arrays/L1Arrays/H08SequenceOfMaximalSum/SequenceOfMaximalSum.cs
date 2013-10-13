////Kadane's algorithm
namespace H08SequenceOfMaximalSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SequenceOfMaximalSum
    {
        private static int sum;

        private static List<int> MaxSubarray(int[] array)
        {
            sum = 0;
            int currentSum = 0;
            List<int> currentSubarray = new List<int> { };
            List<int> maxSubarray = new List<int> { };
 
            for (int i = 0; i < array.Length; i++)
            {
                currentSum += array[i];
                currentSubarray.Add(array[i]);

                if (currentSum < 0)
                {
                    currentSum = 0;
                    currentSubarray.Clear();
                }

                if (sum < currentSum)
                {
                    sum = currentSum;
                    maxSubarray.Clear();
                    maxSubarray.AddRange(currentSubarray);
                }
            }

            return maxSubarray;           
        }

        private static void PrintArray(List<int> array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }   
        }

       private static void PrintSum(int sum)
        {
            Console.WriteLine("Sum = " + sum);
        }

       private static void Main(string[] args)
        {
            int[] array = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };

            List<int> subarray = MaxSubarray(array);
            PrintArray(subarray);
            PrintSum(sum);
        }     
    }
}
