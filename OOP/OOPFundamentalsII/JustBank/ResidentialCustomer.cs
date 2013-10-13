////
namespace JustBank
{
    using System;
    using System.Linq;

    public class ResidentialCustomer : Customer
    {
        private string personalNumber;

        public ResidentialCustomer(string name, string personalNumber) : base(name)
        {
            this.PersonalNumber = personalNumber;
        }

        public string PersonalNumber
        {
            get
            {
                return this.personalNumber;
            }

            set
            {
                this.personalNumber = value;
            }
        }
    }
}
