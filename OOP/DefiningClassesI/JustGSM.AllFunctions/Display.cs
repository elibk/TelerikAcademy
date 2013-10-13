////
namespace JustGSM.AllFunctions
{
    using System;
    using System.Linq;
    using System.Text;

   public class Display
    {
        private double? size;
        private string colors;

        #region constructors
        public Display()
            : this(null, null)
        {
        }

        public Display(double? size)
            : this(null, size)
        {
        }

        public Display(string colors)
            : this(colors, null)
        {
        }

        public Display(string colors, double? size)
        {
            this.Colors = colors;
            this.Size = size;
        }
        #endregion

        #region properties
        public string Colors
        {
            get { return this.colors; }
            set { this.colors = value; }
        }

        public double? Size
        {
            get { return this.size; }
            set { this.size = value; }
        }
        #endregion

        public override string ToString()
        {
            StringBuilder strBuild = new StringBuilder();

            if (this.colors != null)
            {
                strBuild.Append(this.Colors);
            }

            if (this.size != null)
            {
                strBuild.Append(String.Format("({0}-inch)", this.Size));
            }

            return strBuild.ToString();
        }
    }
}
