//Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.

using System;

class MinAndMax
{
    static void Main(string[] args)
    {
        Console.WriteLine("Arrey's size:");
        int arreySize = int.Parse(Console.ReadLine());
        int[] arrey = new int[arreySize];
        int min, max;

        Console.Write("Value:");
        arrey[0] = int.Parse(Console.ReadLine());
        min = max = arrey[0];

        for (int i = 1; i < arrey.Length; i++)
        {
            Console.Write("Value:");
            arrey[i] = int.Parse(Console.ReadLine());
            if (min > arrey[i])
            {
                min = arrey[i];
            }
            else if (max < arrey[i])
            {
                max = arrey[i];
            }
        }

        Console.WriteLine("The minimal value is {0} and the maximum is {1}.", min, max);
    }
}
