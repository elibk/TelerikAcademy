////
namespace H03040506LambdaAndLINQ
{
    using System;
    using System.Linq;
    using System.Text;

   public class Student
    {
        private string firstName;
        private string lastName;
        private sbyte age;

        public Student(string firstName, string lastName, sbyte age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        #region Properties
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

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                this.lastName = value;
            }
        }

        public sbyte Age
        {
            get
            {
                return this.age;
            }

            set
            {
                this.age = value;
            }
        }
        #endregion

        public override string ToString()
        {
            StringBuilder studentInfo = new StringBuilder();

            studentInfo.Append(this.FirstName);
            studentInfo.Append(" ");
            studentInfo.Append(this.LastName);
            studentInfo.Append(" Age:");
            studentInfo.Append(this.Age);

            return studentInfo.ToString();
        }
    }
}
