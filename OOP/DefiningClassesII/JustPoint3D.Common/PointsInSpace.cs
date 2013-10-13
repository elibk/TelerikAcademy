////
namespace JustPoint3D.Common
{
    using System;
    using System.Linq;

   public static class PointsInSpace
    {
       public static double CalculateTheDistanceBetweenTwoPoints(Point3D firstPoint, Point3D secondPoint)
       {
           double distance = new double();
           double distanceX = firstPoint.X - secondPoint.X;
           double distanceY = firstPoint.Y - secondPoint.Y;
           double distanceZ = firstPoint.Z - secondPoint.Z;

           distance = Math.Sqrt((distanceX * distanceX) + (distanceY * distanceY) + (distanceZ * distanceZ));

           return distance;
       }
    }
}
