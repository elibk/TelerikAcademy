////

namespace CohesionAndCoupling
{
    using System;

    internal class Space2D
    {
        private double width;
        private double height;
        
        public Space2D(double width, double height) 
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
                if (value < 0)
                {
                    throw new ArgumentException("The value for 'Width' can not be negative number.");
                }

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
                if (value < 0)
                {
                    throw new ArgumentException("The value for 'Height' can not be negative number.");
                }

                this.height = value;
            }
        }

        internal static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double deltaX = x2 - x1;
            double deltaY = y2 - y1;
            double distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
            return distance;
        }

        internal double CalcDiagonalXY()
        {
            double distance = CalcDistance(0, 0, this.Width, this.Height);
            return distance;
        }
    }
}
