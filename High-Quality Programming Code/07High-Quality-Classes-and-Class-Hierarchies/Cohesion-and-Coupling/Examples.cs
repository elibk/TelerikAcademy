////
namespace CohesionAndCoupling
{
    using System;

    internal class Examples
    {
        internal static void Main()
        {
            Console.WriteLine(FileNaming.GetFileExtension("example"));
            Console.WriteLine(FileNaming.GetFileExtension("example.pdf"));
            Console.WriteLine(FileNaming.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileNaming.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileNaming.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileNaming.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}", Space2D.CalcDistance(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}", Space3D.CalcDistance(5, 2, -1, 3, -6, 4));

            Space3D testSpace = new Space3D(3, 4, 5);
            Console.WriteLine("Volume = {0:f2}", testSpace.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", testSpace.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", testSpace.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", testSpace.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", testSpace.CalcDiagonalYZ());
        }
    }
}
