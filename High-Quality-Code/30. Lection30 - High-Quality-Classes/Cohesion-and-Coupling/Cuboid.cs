using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CohesionAndCoupling
{
    public class Cuboid
    {
        private const double DimensionMinValue = 0;

        private double width;
        private double height;
        private double depth;

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

        public double Depth
        {
            get
            {
                return this.depth;
            }
            set
            {
                this.depth = value;
                if (IsValidDimension(value))
                {
                    this.depth = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("depth", string.Format
                        ("depth should be between {0} and {1} inclusive.", DimensionMinValue, double.MaxValue));
                }
            }
        }

        public Cuboid()
        {
        }

        public Cuboid(double width, double height, double depth)
            : this()
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
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
}
