////
namespace JustPoint3D.Common
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

   public struct Point3D
    {
        private static Point3D centalPoint = new Point3D(0, 0, 0);

        public Point3D(double x, double y, double z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Point3D CentalPoint
        {
            get { return centalPoint; }          
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public override string ToString()
        {
            StringBuilder strBuild = new StringBuilder("Point(");

            strBuild.Append(string.Format(new CultureInfo("en-US"), "{0},{1},{2}", this.X, this.Y, this.Z));
            strBuild.Append(")");
            return strBuild.ToString();
        }
    }
}
