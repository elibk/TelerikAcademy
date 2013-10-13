////
namespace H03SortedNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

   public class SortNumbers
    {
       public static void Main(string[] args)
        {
            // Press 'Enter' to stop the input
            List<int> numbers = new List<int> { 2, 5, -4 };

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
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            } 
            while (true);

            numbers.Sort();
            DisplayCollection(numbers);
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
                throw new ArgumentException(string.Format("The input must be a number between 0 and {0}.", int.MaxValue));
            }
            else if (number < 0)
            {
                throw new ArgumentOutOfRangeException("The numbers must be positive.");
            }

            return number;
        }
    }
}
