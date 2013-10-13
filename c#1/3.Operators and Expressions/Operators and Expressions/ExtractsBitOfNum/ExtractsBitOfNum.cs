using System;

class ExtractsBitOfNum
{
    static void Main()
    {
        Console.WriteLine("Enter number:");
        int num = int.Parse(Console.ReadLine());
        int position = 3;
        int putOne = 1 << position;
        int result = num & putOne;
        int bitValue = result >> position;

        Console.WriteLine("The third bit (countinf from 0) of {0} is \"{1}\".", num,bitValue);
    }
}

