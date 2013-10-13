////
namespace H06FilledString
{
    using System;
    using System.Linq;

   public class FilledString
    {
       private static void Main(string[] args)
        {
            string input;

            do
            {
                Console.Write("Enter string with max length 20 charecters:");
                input = Console.ReadLine();           
            } 
            while (input.Length > 20);

            input = input.PadRight(20, '*');
            Console.WriteLine(input);           
        }
    }
}
