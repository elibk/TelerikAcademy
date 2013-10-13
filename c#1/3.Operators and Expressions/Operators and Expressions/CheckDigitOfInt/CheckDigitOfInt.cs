using System;

    class CheckDigitOfInt
    {
        static void Main()
        {
            Console.WriteLine("Enter num:");
            int num = int.Parse(Console.ReadLine());
            double numChek = ((double)num) / 1000;
            int numChek2 = (int)numChek;
            int finalChek = (int)((numChek - numChek2) * 10);
            bool chek = finalChek == 7;
            Console.WriteLine("It is {0}, that third digit (right-to-left) of number {1} is 7.",chek,num );
        }
    }

