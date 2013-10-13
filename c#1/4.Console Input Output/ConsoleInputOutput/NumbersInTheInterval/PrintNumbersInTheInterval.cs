using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersInTheInterval
{
    class PrintNumbersInTheInterval
    {
        static void Main(string[] args)
        {
            Console.Write("Enter integer number:");
            int num = Convert.ToInt32(Console.ReadLine());
            int numInterval = 0;
            Console.WriteLine("This are the numbers in the interval 1 to {0}: ",num);
            do
            {
                numInterval++;
                Console.WriteLine(" " + numInterval);
            } 
            while (num > numInterval );
        }
    }
}
