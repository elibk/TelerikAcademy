using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciSequence
{
    class FibonacciSequence
    {
        static void Main()
        {
            int member = 2;
            decimal firstNum = 0;
            decimal secondNum = 1;
            decimal thirdNum = 0;
            Console.WriteLine(firstNum);
            Console.WriteLine(secondNum);
            while (member < 100)
            {
                thirdNum = firstNum + secondNum;
                Console.WriteLine(thirdNum);
                firstNum = secondNum;
                secondNum = thirdNum;
                member++;
            }
            
        }
    }
}
