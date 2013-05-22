using System;

class TriangleSurface
{
    static void Main()
    {
        double side1 = 5;
        double side2 = 5;
        double side3 = 5;
        double altiduteToSide1 = 7;
        double angle = 30;
        SurfaceBySideAndAltitude(side1, altiduteToSide1);
        SurfaceByThreeSides(side1, side2, side3);
        SurfaceByTwoSidesAndAngleBetween(side1, side2, angle);
    }

    static void SurfaceBySideAndAltitude(double a, double h)
    {
        double s = (a * h) / 2;
        Console.WriteLine(s);
    }

    static void SurfaceByThreeSides(double a, double b, double c)
    {
        double p = (a + b + c)/2;
        double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        Console.WriteLine(s);
    }

    static void SurfaceByTwoSidesAndAngleBetween(double a, double b, double ang)
    {
        double s = (a * b * Math.Sin(ang*Math.PI/180)) / 2;
        Console.WriteLine(s);
    }

}
