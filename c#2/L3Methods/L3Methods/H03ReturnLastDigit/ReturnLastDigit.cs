////
namespace H03ReturnLastDigit
{
    using System;
    using System.Linq;

   public class ReturnLastDigit
    {
      private static char lastDigit;
      private static string digitLast = string.Empty;

       private static void GetLastDigit(string number)
        {
            lastDigit = number[number.Length - 1];

            ConvertDigitToText(lastDigit);
        }

       private static void ConvertDigitToText(char digit)
        {  
            switch (digit)
            {
                case '0':
                    digitLast = "zero";
                    break;
                case '1':
                    digitLast = "one";
                    break;
                case '2':
                    digitLast = "two";
                    break;
                case '3':
                    digitLast = "three";
                    break;
                case '4':
                    digitLast = "four";
                    break;
                case '5':
                    digitLast = "five";
                    break;
                case '6':
                    digitLast = "six";
                    break;
                case '7':
                    digitLast = "seven";
                    break;
                case '8':
                    digitLast = "eight";
                    break;
                case '9':
                    digitLast = "nine";
                    break;
                default:
                    digitLast = "Incorrect input!";
                    break;
            }
        }

       private static void Main(string[] args)
        {
            string number = Console.ReadLine();

            GetLastDigit(number);

            Console.WriteLine(digitLast);
        }
    }
}
