////
namespace H01SquareRoot
{
    using System;
    using System.Linq;

    public class SquareRoot
    {
        private static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                double squareRoot = GetSquareRoot(number);
                Console.WriteLine("Square root of {0} is {1}.", number, squareRoot);
            }
            finally 
            {
                Console.WriteLine("Goodbye!");
            }
        }

        private static double GetSquareRoot(int number)
        {
            if (number < 0)
            {
                Exception negativeNumExeption = new Exception("You can't calculate square root of negative number.");

                throw negativeNumExeption;
            }

            return Math.Sqrt(number);
        }
    }
}
