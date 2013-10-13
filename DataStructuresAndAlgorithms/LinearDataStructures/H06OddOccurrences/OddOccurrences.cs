////
namespace H06OddOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

   public class OddOccurrences
    {
       public static void Main(string[] args)
        {
            // Press 'Enter' to stop the input
            List<int> numbers = new List<int> { 1, -2, 1, 4, 1, -2, 4 };

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
            } 
            while (true);

            var oddOccurredNumbers = RemoveOddOccurredNumbers(numbers);
            DisplayCollection(oddOccurredNumbers);
        }

        private static IEnumerable<int> RemoveOddOccurredNumbers(IEnumerable<int> numbers)
        {
            Dictionary<int, int> numbersOccurences = new Dictionary<int, int>();

            foreach (var number in numbers)
            {
                if (numbersOccurences.ContainsKey(number))
                {
                    numbersOccurences[number]++;
                }
                else
                {
                    numbersOccurences[number] = 1;
                }
            }

            var evenOccurredNumbersOcurrence = numbersOccurences.Where(numberOccurrence => numberOccurrence.Value % 2 == 0);

            List<int> evenOccurredNumbers = new List<int>();

            foreach (var item in evenOccurredNumbersOcurrence)
            {
                for (int i = 0; i < item.Value; i++)
                {
                    evenOccurredNumbers.Add(item.Key);
                }
            }

            return evenOccurredNumbers;
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
