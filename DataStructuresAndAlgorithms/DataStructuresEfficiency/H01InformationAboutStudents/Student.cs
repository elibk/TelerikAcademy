namespace H01InformationAboutStudents
{
    using System;
    using System.Linq;

    public class Student : IComparable<Student>
    {
        private string firstName;
        private string lastName;

        public Student(string firstName, string lastName)
        {
            this.FName = firstName;
            this.LName = lastName;
        }

        public string FName
        {
            get
            {
                return this.firstName;
            }

            protected set
            {
                this.firstName = value;
            }
        }

        public string LName
        {
            get
            {
                return this.lastName;
            }

            protected set
            {
                this.lastName = value;
            }
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(Student other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            int firstNameComparetion = this.firstName.CompareTo(other.FName);
            if (firstNameComparetion == 0)
            {
                return this.LName.CompareTo(other.LName);
            }

            return firstNameComparetion;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.firstName, this.LName);
        }
    }
}