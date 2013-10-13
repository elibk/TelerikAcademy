////
namespace H01Sizes
{
    using System;
    using System.Linq;

    public class Size
    {
        private double width, height;

        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                this.height = value;
            }
        }

        private Size GetRotatedSize(Size size, double sizeAngle)
        {
            double rotatedWidth = (Math.Abs(Math.Cos(sizeAngle)) * size.Width) + (Math.Abs(Math.Sin(sizeAngle)) * size.Height);
            double ratatedHeight = (Math.Abs(Math.Sin(sizeAngle)) * size.Width) + (Math.Abs(Math.Cos(sizeAngle)) * size.Height);

            return new Size(rotatedWidth, ratatedHeight);
        }
    }
}
