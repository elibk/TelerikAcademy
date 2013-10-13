// TODO : not finished yet
namespace H04SortFunctions
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    class TestPerformance
    {
        private static Random randomGenerator = new Random();
        private const int CountOfOperations = 1000;
        private static readonly Stopwatch recordTime = new Stopwatch();
        private static int elementsInArray = 5;
        private const string charSymbols = "abcdefghigk lmnopqrstuvwab-";


        static void Main(string[] args)
        {
            int[] intNumbers = CreateArrayOfInt();
            
            double[] doubleNumbers = CreateArrayOfDouble();
           
            string[] strings = CreateArrayOfString();

            Console.WriteLine("RANDOM ELEMNTS");

            object[] param = {intNumbers.Clone()};
            DisplayReportForPerformance("QickSortIntegers", param);
            param[0] = intNumbers.Clone();
            DisplayReportForPerformance("QickSortIntegers", param);
            param[0] = intNumbers.Clone();
            DisplayReportForPerformance("QickSortIntegers", param);
            Console.WriteLine(new string('~', Console.WindowWidth));
            param[0] = doubleNumbers.Clone();
            DisplayReportForPerformance("QickSortDoubles", param);
            param[0] = doubleNumbers.Clone();
            DisplayReportForPerformance("QickSortDoubles", param);
            param[0] = doubleNumbers.Clone();
            DisplayReportForPerformance("QickSortDoubles", param);
            Console.WriteLine(new string('~', Console.WindowWidth));
            param[0] = strings.Clone();
            DisplayReportForPerformance("QickSortStrings", param);
            param[0] = strings.Clone();
            DisplayReportForPerformance("QickSortStrings", param);
            param[0] = strings.Clone();
            DisplayReportForPerformance("QickSortStrings", param);

            Console.WriteLine("SORTED ELEMNTS");

            intNumbers = CreateArrayOfInt();
            Array.Sort(intNumbers);
            param[0] = intNumbers;
            DisplayReportForPerformance("QickSortIntegers", param);
            DisplayReportForPerformance("QickSortIntegers", param);
            DisplayReportForPerformance("QickSortIntegers", param);
            Console.WriteLine(new string('~', Console.WindowWidth));
            doubleNumbers = CreateArrayOfDouble();
            Array.Sort(doubleNumbers);
            param[0] = doubleNumbers;
            DisplayReportForPerformance("QickSortDoubles", param);
            DisplayReportForPerformance("QickSortDoubles", param);
            DisplayReportForPerformance("QickSortDoubles", param);
            Console.WriteLine(new string('~', Console.WindowWidth));
            param[0] = strings;
            DisplayReportForPerformance("QickSortStrings", param);
            DisplayReportForPerformance("QickSortStrings", param);
            DisplayReportForPerformance("QickSortStrings", param);
            
        }

        public static void QickSortIntegers( ref int[] arr)
        {
            recordTime.Start();
            // class Array implemented QickSort
            Array.Sort(arr);
            recordTime.Stop();
        }

        public static void QickSortDoubles(ref double[] arr)
        {
            recordTime.Start();
            // class Array implemented QickSort
            Array.Sort(arr);
            recordTime.Stop();
        }

        public static void QickSortStrings(ref string[] arr)
        {
            recordTime.Start();
            // class Array implemented QickSort
            Array.Sort(arr);
            recordTime.Stop();
        }

        private static void DisplayReportForPerformance(string methodName, object[] parameters)
        {
            recordTime.Reset();
            Type classType = typeof(TestPerformance);
            MethodInfo method = classType.GetMethod(methodName);
            if (method != null)
            {

                for (int i = 0; i < CountOfOperations; i++)
                {

                    method.Invoke(null, parameters);

                }
            }

            Console.WriteLine(methodName);
            Console.WriteLine("Performed {0} operations. Elemnts in array {1}.", CountOfOperations, elementsInArray);
            Console.WriteLine("Time elapsed in milliseconds {0}.", recordTime.Elapsed.TotalMilliseconds);
            Console.WriteLine(new string('-', Console.WindowWidth));
        }

        
        
        private static double[] CreateArrayOfDouble()
        {
           
            double[] arr = new double[elementsInArray];

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                arr[i] = randomGenerator.Next(int.MinValue, int.MaxValue) + randomGenerator.NextDouble();
            }

            return arr;
        }

        private static int[] CreateArrayOfInt()
        {
            

            int[] arr = new int[elementsInArray];


            for (int i = arr.Length - 1; i >= 0; i--)
            {
                arr[i] = randomGenerator.Next(int.MinValue, int.MaxValue) ;
            }

            return arr;
        }

        private static string[] CreateArrayOfString()
        {
            
            string[] arr = new string[elementsInArray];
            

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                arr[i] = GenerateString();
            }

            return arr;
        }

        private static string GenerateString()
        {
           
            StringBuilder result = new StringBuilder();
            int stringMinLen = 1;
            int stringMaxLen = 100;

            int stringlen = randomGenerator.Next(stringMinLen, stringMaxLen);

            for (int i = 0; i < stringlen; i++)
            {
                result.Append(charSymbols[randomGenerator.Next(0, charSymbols.Length)]);
            }

            return result.ToString();
        }
    }
}
