//1. Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space. Implement the ToString() to enable printing a 3D point.
//2. Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}. Add a static property to return the point O.
//3. Write a static class with a static method to calculate the distance between two points in the 3D space.
//4. Create a class Path to hold a sequence of points in the 3D space. Create a static class PathStorage with static methods to save and load paths from a text file. Use a file format of your choice.


using System;
using System.Collections.Generic;

class test
{
    static void Main()
    {
        Point3D point1 = new Point3D(2, 3, 8);
        Console.WriteLine(point1);
        Console.WriteLine(Point3D.Point0);
        
        double distance = TwoPointsDistance.CalcTwoPointsDistance(new Point3D(-7,5,2), new Point3D(5,-12,6));
        Console.WriteLine(distance);

        Path sequence = new Path();
        sequence.AddPointToSequence(point1);

        List<Path> paths = PathStorage.PathLoad();
        foreach (var item in paths)
        {
            PathStorage.PathSave(item);
        }
        
    }
}
