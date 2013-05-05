using System;

namespace Abstraction
{
    class Circle : Figure
    {
        private const double DimensionMinValue = 0;

        private double radius;

        public double Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                this.radius = value;
                if (IsValidDimension(value))
                {
                    this.radius = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("radius", string.Format
                        ("radius should be between {0} and {1} inclusive.", DimensionMinValue, double.MaxValue));
                }
            }
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

        public Circle()
        {
        }

        public Circle(double radius) : this()
        {
            this.Radius = radius;
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
