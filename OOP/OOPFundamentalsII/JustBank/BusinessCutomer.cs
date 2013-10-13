////
namespace JustBank
{
    using System;
    using System.Linq;

    public class BusinessCutomer : Customer
    {
      private string responsiblePerson;
      private string bulstat;

        public BusinessCutomer(string name, string responsiblePerson, string bulstat) : base(name)
        {
            this.ResponsiblePerson = responsiblePerson;
            this.bulstat = bulstat;
        }

        public string ResponsiblePerson
        {
            get
            {
                return this.responsiblePerson;
            } 

            set
            {
                this.responsiblePerson = value;
            }
        }

        public string Bulstat
        {
            get
            {
                return this.bulstat;
            }

            set
            {
                this.bulstat = value;
            }
        }
    }
}
