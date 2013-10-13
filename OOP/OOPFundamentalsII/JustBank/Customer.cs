////
namespace JustBank
{
    using System;
    using System.Linq;

    public abstract class Customer
    {
        private string name;

        public Customer(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public override string ToString()
        {
            return GetType().Name.ToString() + " " + this.Name;
        }
    }
}
