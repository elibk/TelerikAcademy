////
namespace H10CalculateFactorial
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

   public class CalculateFactorial
    {
       private static void Main(string[] args)
        {
            string[] factorials = new string[101];

            factorials[1] = "1";

            for (int i = 2; i <= 100; i++)
            {
                factorials[i] = Multiplicator(factorials[i - 1], i);  
            }

            PrintArray(factorials);
        }

        private static void PrintArray(string[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                Console.WriteLine("{0}! = {1}", i, array[i]);
            }
        }

        private static string Multiplicator(string number, int num)
        {
            List<string> sums = new List<string>(number.Length);

            for (int i = number.Length - 1, zeros = 0; i >= 0; i--, zeros++)
            {
                sums.Add((num * ((int)number[i] - 48)) + new string ('0', zeros));
            }

            string factorial = sums[0];

            for (int i = 1; i < sums.Count; i++)
            {
              factorial = Calculate(factorial, sums[i]);
            }

            return factorial;
        }

      private static string Calculate(string biggerNum, string smallerNum)
        {     
            bool oneInMind = false;

            if (biggerNum.Length > smallerNum.Length)
            {
                smallerNum = smallerNum.PadLeft(biggerNum.Length, '0');
            }
            else
            {
                biggerNum = biggerNum.PadLeft(smallerNum.Length, '0');
            }

            char[] sum = new char[biggerNum.Length + 1];

            for (int i = smallerNum.Length - 1; i >= 0; i--)
            {
                if (oneInMind)
                {
                    sum[i + 1] = (char)((int)biggerNum[i] + ((int)smallerNum[i] - 48) + 1);
                }
                else
                {
                    sum[i + 1] = (char)((int)biggerNum[i] + ((int)smallerNum[i] - 48));
                }

                if (sum[i + 1] > 57)
                {
                    oneInMind = true;
                    sum[i + 1] = (char)(((int)sum[i + 1] - 57) + 47);
                }
                else
                {
                    oneInMind = false;
                }
            }

            if (oneInMind)
            {
                sum[0] = '1';
                string sumString = new string(sum);

                return sumString;
            }
            else
            {
                string sumString = new string(sum);

                return sumString.Substring(1);
            }           
        }
    }
}
