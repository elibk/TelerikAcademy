using System;

class AreaAndPerimeterOfCircle
{
    static void Main()
    {
        Console.Write("Enter a circle's radius:");
        double radius = Convert.ToDouble(Console.ReadLine());
        double pi = 3.1415926;
        Console.Write("Area of the circle with radius {0} is {1:F2}.",radius,pi*radius*radius);
        Console.WriteLine("It's's perimeter is {0:F2}.",2d*pi*radius );
    }
}