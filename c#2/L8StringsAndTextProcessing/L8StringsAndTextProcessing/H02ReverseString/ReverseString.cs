////
namespace H02ReverseString
{
    using System;
    using System.Linq;
    using System.Text;

   public class ReverseString
    {
       private static void Main(string[] args)
        {
            string input = "sample";
            input = Reverse(input);

            Console.WriteLine(input);
        }

        private static string Reverse(string input)
        {
            char[] array = input.ToArray();

            array = array.Reverse().ToArray();

            StringBuilder reversedWord = new StringBuilder();

            reversedWord.Append(array);
            input = reversedWord.ToString();

            return input;
        }
    }
}
