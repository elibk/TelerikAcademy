using System;

    class FindThirdBit
    {
        static void Main()
        {
            Console.WriteLine("Enter a number to find if it's thirt bit (counting from 0) is 1:");
            int num = int.Parse(Console.ReadLine());
            int checkNum = num & 8; // 8 bitwise is 0000 0000 0000 0000 0000 0000 1000
            bool result = checkNum == 8;
            Console.WriteLine("It is {0} that the thirt bit (counting from 0) of number {1} is \"1\"", result, num);
        }
    }