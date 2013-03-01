using System;

static class TwoPointsDistance
{
    static public double CalcTwoPointsDistance(Point3D point1, Point3D point2)
    {
        double xd = point1.X - point2.X;
        double yd = point1.Y - point2.Y;
        double zd = point1.Z - point2.Z;
        double distance = Math.Sqrt(xd * xd + yd * yd + zd * zd);
        return distance;
    }
}
