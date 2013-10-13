using System;

class NumbersNotDivisibleBy3And7 
{
    static void Main()
    {
        Console.Write("To see numbers between 1 and N, that are not divisible by 3 and 7 at the same time, enter N:");
        int input = int.Parse(Console.ReadLine());
        int n = 0;
        Console.WriteLine("The numbers are: ");
        while (n < input)
        {
            ++n;
            if (n % 3 != 0 && n % 7 != 0)
            {
                Console.WriteLine(n);
            }
        }
    }
}

