using System;

class ForestRoad
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        string Geeko = "*";

        for (int dotsLeft = 0, dotsRight = N - 1; dotsLeft < N; dotsLeft++, dotsRight--)
        {
            Console.WriteLine(new string ('.' ,dotsLeft) + Geeko + new string('.', dotsRight));
        }
        for (int dotsLeft = N - 2, dotsRight = 1; dotsRight < N; dotsLeft--, dotsRight++)
        {
            Console.WriteLine(new string ('.' ,dotsLeft) + Geeko + new string('.', dotsRight));
        }
    }
}

