using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NumberToText
{
    static char firstDigit, secondDigit;
    static string units, tens, hundreds, teens;

    static void GetTens()
    {
        switch (secondDigit)
        {
            case '2':
                tens = "Twenty";
                break;
            case '3':
                tens = "Thirty";
                break;
            case '4':
                tens = "Fourty";
                break;
            case '5':
                tens = "Fifty";
                break;
            case '6':
                tens = "Sixty";
                break;
            case '7':
                tens = "Seventy";
                break;
            case '8':
                tens = "Eighty";
                break;
            case '9':
                tens = "Ninty";
                break;
        }
    }
    static void GetUnits()
    {
        switch (firstDigit)
        {
            case '0':
                units = "Zero";
                break;
            case '1':
                units = "One";
                break;
            case '2':
                units = "Two";
                break;
            case '3':
                units = "Three";
                break;
            case '4':
                units = "Four";
                break;
            case '5':
                units = "Five";
                break;
            case '6':
                units = "Six";
                break;
            case '7':
                units = "Seven";
                break;
            case '8':
                units = "Eight";
                break;
            case '9':
                units = "Nine";
                break;
        }
    }
    static void GetTeens()
    {
        switch (teens)
        {
            case "10":
                teens = "Ten";
                break;
            case "11":
                teens = "Elevan";
                break;
            case "12":
                teens = "Twelve";
                break;
            case "13":
                teens = "Thirdteen";
                break;
            case "14":
                teens = "Fourteen";
                break;
            case "15":
                teens = "Fifteen";
                break;
            case "16":
                teens = "Sixteen";
                break;
            case "17":
                teens = "Seventeen";
                break;
            case "18":
                teens = "Eighteen";
                break;
            case "19":
                teens = "Nineteen";
                break;
        }                 
    }

    static void Main()
    {
        Console.WriteLine("Enter number from 0 to 999");
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


