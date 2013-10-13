////
namespace H02TypesOfPeople
{
    using System;
    using System.Linq;
    using System.Text;

   public class Student : Human
    {
        private sbyte grade;

        public Student(string firstName, string secondName, sbyte grade) 
            : base(firstName, secondName)
        {
            this.grade = grade;
        }

        public sbyte Grade
        {
            get
            {
                return this.grade;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The value for Grade can not be negative");
                }

                if (value > 6)
                {
                    throw new ArgumentException("The value for Grade can not be bigger than 6");
                }

                this.grade = value;
            }
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder("Student:");
            info.Append(this.FirstName);
            info.Append(" ");
            info.Append(this.SecondName);
            info.Append(" grade:");
            info.Append(this.Grade);

            return info.ToString();
        }
    }
}
