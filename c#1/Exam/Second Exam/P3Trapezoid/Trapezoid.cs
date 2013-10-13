using System;

class Trapezoid
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        string top = new string('.', N) + new string('*', N);
        string bottom = new string('*', 2 * N);

        Console.WriteLine(top);
        for (int dotsLeft = N - 1, dotsRight = N - 1; dotsLeft > 0; dotsLeft--, dotsRight++)
        {
            
            Console.WriteLine(new string ('.',dotsLeft)+'*' + new string ('.',dotsRight)+'*');
           
        }
        Console.WriteLine(bottom);
    }
}

