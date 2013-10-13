////
namespace JustShape
{
    using System;
    using System.Linq;

    public abstract class Shape
    {
        private double? width;
        private double? height;

        protected Shape(double? width, double? height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double? Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The value for Width should not be negative.");
                }
                
                this.width = value;
            }
        }

        public double? Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The value for Height should not be negative.");
                }
                
                this.height = value;
            }
        }

        public abstract double CalculateSurface();      
    }
}
