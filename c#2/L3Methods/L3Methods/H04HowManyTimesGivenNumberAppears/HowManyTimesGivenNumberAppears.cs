////
namespace H04HowManyTimesGivenNumberAppears
{
    using System;
    using System.Linq;

   public class HowManyTimesGivenNumberAppears
    {
       private static readonly int[] Array = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };

       private static int GetNumberFreq(int number)
        {
            int count = 0;

            for (int i = 0; i < Array.Length; i++)
            {
                if (number == Array[i])
                {
                    count++;
                }
            }

            return count;
        }

       private static void PrintArray() 
        {
            foreach (int number in Array)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
        }

       private static void Main(string[] args)
        {
            PrintArray();

            Random randomGenerator = new Random();

            int number = randomGenerator.Next(-5, 10);
            int numberFrequance = GetNumberFreq(number);
            Console.WriteLine("number {0} arrears {1} times.", number, numberFrequance);
        }
    }
}
