////
namespace H10ConvertCharToCharLiteral
{
    using System;
    using System.Linq;
    using System.Text;

   public class ConvertCharToCharLiteral
    {
       private static void Main(string[] args)
        {           
            string input = "Hi!";

            input = ConvertToLiterals(input);
            Console.WriteLine(input);
        }

        private static string ConvertToLiterals(string input)
        {
            StringBuilder strBild = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                strBild.Append(@"\u" + Convert.ToString((int)input[i], 16).PadLeft(4, '0'));
            }

            string output = strBild.ToString();
            return output;
        }
    }
}
