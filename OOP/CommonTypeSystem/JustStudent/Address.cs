////
namespace JustStudent
{
    using System;
    using System.Linq;
    using System.Text;

    public class Address : ICloneable
    {
        private string country;
        private string town;
        private string street;
        private int streetNum;

        public Address(string country, string town, string street, int streetNum)
        {
            this.Country = country;
            this.Town = town;
            this.Street = street;
            this.StreetNum = streetNum;
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            set
            {
                this.town = value;
            }
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

        public int StreetNum
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

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.Append(this.Country + " " + this.Town);
            info.Append(Environment.NewLine);
            info.Append(this.Street + " " + this.StreetNum);
            
            return info.ToString();
        }

        public object Clone()
        {
            Address newAddress = new Address(this.Country, this.Town, this.Street, this.StreetNum);
            return newAddress;
        }
    }
}
