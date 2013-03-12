using System;

abstract class Shape
{
    public float Width { get; set; }
    public float Height { get; set; }

    public abstract float CalculateSurface();
}
