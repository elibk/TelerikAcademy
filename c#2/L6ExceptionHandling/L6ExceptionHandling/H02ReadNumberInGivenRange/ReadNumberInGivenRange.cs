////
namespace H02ReadNumberInGivenRange
{
    using System;
    using System.Linq;

   public class ReadNumberInGivenRange
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter 10 numbers, every one on a single line, such that such that {1 < a1 < ... < a10 < 100}.");
            
            for (int start = 2, end = 99, count = 1; count <= 10; count++)
            {
                if (start < end)
                {
                    Console.Write("Enter number in range [{0}...{1}]:", start, end);
                    string number = Console.ReadLine();
                    int num = ReadNumber(number, start, end);
                
                    start = num + 1; 
                }
                else
                {
                    Console.WriteLine("You can not enter any more numbers.");
                    break;
                }            
            }   
        }

        private static int ReadNumber(string number, int start, int end)
        {
            int num = int.Parse(number);

            if (num < start || num > end)
            {
                throw new ArgumentOutOfRangeException("number must be in the range.");
            }

            return num;
        }
    }
}
