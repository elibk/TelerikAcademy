namespace H01OccurrencesOfNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

   public class OccurrencesOfNumber
    {
       public static void Main(string[] args)
        {
            double[] numbers = { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            IDictionary<double, int> numbersAndOccurrences = GetNumbersAndTheirOccurrences(numbers);
            DisplayResult(numbersAndOccurrences);
        }

        private static void DisplayResult(IDictionary<double, int> numbersAndOccurrences)
        {
            foreach (var number in numbersAndOccurrences)
            {
                Console.WriteLine("{0} --> {1} times.", number.Key, number.Value);
            }
        }

        private static IDictionary<double, int> GetNumbersAndTheirOccurrences(double[] numbers)
        {
            IDictionary<double, int> numbersAndOccurrences = new SortedDictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (!numbersAndOccurrences.ContainsKey(numbers[i]))
                {
                    numbersAndOccurrences.Add(numbers[i], 0);
                }

                numbersAndOccurrences[numbers[i]]++;
            }

            return numbersAndOccurrences;
        }
    }
}
