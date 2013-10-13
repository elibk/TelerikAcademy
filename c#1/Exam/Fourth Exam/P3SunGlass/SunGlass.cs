using System;

class SunGlass
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        for (int dotsLeft = 0, stars = N, dotsRight = 0; stars >0; dotsLeft++, stars-=2, dotsRight++)
        {
            Console.WriteLine(new string ('.',dotsLeft) + new string ('*',stars) + new string ('.',dotsRight));
        }
        for (int dotsLeft = N / 2 -1, stars = 3, dotsRight = N / 2 -1; stars <= N; dotsLeft--, stars += 2, dotsRight--)
        {
            Console.WriteLine(new string('.', dotsLeft) + new string('*', stars) + new string('.', dotsRight));
        }
    }
}

