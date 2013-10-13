using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H02PointChecker
{
    public struct Point
    {
        public double Y { get; set; }
        public double X { get; set; }

        public Point(double x, double y) : this()
        {
            this.Y = y;
            this.X = x;
        }
    }
}
