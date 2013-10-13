////
namespace H01SumAndAverage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

   public class SumAndAverage
    {
       public static void Main(string[] args)
        {
            // Press 'Enter' to stop the input
            List<int> numbers = new List<int> { 1, 3, 1 };

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
           
            Console.WriteLine(numbers.Sum());
            Console.WriteLine(numbers.Average());
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
