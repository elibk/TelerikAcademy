////
namespace H04ConvertHexadicimalNumbersToDecimal
{
    using System;
    using System.Linq;

   public class ConvertHexadicimalNumbersToDecimal
    {
       private static void Main(string[] args)
        {
            int numSystemBase = 16;
            string hexNum = "A64";

            int decimalNum = 0;

            for (int i = hexNum.Length - 1, numPosition = 0; i >= 0; i--, numPosition++)
            {
                if (hexNum[numPosition] >= 65)
                {
                  decimalNum += (int)Math.Pow(numSystemBase, (double)i) * ((int)hexNum[numPosition] - 55); 
                }
                else
                {
                    decimalNum += (int)Math.Pow(numSystemBase, (double)i) * ((int)hexNum[numPosition] - 48);
                }
            }

            Console.WriteLine(decimalNum);
        }
    }
}
