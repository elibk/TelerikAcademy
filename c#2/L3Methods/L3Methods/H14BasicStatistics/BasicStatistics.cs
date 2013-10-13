////
namespace H14BasicStatistics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

   public class BasicStatistics
    {
       private static void Main(string[] args)
        {
            Console.WriteLine("Enter sequace of integer numbers, divided by ; (1;2;3;...n):");
            string sequence = Console.ReadLine();

            List<int> numbers = ConvertToSequenceOfIntegers(sequence);

            int min = GetMin(numbers);
            int max = GetMax(numbers);
            double average = GetAverage(numbers);
            int sum = GetSum(numbers);
            long product = GetProduct(numbers);

            Console.WriteLine("Minimal = {0}", min);
            Console.WriteLine("Maximal = {0}", max);
            Console.WriteLine("Average = {0}", average);
            Console.WriteLine("Sum = {0}", sum);
            Console.WriteLine("Product = {0}", product);           
        }

        private static List<int> ConvertToSequenceOfIntegers(string sequence)
        {
            List<int> numbers = new List<int>();
            int count = new int();

            if (sequence.LastIndexOf(';') == sequence.Length - 1)
            {
                sequence = sequence.Substring(0, sequence.Length - 1);
            }

            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] == ';')
                {
                    numbers.Add(int.Parse(sequence.Substring(i - count, count)));
                    count = 0;
                }
                else
                {
                    count++;
                }
            }

            numbers.Add(int.Parse(sequence.Substring((sequence.Length) -count, count)));
            count = 0;

            return numbers;
        }

        private static long GetProduct(List<int> numbers)
        {
           long product = 1;
           for (int i = 0; i < numbers.Count; i++)
           {
               product *= numbers[i];
           }

           return product;
        }

        private static int GetSum(List<int> numbers)
        {
            int sum = numbers.Sum();
            return sum;
        }

        private static double GetAverage(List<int> numbers)
        {
            double average = GetSum(numbers) / (double)numbers.Count;
            return average;
        }

        private static int GetMax(List<int> numbers)
        {
            int max = numbers.Max();
            return max;
        }

        private static int GetMin(List<int> numbers)
        {
            int min = numbers.Min();
            return min;
        }
    }
}
