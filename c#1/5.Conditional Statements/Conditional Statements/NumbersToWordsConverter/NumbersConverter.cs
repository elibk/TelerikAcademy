////NumbersToWordsConverter
////This is a solution of the traditional task: to convert numbers into english words.
////Can be very useful for accounting or creating any documentation.
////One of my earliest projects. 
namespace NumbersToWordsConverter
{
    using System;
    using System.Linq;

   public class NumbersConverter
    {
        private static char firstDigit, secondDigit;
        private static string units, tens, hundreds, teens;

        private static void GetTens()
        {
            switch (secondDigit)
            {
                case '2':
                    tens = "twenty";
                    break;
                case '3':
                    tens = "thirty";
                    break;
                case '4':
                    tens = "fourty";
                    break;
                case '5':
                    tens = "fifty";
                    break;
                case '6':
                    tens = "sixty";
                    break;
                case '7':
                    tens = "seventy";
                    break;
                case '8':
                    tens = "eighty";
                    break;
                case '9':
                    tens = "ninty";
                    break;
            }
        }

        private static void GetUnits()
        {
            switch (firstDigit)
            {
                case '0':
                    units = "zero";
                    break;
                case '1':
                    units = "one";
                    break;
                case '2':
                    units = "two";
                    break;
                case '3':
                    units = "three";
                    break;
                case '4':
                    units = "four";
                    break;
                case '5':
                    units = "five";
                    break;
                case '6':
                    units = "six";
                    break;
                case '7':
                    units = "seven";
                    break;
                case '8':
                    units = "eight";
                    break;
                case '9':
                    units = "nine";
                    break;
            }
        }

        private static void GetTeens()
        {
            switch (teens)
            {
                case "10":
                    teens = "ten";
                    break;
                case "11":
                    teens = "elevan";
                    break;
                case "12":
                    teens = "twelve";
                    break;
                case "13":
                    teens = "thirdteen";
                    break;
                case "14":
                    teens = "fourteen";
                    break;
                case "15":
                    teens = "fifteen";
                    break;
                case "16":
                    teens = "sixteen";
                    break;
                case "17":
                    teens = "seventeen";
                    break;
                case "18":
                    teens = "eighteen";
                    break;
                case "19":
                    teens = "nineteen";
                    break;
            }
        }

        private static void Main(string[] args)
        {
            Console.Write("Enter number from 0 to 999:");
            string numText = Console.ReadLine();
            int number = int.Parse(numText);

            if (number < 20)
            {
                if (number < 10)
                {
                    firstDigit = numText[0];
                    GetUnits();
                    Console.WriteLine(units);
                }
                else
                {
                    teens = numText.Substring(numText.Length - 2);
                    GetTeens();
                    Console.WriteLine(teens);
                }
            }
            else if (number > 19 && number < 100)
            {
                secondDigit = numText[0];
                firstDigit = numText[1];
                GetTens();
                GetUnits();

                if (firstDigit == '0')
                {
                    Console.WriteLine(tens);
                }
                else
                {
                    Console.WriteLine("{0} {1}", tens, units);
                }
            }
            else if (number > 99)
            {
                firstDigit = numText[0];
                GetUnits();
                hundreds = units;
                secondDigit = numText[1];
                firstDigit = numText[2];
                teens = numText.Substring(numText.Length - 2);
                GetTens();
                GetUnits();

                if (secondDigit == '1')
                {
                    GetTeens();
                    Console.WriteLine("{0} hundred and {1}", hundreds, teens);
                }
                else if (secondDigit == '0')
                {
                    if (firstDigit == '0')
                    {
                        Console.WriteLine("{0} hundred", hundreds);
                    }
                    else
                    {
                        Console.WriteLine("{0} hundred and {1}", hundreds, units);
                    }
                }
                else
                {
                    Console.WriteLine("{0} hundred {1} {2}", hundreds, tens, units);
                }
            }
        }
    }
}
