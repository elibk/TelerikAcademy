////
namespace JustPoint3D.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    
   public static class PathStorage
    {

       public static void FillStorage(Path sequence, string path)
       {
           StreamWriter writer = new StreamWriter(path, true, Encoding.GetEncoding("UTF-8"));

           using (writer)
           {
                writer.Write(sequence);
                writer.Write(Environment.NewLine);
           }
       }

      public static void FillStorage(List<Path> sequence, string path)
       {      
           StreamWriter writer = new StreamWriter(path, true, Encoding.GetEncoding("UTF-8"));

           using (writer)
           {
               for (int i = 0; i < sequence.Count; i++)
               {
                   writer.Write(sequence[i]);
                   writer.Write(Environment.NewLine);
               }
           }          
       }

      public static List<Path> LoadStorage(string path)
      {
          List<Path> storage = new List<Path>();
          StreamReader reader = new StreamReader(path, Encoding.GetEncoding("UTF-8"));

          using (reader)
          {
              string line = reader.ReadLine();
              while (line != null)
              {
                  ReadPath(line);

                  storage.Add(ReadPath(line));
                  line = reader.ReadLine();
              }
          }

          return storage;
      }

       //// using automats
      private static Path ReadPath(string sequence)
      {
          StringBuilder numberGetter = new StringBuilder();
          bool inPoint3D = false;
          Path path = new Path();
          byte countCordinats = new byte();
          Point3D point = new Point3D();

          for (int symbol = 0; symbol < sequence.Length; symbol++)
          {
              if (sequence[symbol] == '(')
              {
                  inPoint3D = true;
                  point = new Point3D();
              }
              else if (sequence[symbol] == ')')
              {
                  inPoint3D = false;
                  point.Z = double.Parse(numberGetter.ToString(), NumberStyles.Any,  NumberFormatInfo.InvariantInfo);
                  countCordinats = 0;
                  path.AddPoint(point);
                  numberGetter.Clear();
              }
              else if (inPoint3D)
              {
                  if (sequence[symbol] == ',')
                  {
                      switch (countCordinats)
                      {
                          case 0:
                              point.X = double.Parse(numberGetter.ToString(), NumberStyles.Any, NumberFormatInfo.InvariantInfo);
                              break;
                          case 1:
                              point.Y = double.Parse(numberGetter.ToString(), NumberStyles.Any, NumberFormatInfo.InvariantInfo);
                              break;
                                                        
                          default: Console.WriteLine("FAIL");
                              break;
                      }
                      
                      countCordinats++;
                      numberGetter.Clear();
                  }
                  else
                  {
                      numberGetter.Append(sequence[symbol]);
                  }
              }
          }
               
         return path;
      }
    }
}
