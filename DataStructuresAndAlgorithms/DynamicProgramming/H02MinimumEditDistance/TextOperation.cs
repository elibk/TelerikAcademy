using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H02MinimumEditDistance
{
   internal class TextOperation : IComparable<TextOperation>, IComparable
    {
        public double PermanenetCost { get; set; }
        public double Cost { get; set; }
        public TextOperation(double permanenetCost, double cost)
        {
            this.PermanenetCost = permanenetCost;
            this.Cost = cost;
        }

        public int CompareTo(object obj)
        {
            return this.CompareTo(obj as TextOperation);
        }

        public int CompareTo(TextOperation other)
        {
            int check = this.Cost.CompareTo(other.Cost);

            if (check == 0)
            {
                check = this.PermanenetCost.CompareTo(other.PermanenetCost);
            }

            return check;
        }
    }
}
