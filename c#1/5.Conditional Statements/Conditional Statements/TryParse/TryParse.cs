//Write a program that, depending on the user's choice inputs int, double or string variable. 
//If the variable is integer or double, increases it with 1. 
//If the variable is string, appends "*" at its end. 
//The program must show the value of that variable as a console output
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryParse
{
    class TryParse
    {
        static void Main()
        {
            Console.Write("Enter integer number, double number or text:");
            string numberS = Console.ReadLine();
            double numberD;
            int numberI;

            if (int.TryParse(numberS, out numberI))
            {
                Console.WriteLine(numberI + 1);
            }
            else
            {
                switch (double.TryParse(numberS, out numberD))
                {
                    case true:
                        Console.WriteLine(numberD + 1);
                        break;
                    default:
                        Console.WriteLine(numberS + "*");
                        break;
                }
            }
            
        }
    }
}
