using System;

namespace Abstraction
{
    class Rectangle : Figure
    {
        private const double DimensionMinValue = 0;

        private double width { get; set; }
        private double height { get; set; }

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
                this.height = value;
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

        public Rectangle()
        {
        }

        public Rectangle(double width, double height)
            : this()
        {
            this.Width = width;
            this.Height = height;
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

        public override double CalcPerimeter()
        {
            double perimeter = 2 * this.Width + 2 * this.Height;
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
