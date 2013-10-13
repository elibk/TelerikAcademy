using System;
using System.Numerics;

    class FibonacciSequence
    {
        static void Main()
        {
            Console.Write("To see first N numbers from Fibonacci sequence. N = ");
            int n = int.Parse(Console.ReadLine());
            BigInteger firstMember = 0;
            BigInteger secondMember = 1;
            BigInteger thirdMember = 0;

            if (n >= 1)
            {
                Console.WriteLine(firstMember);
                if (n >= 2)
                {
                    Console.WriteLine(secondMember);
                }
            }
            for (int i = 2; i < n; i++)
            {
                thirdMember = firstMember + secondMember;
                Console.WriteLine(thirdMember);
                firstMember = secondMember;
                secondMember = thirdMember;
            }
        }
    }
