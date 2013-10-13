////
namespace H02ReversedNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

   public class ReverseNumbers
    {
       public static void Main(string[] args)
        {
            // Press 'Enter' to stop the input
            Stack<int> numbers = new Stack<int>();

            do
            {
                try
                {
                    int number = ReadInput();
                    numbers.Push(number);
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

            DisplayReversedNumbers(numbers);
        }

        private static void DisplayReversedNumbers(Stack<int> numbers)
        {
            while (numbers.Count > 0)
            {
                Console.WriteLine(numbers.Pop()); 
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
