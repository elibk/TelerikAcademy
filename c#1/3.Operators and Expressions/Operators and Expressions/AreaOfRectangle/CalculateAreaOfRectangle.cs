using System;

class CalculateAreaOfRectangle
{
    static void Main()
    {
        Console.WriteLine("Enter rectangles's wight:");
        double width = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter rectangles's height:");
        double height = double.Parse(Console.ReadLine());
        Console.WriteLine("Rectangles's area is "+(width*height)+".");
    }
}

