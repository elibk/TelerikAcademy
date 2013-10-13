////
namespace StaffEvaluation.Common
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Client : Person
    {
        private static readonly string EmailPattern = @"\b[A-Z0-9a-z._%+-]+@[A-Z0-9a-z.-]+\.[A-Za-z]{2,4}\b";
        private string email;
        
        public Client(byte age, string email, string firstName = "NA", string lastName = "NA") : base(firstName, lastName, age)
        {
            this.Email = email;
        }

        public string Email
        {
            get
            {
                return this.email;
            }

            private set
            {
                if (Regex.IsMatch(value, EmailPattern))
                {
                    this.email = value;
                    return;
                }

                throw new EvaluationSystemException("Invalid value for 'Email'", new ArgumentException());
            }
        }

        public override string ToString()
        {
            return base.ToString() + this.Email + "|";
        }
    }
}
