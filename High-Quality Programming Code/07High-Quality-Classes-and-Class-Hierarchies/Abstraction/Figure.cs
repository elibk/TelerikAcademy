////
namespace Abstraction
{
    using System;
    using System.Text;

   internal abstract class Figure
    {
        public abstract double GetPerimeter();

        public abstract double GetSurface();

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("I am a ");
            result.Append(this.GetType().Name.ToLower());
            result.Append(". ");
            result.Append(string.Format("My perimeter is {0:f2}. ", this.GetPerimeter()));
            result.Append(string.Format("My surface is {0:f2}.", this.GetSurface()));

            return result.ToString();
        }
    }
}
