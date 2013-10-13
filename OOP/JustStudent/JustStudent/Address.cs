using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustStudent
{
    public class Address
    {
       private string country;
       private string street;
       private string streetNum;

        public Address(string country, string street, string streetNum)
        {
            this.Country = country;
            this.Street = street;
            this.StreetNum = streetNum;
        }

        public string Country
        {
            get
            {
                return this.country;
            }
            set
            {
                this.country = value;
            }
        }

        public string Street
        {
            get
            {
                return this.street;
            }
            set
            {
                this.street = value;
            }
        }

        public string StreetNum
        {
            get
            {
                return this.streetNum;
            }
            set
            {
                this.streetNum = value;
            }
        }
    }
}
