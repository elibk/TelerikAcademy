////
namespace JustPoint3D.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Path 
    {
      internal readonly List<Point3D> SequenceOfPoints = new List<Point3D>();

      public Path()
      {
      }

      public void AddPoint(Point3D point)
      {
          this.SequenceOfPoints.Add(point);
      }

      public override string ToString()
      {
          StringBuilder path = new StringBuilder("/");

          for (int i = 0; i < this.SequenceOfPoints.Count; i++)
          {
              path.Append(this.SequenceOfPoints[i] + "/");
          }

          return path.ToString();
      }
    }
}
