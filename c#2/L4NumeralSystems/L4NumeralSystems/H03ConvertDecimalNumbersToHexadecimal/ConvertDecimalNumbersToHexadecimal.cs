////
namespace H03ConvertDecimalNumbersToHexadecimal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

   public class ConvertDecimalNumbersToHexadecimal
    {
       private static void Main(string[] args)
        {
            int decimalNum = 2660;
            List<int> digits = new List<int> { };

            while (decimalNum != 0)
            {
                digits.Add(decimalNum % 16);

                decimalNum = decimalNum / 16;
            }

            string hexNum = string.Empty;

            for (int i = digits.Count - 1; i >= 0; i--)
            {
                if (digits[i] > 9)
                {
                    hexNum += (char)(digits[i] + 55);
                }
                else
                {
                   hexNum += digits[i];
                }               
            }

            Console.WriteLine(hexNum);
        }
    }
}
