////
namespace StaffEvaluation.Common
{
    using System;
    using System.Linq;
    using System.Text;

    public class Person : IPerson, ITableable
    {
        private static readonly byte MinAge = 18;
        private static readonly byte MaxAge = 120;
        private static readonly int NameMinLenght = 2;
        private string firstName;
        private string lastName;
        private byte age;
        
        public Person(string firstName, string lastName, byte age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }
      
        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            protected set
            {
                if (value.Length < NameMinLenght)
                {
                    throw new EvaluationSystemException("Value for FirstName should contain no less than " + NameMinLenght + "charecters.", new ArgumentException());
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            protected set
            {
                if (value.Length < NameMinLenght)
                {
                    throw new EvaluationSystemException("Value for FirstName should contain no less than " + NameMinLenght + "charecters.", new ArgumentException());
                }

                this.lastName = value;
            }
        }

        public byte Age
        {
            get
            {
                return this.age;
            }

            protected set
            {
                if (value < MinAge || value > MaxAge)
                {
                    throw new EvaluationSystemException(String.Format("Value should be in the range [{0}:{1}].", MinAge, MaxAge), new ArgumentOutOfRangeException());
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.Append(this.FirstName);
            info.Append("|");
            info.Append(this.LastName);
            info.Append("|");
            info.Append(this.Age);
            info.Append("|");

            return info.ToString();
        }

        public virtual string ToTableView()
        {
            StringBuilder info = new StringBuilder();
            info.AppendFormat("|{0,15}|{1,15}|{2,3}", this.FirstName, this.LastName, this.Age);
            return info.ToString();
        }
    }
}
