using System;

class TreeIntegersSum
{
    static void Main()
    {
        Console.Write("Enter first integer num:");
        int firstInt = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter second integer num:");
        int secondNum = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter third integer num:");
        int thirdNum = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("The sum of {0},{1} and {2} is {3}.",firstInt,secondNum,thirdNum,firstInt+secondNum+thirdNum);
    }
}

