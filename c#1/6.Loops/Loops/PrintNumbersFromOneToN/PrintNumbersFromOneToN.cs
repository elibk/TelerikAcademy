using System;

class PrintNumbersFromOneToN
{
    static void Main()
    {
        Console.Write("To see numbers between 1 and N, enter N:");
        int input = int.Parse(Console.ReadLine());
        int N = 0;
        Console.WriteLine("The numbers are: ");
        while (N < input)
        {
            Console.WriteLine(++N);
        }

    }
}
