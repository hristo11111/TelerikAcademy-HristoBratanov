using System;

namespace CohesionAndCoupling
{
    class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileExtension("example.cs"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                GeometryUtils2D.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                GeometryUtils3D.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Cuboid cuboid = new Cuboid(3, 4, 5);
            Console.WriteLine("Volume = {0:f2}", GeometryUtils3D.CalcVolume(cuboid.Width, cuboid.Height, cuboid.Depth));
            Console.WriteLine("Diagonal XYZ = {0:f2}", GeometryUtils3D.CalcDiagonalXYZ(cuboid.Width, cuboid.Height, cuboid.Depth));
            Console.WriteLine("Diagonal XY = {0:f2}", GeometryUtils2D.CalcDiagonalXY(cuboid.Width, cuboid.Height));
            Console.WriteLine("Diagonal XZ = {0:f2}", GeometryUtils2D.CalcDiagonalXZ(cuboid.Width, cuboid.Depth));
            Console.WriteLine("Diagonal YZ = {0:f2}", GeometryUtils2D.CalcDiagonalYZ(cuboid.Depth, cuboid.Height));
        }
    }
}
