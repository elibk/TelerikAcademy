using System;

class CheckEvenOrOdd
{
    static void Main()
    {
        Console.WriteLine("Enter number which you want to check if it is even or odd:");
        int num = int.Parse(Console.ReadLine());
        int chek = num % 2;
        Console.WriteLine(chek);
        if (chek == 0)
        {
            Console.WriteLine("Number {0} is odd.", num);
        }
        else
        {
            Console.WriteLine("Number {0} is even.", num);
        }
    }
}

