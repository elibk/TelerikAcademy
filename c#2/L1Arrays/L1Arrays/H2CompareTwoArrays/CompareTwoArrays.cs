////Write a program that reads two arrays from the console and compares them element by element.

namespace H2CompareTwoArrays
{
    using System;
    using System.Linq;

    public class CompareTwoArrays
    {
       private static void Main(string[] args)
        {
            int arrayLen = 0;
            int[] firstArray, secondArray;
            Console.ForegroundColor = ConsoleColor.White;
            do
            {
                Console.Write("Enter arrays lenght:");
                int.TryParse(Console.ReadLine(), out arrayLen);
                firstArray = new int[arrayLen];
                secondArray = new int[arrayLen];
            }
            while (arrayLen == 0);

            for (int i = 0; i < arrayLen; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nElement {0} \\first array\\ =", i);
                firstArray[i] = int.Parse(Console.ReadLine());

                Console.Write("\nElement {0} \\second array\\ =", i);
                secondArray[i] = int.Parse(Console.ReadLine());

                if (firstArray[i] == secondArray[i])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Element {0} of first array is equal to element {0} of second array.", i);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Element {0} of first array isn't equal to element {0} of second array.", i);
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}