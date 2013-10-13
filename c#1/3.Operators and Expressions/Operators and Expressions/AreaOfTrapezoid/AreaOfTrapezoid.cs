using System;

    class AreaOfTrapezoid
    {
        static void Main()
        {
            Console.WriteLine("Enter base A of trapezoid:");
            double baseA = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter base B of trapezoid:");
            double baseB = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter height of trapezoid:");
            double height = double.Parse(Console.ReadLine());

            double area = ((baseA + baseB) * height) / 0.5;

            Console.WriteLine("The area of trapezoid with basees {0} and {1}, and height {2} is {3}.", baseA, baseB, height, area);
        }
    }

