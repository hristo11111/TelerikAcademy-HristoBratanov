using System;
using System.Linq;

public class Figure
{
    private const double DimensionMinValue = 0;

    private double width;
    private double height;

    public double Width
    {
        get
        {
            return this.width;
        }
        set
        {
            this.width = value;
            if (IsValidDimension(value))
            {
                this.width = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("width", string.Format
                    ("width should be between {0} and {1} inclusive.", DimensionMinValue, double.MaxValue));
            }
        }
    }

    public double Height
    {
        get
        {
            return this.height;
        }
        set
        {
            if (IsValidDimension(value))
            {
                this.height = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("height", string.Format
                    ("height should be between {0} and {1} inclusive.", DimensionMinValue, double.MaxValue));
            }
        }
    }

    public Figure(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    public static Figure GetRotatedFigure(Figure figure, double rotatedFigureAngle)
    {
        double width;
        double height;

        width = Math.Abs(Math.Cos(rotatedFigureAngle)) * figure.width +
            Math.Abs(Math.Sin(rotatedFigureAngle)) * figure.height;
        height = Math.Abs(Math.Sin(rotatedFigureAngle)) * figure.width +
            Math.Abs(Math.Cos(rotatedFigureAngle)) * figure.height;

        Figure rotatedFigure = new Figure(width, height);

        return rotatedFigure;
    }

    private bool IsValidDimension(double dimension)
    {
        bool isValid;

        if (dimension <= DimensionMinValue)
        {
            isValid = false;
        }
        else
        {
            isValid = true;
        }

        return isValid;
    }
}



