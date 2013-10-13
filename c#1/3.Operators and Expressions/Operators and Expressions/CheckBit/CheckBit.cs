using System;

class CheckBit
{
    static void Main()
    {
        Console.WriteLine("Enter number:");
        int num = int.Parse(Console.ReadLine());
        int position = 3;
        int putOne = 1 << position;
        int result = num & putOne;
        int final = result >> position;
        bool statment = final==1;

        Console.WriteLine("It is {0} that thirt bit of {1} is 1.",statment,num);
    }
}
