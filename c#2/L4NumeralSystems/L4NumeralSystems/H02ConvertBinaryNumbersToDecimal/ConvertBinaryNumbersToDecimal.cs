////
namespace H02ConvertBinaryNumbersToDecimal
{
    using System;
    using System.Linq;

   public class ConvertBinaryNumbersToDecimal
    {
       private static void Main(string[] args)
        {
            int number = -4;
            string bynaryNum = "10000000000000000000000001100100";
            int decimalNum = 0;
            for (int i = 0; i < bynaryNum.Length - 1; i++)
            {
                decimalNum = (decimalNum + (bynaryNum[i] - '0')) * 2;
            }

            decimalNum += bynaryNum[bynaryNum.Length - 1] - '0';

            Console.WriteLine(decimalNum);

            ////int NumSystemBase = 10;
            ////string binaryNum = "100";

            ////int decimalNum = 0;

            ////for (int i = binaryNum.Length - 1, numPosition = 0; i >= 0; i--, numPosition++)
            ////{
            ////    decimalNum += (int)(Math.Pow(NumSystemBase, (double)i)) * (((int)binaryNum[numPosition]) - 48);
            ////}
            ////Console.WriteLine(decimalNum);
        }
    }
}
