////
namespace H10SequenceOfGivenSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SequenceOfGivenSum
    {
        private static void Main(string[] args)
        {
            int[] array = { 4, 3, 1, -1, 2, 5, 8 };
            Console.Write("Check if some sum present in given array.Enter sum:");
            int sum = int.Parse(Console.ReadLine());
            int currentSum = int.MinValue;
            List<int> subarray = new List<int> { };

            for (int indexStart = 0; indexStart < array.Length - 1; indexStart++)
            {
                currentSum = array[indexStart];
                subarray.Clear();
                subarray.Add(array[indexStart]);

                for (int i = indexStart + 1; i < array.Length; i++)
                {
                    currentSum += array[i];
                    subarray.Add(array[i]);
                    if (currentSum == sum)
                    {
                        break;
                    }
                }

                if (sum == currentSum)
                {
                    break;
                }
            }

            if (currentSum == sum)
            {
                Console.WriteLine("Yes");
                foreach (var item in subarray)
                {
                    Console.Write(" " + item);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No");
            }
        }     
    }
}
