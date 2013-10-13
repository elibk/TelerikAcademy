////
namespace JustShapeTest
{
    using System;
    using System.Linq;
    using JustShape;

   public class Test
    {
       private static void Main(string[] args)
        {
            Shape[] shapes = { new Rectangle(5.5, 10), new Triangle(5.5, 10), new Circle(5.5) };

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.GetType().Name);
                Console.WriteLine("Surface: " + shape.CalculateSurface());
            }
        }
    }
}
