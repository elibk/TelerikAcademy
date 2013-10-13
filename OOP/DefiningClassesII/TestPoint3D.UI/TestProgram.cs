////
namespace TestPoint3D.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using JustPoint3D.Common;

   public class TestProgram
    {
       private static void Main(string[] args)
        {           
            Point3D point = new Point3D(2.3, 456, 2);
            Point3D pointSecond = new Point3D(1, 1, 1);
            Console.WriteLine(Point3D.CentalPoint);

            Console.WriteLine(PointsInSpace.CalculateTheDistanceBetweenTwoPoints(pointSecond, Point3D.CentalPoint)); 

            List<Path> paths = new List<Path>();
            Point3D pointOther = new Point3D(2.3, 456, -2);

            Path sequence = new Path();

            sequence.AddPoint(point);
            sequence.AddPoint(pointSecond);
            sequence.AddPoint(pointOther);

            paths.Add(sequence);
            paths.Add(sequence);
            paths.Add(sequence);

            PathStorage.FillStorage(sequence, ".../.../Point3DPaths.txt");
            PathStorage.FillStorage(paths, ".../.../Point3DPaths.txt");
            paths = PathStorage.LoadStorage(".../.../Point3DPaths.txt");

            for (int i = 0; i < paths.Count; i++)
            {
                Console.WriteLine(paths[i]);
            }
        }
    }
}
