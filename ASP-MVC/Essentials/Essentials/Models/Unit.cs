using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Essentials.Models
{
    public class Unit : Essentials.Models.IUnit
    {
        public int PowerOfTen { get; set; }
        public int PowerOfTwo { get; set; }
        public string Prefix { get; set; }
        public bool IsBit { get; set; }
        public string UnitInitials { get; set; }
        public decimal Quantity { get; set; }


        public override string ToString()
        {
            return string.Format("{0}{1} - {2}", 
                            this.Prefix, (this.IsBit ? (this.Prefix != string.Empty ? "bit" : "Bit") 
                            : (this.Prefix != string.Empty ? "byte" : "Byte")), this.UnitInitials);
        }
    }
}