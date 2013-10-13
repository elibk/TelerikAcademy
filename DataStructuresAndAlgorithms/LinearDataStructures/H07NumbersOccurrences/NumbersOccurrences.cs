////
namespace H07NumbersOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

   public class NumbersOccurrences
    {
       public static void Main(string[] args)
        {
            // Press 'Enter' to stop the input
            List<int> numbers = new List<int> { 1, -2, 3, 4, 1, -2, 3, 4, 1, 4 };

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

            var numbersOccurrences = GetNumbersAndTheirOccurrences(numbers);
            DisplayOccurences(numbersOccurrences);
        }

        private static Dictionary<int, int> GetNumbersAndTheirOccurrences(IEnumerable<int> numbers)
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

            return numbersOccurences;
        }

        private static void DisplayOccurences(Dictionary<int, int> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine("{0} -> {1} times.", item.Key, item.Value);
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
