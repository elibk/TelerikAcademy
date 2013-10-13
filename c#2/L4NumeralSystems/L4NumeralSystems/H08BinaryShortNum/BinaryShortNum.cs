////
namespace H08BinaryShortNum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

   public class BinaryShortNum
    {
       private static void Main(string[] args)
        {
            short shortNum = 0;
            List<int> digits = new List<int> { };

            bool positiveCheck = true;

            if (shortNum < 0)
            {
                positiveCheck = false;
                shortNum = (short)((shortNum * -1) - 1);
            }

            while (shortNum != 0)
            {
                if (positiveCheck)
                {
                    digits.Add(shortNum % 2);
                }
                else
                {
                    if (shortNum % 2 == 1)
                    {
                        digits.Add(0);
                    }
                    else
                    {
                        digits.Add(1);
                    }
                }

                shortNum = (short)(shortNum / 2);
            }

            string binaryNum = string.Concat(digits);

            if (positiveCheck)
            {
                Console.WriteLine(binaryNum.PadLeft(16, '0'));
            }
            else
            {
                Console.WriteLine(binaryNum.PadLeft(16, '1'));
            }  
        }
    }
}
