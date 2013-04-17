using System;

class Display
{
    private float width;
    private float height;
    private int colors;

    public float Width
    {
        get { return this.width; }
        set
        {
            if (this.width < 0)
            {
                throw new ArgumentException("width has to be non-negative");
            }
            this.width = value;
        }
    }

    public float Height
    {
        get { return this.height; }
        set
        {
            if (this.height < 0)
            {
                throw new ArgumentException("height has to be non-negative");
            }
            this.height = value;
        }
    }

    public int Colors
    {
        get { return this.colors; }
        set
        {
            if (this.colors < 0)
            {
                throw new ArgumentException("colors have to be non-negative");
            }
            this.colors = value;
        }
    }

    public Display()
    {
    }

    public Display(float width, float height)
        : this()
    {
        this.Width = width;
        this.Height = height;
    }

    public Display(int colors)
        : this()
    {
        this.Colors = colors;
    }

    public Display(float width, float height, int colors)
        : this(width, height)
    {
        this.Colors = colors;
    }
}
