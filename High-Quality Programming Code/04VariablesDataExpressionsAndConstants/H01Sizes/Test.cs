////
namespace H01Sizes
{
    using System;
    using System.Linq;

   internal class Test
    {
        private static Size GetRotatedSize(Size size, double sizeAngle)
        {
            double rotatedWidth = (Math.Abs(Math.Cos(sizeAngle)) * size.Width) + (Math.Abs(Math.Sin(sizeAngle)) * size.Height);
            double ratatedHeight = (Math.Abs(Math.Sin(sizeAngle)) * size.Width) + (Math.Abs(Math.Cos(sizeAngle)) * size.Height);

            return new Size(rotatedWidth, ratatedHeight);
        }

        private static void Main(string[] args)
        {
        }
    }
}
