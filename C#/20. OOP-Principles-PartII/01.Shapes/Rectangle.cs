using System;

class Rectangle : Shape
{
    public Rectangle(float width, float height)
    {
        this.Width = width;
        this.Height = height;
    }

    public override float CalculateSurface()
    {
        return Width * Height;
    }
}

