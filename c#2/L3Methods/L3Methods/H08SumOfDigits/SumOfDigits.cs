////
namespace H08SumOfDigits
{
    using System;
    using System.Linq;

    public class SumOfDigits
    {
       private static void Main(string[] args)
        {
            string firstNum = "92233459",
                   secondNum = "21213";

            string sum = GetSum(firstNum, secondNum);

            Console.WriteLine(sum);
        }

        private static string GetSum(string firstNum, string secondNum)
        {
            char[] sum = ConvertStringToReversedArray(firstNum, secondNum);
            string sumString = ConvertArrayToReversedString(sum);

            return sumString;
        }

        private static char[] ConvertStringToReversedArray(string firstNum, string secondNum)
        {
            if (firstNum.Length > secondNum.Length)
            {
                secondNum = secondNum.PadLeft(firstNum.Length, '0');
            }
            else
            {
                firstNum = firstNum.PadLeft(secondNum.Length, '0');
            }

            char[] firstArray = new char[firstNum.Length];

            for (int indexArray = 0, indexString = firstNum.Length - 1; indexArray < firstNum.Length; indexArray++, indexString--)
            {
                firstArray[indexArray] = firstNum[indexString];
            }

            char[] secondArray = new char[secondNum.Length];

            for (int indexArray = 0, indexString = secondNum.Length - 1; indexArray < secondNum.Length; indexArray++, indexString--)
            {
                secondArray[indexArray] = secondNum[indexString];
            }

            char[] sumOfArrays;
            if (firstNum.Length > secondNum.Length)
            {
                sumOfArrays = Calculate(firstArray, secondArray);
            }
            else
            {
                sumOfArrays = Calculate(secondArray, firstArray);
            }

            return sumOfArrays;           
        }

        private static char[] Calculate(char[] biggerNum, char[] smallerNum)
        {
            char[] sum = new char[biggerNum.Length + 1];
            bool oneInMind = false;

            for (int i = 0; i < smallerNum.Length; i++)
            {
                if (oneInMind)
                {
                    sum[i] = (char)((int)biggerNum[i] + ((int)smallerNum[i] - 48) + 1);
                }
                else
                {
                    sum[i] = (char)((int)biggerNum[i] + ((int)smallerNum[i] - 48));
                }

                if (sum[i] > 57)
                {
                    oneInMind = true;
                    sum[i] = (char)(((int)sum[i] - 57) + 47);
                }
                else
                {
                    oneInMind = false;
                }
            }

            if (oneInMind)
            {
                sum[sum.Length - 1] = '1';
            }

            return sum;
        }

       private static string ConvertArrayToReversedString(char[] array)
        { 
            string sum = string.Empty;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                sum += array[i]; 
            }

            return sum;
        }
    }
}
