using System;

class Circle : Shape
{
    public Circle(float radius)
    {
        this.Width = radius;
        this.Height = radius;
    }

    public override float CalculateSurface()
    {
        return (float)(2 * Math.PI * Width * Width);
    }
}
