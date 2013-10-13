using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H02PointChecker
{
    public class PointChecker
    {
        private double CalculateArea(Point a, Point b, Point c) 
        {
            return Math.Abs((a.X * (b.Y - c.Y) + b.X * (c.Y - a.Y) + c.X * (a.Y - b.Y)) / 2.0);
        }

        public bool IsPointWithinTriangle(Point a, Point b, Point c, Point point)
        {
            /* Calculate area of triangle ABC */
            double A = CalculateArea(a, b, c);

            /* Calculate area of triangle PBC */
            double A1 = CalculateArea(point, b, c);

            /* Calculate area of triangle PAC */
            double A2 = CalculateArea(a, point, c);

            /* Calculate area of triangle PAB */
            double A3 = CalculateArea(a, b, point);

            /* Check if sum of A1, A2 and A3 is same as A */
            return (A == A1 + A2 + A3);

        }

    }
}
