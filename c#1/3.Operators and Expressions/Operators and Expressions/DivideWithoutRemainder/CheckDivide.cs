using System;

    class CheckDivide
    {
        static void Main()
        {
            Console.WriteLine("Enter number for which you want to check is it true that you can divide it (without remainer) with 5 and 7 at the same time:");
            int num = int.Parse(Console.ReadLine());
            bool chek = (num % 5 == 0 && num % 7 == 0);
            Console.WriteLine(chek);
        }
    }
