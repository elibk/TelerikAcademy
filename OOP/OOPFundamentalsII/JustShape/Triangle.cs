////
namespace JustShape
{
    using System;
    using System.Linq;

   public class Triangle : Shape
    {
       public Triangle(double height, double width)
            : base(height, width)
        {
        }

        public override double CalculateSurface()
        {
            double surface = (double)(this.Width * this.Height) / 2;
            return surface;
        }
    }
}
