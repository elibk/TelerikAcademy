using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfNumbersOfDegreeAndFactorials
{
    class SumOfNumbersOfDegreeAndFactorials
    {
        static void Main()
        {
            Console.Write("Find S in S = 1 + 1!/X + 2!/X2 + … + N!/XN.\nN = ");
            int size = int.Parse(Console.ReadLine());
            Console.Write("X = ");
            int number = int.Parse(Console.ReadLine());
            int factorial = 1;
            int stepen = number;
            Console.Write("S = 1 + 1/{0}",number);
            decimal sum = 1 + 1 / number;

            for (int i = 2; i <= size ; i++)
            {
                factorial = factorial * i;
                number = number * stepen;
                sum = sum + ((decimal)factorial) /((decimal)number);
                Console.Write(" + {0}/{1}",factorial,number);
            }
            Console.WriteLine(" = {0}",sum);
        }
    }
}
