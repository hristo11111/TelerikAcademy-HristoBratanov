using System;

class Triangle : Shape
{
    public Triangle(float width, float height)
    {
        this.Width = width;
        this.Height = height;
    }

    public override float CalculateSurface()
    {
        return ((this.Height * this.Width) / 2);
    }
}
