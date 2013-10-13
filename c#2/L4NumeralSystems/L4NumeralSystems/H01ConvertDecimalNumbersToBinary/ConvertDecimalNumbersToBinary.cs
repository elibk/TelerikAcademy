////
namespace H01ConvertDecimalNumbersToBinary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

   public class ConvertDecimalNumbersToBinary
    {
       private static void Main(string[] args)
        {
            int decimalNum = 0;
            List<int> digits = new List<int> { };

            bool positiveCheck = true;

            if (decimalNum < 0)
            {
                positiveCheck = false;
                decimalNum = (decimalNum * -1) - 1;
            }

            while (decimalNum != 0)
            {
                if (positiveCheck)
                {
                    digits.Add(decimalNum % 2);
                }
                else
                {
                    if (decimalNum % 2 == 1)
                    {
                        digits.Add(0);
                    }
                    else
                    {
                        digits.Add(1);
                    }
                }

                decimalNum = decimalNum / 2;
            }

            foreach (var item in digits)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            string binaryNum = string.Concat(digits);

            if (positiveCheck)
            {
                Console.WriteLine(binaryNum.PadLeft(32, '0'));
            }
            else 
            {
                Console.WriteLine(binaryNum.PadLeft(32, '1'));                         
            }
        }
    }
}
