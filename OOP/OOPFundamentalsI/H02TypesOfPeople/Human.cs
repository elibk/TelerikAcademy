////
namespace H02TypesOfPeople
{
    using System;
    using System.Linq;

    public abstract class Human
    {
        private string firstName;
        private string secondName;

        public Human(string firstName, string secondName)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.firstName = value;
            }
        }

        public string SecondName
        {
            get
            {
                return this.secondName;
            }

            set
            {
                this.secondName = value;
            }
        }
    }
}
