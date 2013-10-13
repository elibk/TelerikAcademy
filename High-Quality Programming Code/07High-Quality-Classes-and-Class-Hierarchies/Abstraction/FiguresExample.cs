////

namespace Abstraction
{
    using System;

    internal class FiguresExample
    {
        internal static void Main()
        {
            Figure circle = new Circle(5);
            Console.WriteLine(circle);
            Figure rect = new Rectangle(2, 3);
            Console.WriteLine(rect);
        }
    }
}
