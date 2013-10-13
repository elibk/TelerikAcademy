////
namespace JustShape
{
    using System;
    using System.Linq;

    public class Rectangle : Shape
    {
        public Rectangle(double height, double width) : base(height, width)
        { 
        }

        public override double CalculateSurface()
        {
            double surface = (double)(this.Width * this.Height);
            return surface;
        }
    }
}