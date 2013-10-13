////
namespace H06NumbersSeparatedBySpaces
{
    using System;
    using System.Linq;

   public class NumbersSeparatedBySpaces
    {
       private static void Main(string[] args)
        {
            string numSequance = "43 68 9 23 318";
            int sum = Sum(numSequance);

            Console.WriteLine(sum);
        }

        private static int Sum(string numSequance)
        {
            string str = string.Empty;
            int result = new int();

            for (int i = 0; i < numSequance.Length; i++)
            {
                if (numSequance[i] != ' ')
                {
                    str += numSequance[i];
                }
                else
                {
                    result += int.Parse(str);
                    str = string.Empty;
                }
            }

            result += int.Parse(str);
            return result;
        }
    }
}
