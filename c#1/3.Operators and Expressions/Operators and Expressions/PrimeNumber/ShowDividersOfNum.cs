//Show dividers of number

using System;

class PrimeNumber
{
    static void Main()
    {
        Console.WriteLine("Еnter positive integer number:");
        int num = int.Parse(Console.ReadLine());
        int divider = 1;
        int check ;
 
        while (divider < Math.Sqrt(num))
        {
            divider ++;
            check = num % divider;
            if (check == 0)
            {
                Console.WriteLine("Divider {0}",divider);
            }

        }
        Console.WriteLine("DIDN'T SEE ANY DIVIDER? YOUR NUBER IS PRIME.");
    }
}
