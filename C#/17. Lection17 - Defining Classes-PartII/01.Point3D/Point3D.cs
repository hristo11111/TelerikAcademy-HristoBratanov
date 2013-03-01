using System;

public struct Point3D
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public Point3D(float x, float y, float z) : this()
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    public static Point3D Point0
    {
        get
        {
            return new Point3D(0, 0, 0);
        }
    }


    public override string ToString()
    {
        return string.Format("Point({0}, {1}, {2})", this.X, this.Y, this.Z);
    }

}
