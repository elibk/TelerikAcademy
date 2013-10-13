using System;

    class DeclareHex
    {
        static int entredNum;
        static void Main()
        
        {
            Console.WriteLine("Enter number to get it's hexademicam value:");
            entredNum = int.Parse(Console.ReadLine());
            Console.WriteLine("This is it's hexademicam representive: {0:X}", entredNum);
        }
    }
