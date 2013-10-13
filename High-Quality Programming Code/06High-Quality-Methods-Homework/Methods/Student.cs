////
namespace Methods
{
    using System;

   public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student otherStudent)
        {
            return this.BirthDate > otherStudent.BirthDate;
        }
    }
}
