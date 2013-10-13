////
namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class OffsiteCourse : Course
    {
        private string town;

        #region constructors
        public OffsiteCourse(string courseName, Teacher teacher = null, string town = null)
            : this(courseName, new List<Student>(), teacher, town)
        {
        }

        public OffsiteCourse(string courseName, string town)
            : this(courseName, new List<Student>(), null, town)
        {
        }

        public OffsiteCourse(string courseName, IList<Student> students, string town)
            : this(courseName, students, null, town)
        {
        }

        public OffsiteCourse(string courseName, IList<Student> students, Teacher teacher = null, string town = null)
            : base(courseName, students, teacher)
        {
            this.Town = town;
        }
        #endregion

        public string Town
        {
            get
            {
                if (this.town == null)
                {
                    return "N/A";
                }

                return this.town;
            }

            set
            {
                this.town = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Offsite Course");
            result.Append(base.ToString());
            result.Append(" Town = ");
            result.Append(this.Town);
            
            result.Append(" }");

            return result.ToString();
        }
    }
}
