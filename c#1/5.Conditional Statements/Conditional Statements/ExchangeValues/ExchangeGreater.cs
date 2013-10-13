using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeValues
{
    class ExchangeGreater
    {
        static void Main()
        {

            Console.WriteLine("Enter two numbers to see which is greater:");
            double firstNum = double.Parse(Console.ReadLine());
            double secondNum = double.Parse(Console.ReadLine());

            if (secondNum > firstNum )
            {
                firstNum = secondNum;
            }
            Console.WriteLine("The greatest number is {0}",firstNum);
        }
    }
}
