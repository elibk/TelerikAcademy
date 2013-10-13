using System;
using System.Globalization;
using System.Linq;

namespace H02BasicStatistics
{
   internal class BasicStatistics
    {
        static void Main(string[] args)
        {
            double[] numbers = {1.2, 2.0, 3};
            PrintBasicStatistics(numbers,numbers.Length);
        }

        public static void PrintBasicStatistics(double[] numbers, int count)
        {
            double max = GetMax(numbers, count);
            PrintMax(max);

            GetMin(numbers, count);
            PrintMin(max);

            double average = GetAverage(numbers, count);
            PrintAverage(average);
        }

        private static double GetAverage(double[] numbers, int count)
        {
            double average = 0;
            for (int i = 0; i < count; i++)
            {
                average += numbers[i];
            }
            average /= count; 
            return average;
        }

        private static void GetMin(double[] numbers, int count)
        {
            double min = numbers[0];
            for (int i = 0; i < count; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            }
        }

        private static double GetMax(double[] numbers, int count)
        {
            double max = numbers[0];

            for (int i = 0; i < count; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }
            return max;
        }

        private static void PrintAverage(double average)
        {
            CultureInfo invariantCulture = new CultureInfo("");
            Console.WriteLine(String.Format(invariantCulture,"Average : {0:#.##}", average));
        }

        private static void PrintMin(double min)
        {
            CultureInfo invariantCulture = new CultureInfo("");
            Console.WriteLine(String.Format(invariantCulture,"Minimum value : {0:#.##}", min));
        }


        private static void PrintMax(double max)
        {
            CultureInfo invariantCulture = new CultureInfo("");
            Console.WriteLine(String.Format(invariantCulture,"Maximum value : {0:#.##}", max));
        }
    }
}