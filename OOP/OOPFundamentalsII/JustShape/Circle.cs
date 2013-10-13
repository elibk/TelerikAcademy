////
namespace JustShape
{
    using System;
    using System.Linq;

    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius) : base(null, null)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The value for Radius should not be negative.");
                }

                this.radius = value;
            }
        }

        private new double Height
        {
            get
            {
                return this.Height;
            }

            set
            {
                this.Height = value;
            }
        }

        private new double Width
        {
            get
            {
                return this.Width;
            }

            set
            {
                this.Width = value;
            }
        }

        public override double CalculateSurface()
        {
            double surface = Math.PI * this.radius;
            return surface;
        }
    }
}
