using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GCD
{
    static void Main()
    {
        Console.Write("To find GCD of two natural numbers, enter first number = ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter second number = ");
        int b = int.Parse(Console.ReadLine());

        while (a!=b)
        {
            if (a > b)
            {
                a = a - b;
            }
            else
            {
                b = b - a;
            }
        }
        Console.WriteLine("The greatest common division is "+a);

    }
}

