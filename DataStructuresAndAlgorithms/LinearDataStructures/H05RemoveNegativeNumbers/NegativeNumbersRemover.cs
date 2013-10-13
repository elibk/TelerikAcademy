using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H05RemoveNegativeNumbers
{
    class NegativeNumbersRemover
    {
        static void Main(string[] args)
        {
            // Press 'Enter' to stop the input
            List<int> numbers = new List<int> { 1,-2, 3, 4};

            do
            {
                try
                {
                    int number = ReadInput();
                    numbers.Add(number);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (OperationCanceledException)
                {
                    break;
                }

            } while (true);

            var nonNegativeNumbers = RemoveNegativeNumbers(numbers);
            DisplayCollection(nonNegativeNumbers);
        }

        private static IEnumerable<int> RemoveNegativeNumbers(IEnumerable<int> numbers)
        {
            //List<int> nonNegativeNumbers = new List<int>();

            //foreach (var number in numbers)
            //{
            //    if (number >= 0)
            //    {
            //        nonNegativeNumbers.Add(number);
            //    }
            //}

            var nonNegativeNumbers = numbers.Where(number => number >= 0);

            return nonNegativeNumbers;
        }

        private static void DisplayCollection<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        private static int ReadInput()
        {
            string input = Console.ReadLine();

            if (input == null || input == string.Empty)
            {
                throw new OperationCanceledException("End of input");
            }

            int number;
            if (!int.TryParse(input, out number))
            {
                throw new ArgumentOutOfRangeException(string.Format("The input must be a number between {0} and {1}.", int.MinValue, int.MaxValue));
            }

            return number;
        }
    }
}
