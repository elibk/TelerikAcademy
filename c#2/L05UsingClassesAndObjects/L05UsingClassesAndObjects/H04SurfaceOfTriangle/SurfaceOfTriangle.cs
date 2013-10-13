using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H04SurfaceOfTriangle
{
    class SurfaceOfTriangle
    {
        static void Main(string[] args)
        {
            double sideA = 5,
                   sideB = 3.2,
                   sideC = 2.2,
                   altitude =  1;
                

            int angle = 18;

            double S = new double ();
            S = FindSurface(sideA, altitude);
            Console.WriteLine(S);
            S = FindSurface(sideA,sideB,sideC);
            Console.WriteLine(S);
            S = FindSurface(sideA, sideB, angle);
            Console.WriteLine(S);
            
        }

        private static double FindSurface(double side, double altitude)
        {
            double S = (side * altitude) / 2;
            return S;
        }
        private static double FindSurface(double sideA, double sideB, double sideC)
        {
            double P = (sideA + sideB + sideC)/2;
            double S = Math.Sqrt(P*(P-sideA)*(P-sideB)*(P-sideC));
            return S;
        }
        private static double FindSurface(double sideA, double sideB, int angle)
        {
            double doubleAngle = (angle* Math.PI)/180;
            double S = (sideA * sideB * Math.Sin(doubleAngle)) / 2;
            return S;
        }
    }
}
