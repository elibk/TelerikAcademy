using System;

class FirTree
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        for (int dotsLeft = N - 2, characters = 1, dotsRight = N - 2; dotsLeft >= 0; dotsLeft--, dotsRight--, characters = characters + 2)
        {
            Console.WriteLine(new string ('.',dotsLeft) + new string ('*',characters) + new string ('.',dotsRight));
        }
        Console.WriteLine(new string('.', N - 2) + '*' + new string('.', N - 2));
    }
}

