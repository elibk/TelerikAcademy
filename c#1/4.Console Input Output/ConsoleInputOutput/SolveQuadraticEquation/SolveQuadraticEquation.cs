using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveQuadraticEquation
{
    class SolveQuadraticEquation
    {
        static void Main()
        {
            double a = Convert.ToDouble(Console.ReadLine());
            double b = Convert.ToDouble(Console.ReadLine()); ;
            double c = Convert.ToDouble(Console.ReadLine()); ;
            double x1, x2;

            if (b * b - 4 * a * c > 0)
            {

                x1 = (b * b + Math.Sqrt(4 * a * c)) / (2 * a);
                Console.WriteLine("x1 = {0}", x1);
                x2 = (b * b - Math.Sqrt(4 * a * c)) / (2 * a);
                Console.WriteLine("x2 = {0}", x2);
            }
            
            else
            {
                if (b * b - 4 * a * c < 0)
                {

                    Console.WriteLine("The ecuation doesn't have real roots!");
                }

                if (a == 0 && b == 0 && c == 0)
                {
                    Console.WriteLine("Every real number can be root of the ecuation!");
                }

                if (a == 0 && b != 0)
                {
                    x1 = -c / b;
                    Console.WriteLine(" x = {0}", x1);
                }

                if (a == 0 && b == 0 && c != 0)
                {
                    Console.WriteLine("The ecuation doesn't have solvetion!");
                }
            }
        }
    }
}
