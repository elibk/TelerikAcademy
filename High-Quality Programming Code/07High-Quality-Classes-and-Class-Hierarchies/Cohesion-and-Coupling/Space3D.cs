////
namespace CohesionAndCoupling
{
    using System;
    using System.Linq;

    internal class Space3D : Space2D
    {
        private double depth;

        public Space3D(double width, double height, double depth) : base(width, height)
        {
            this.Depth = depth;
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The value for 'Depth' can not be negative number.");
                }

                this.depth = value;
            }
        }

        internal static double CalcDistance(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double deltaX = x2 - x1;
            double deltaY = y2 - y1;
            double deltaZ = z2 - z1;
            double distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY) + (deltaZ * deltaZ));
            return distance;
        }

        internal double CalcVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }

        internal double CalcDiagonalXYZ()
        {
            double distance = CalcDistance(0, 0, 0, this.Width, this.Height, this.Depth);
            return distance;
        }

        internal double CalcDiagonalXZ()
        {
            double distance = CalcDistance(0, 0, this.Width, this.Depth);
            return distance;
        }

        internal double CalcDiagonalYZ()
        {
            double distance = CalcDistance(0, 0, this.Height, this.Depth);
            return distance;
        }
    }
}
