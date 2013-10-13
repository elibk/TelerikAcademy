////
namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Course
    {
        private string lab;

        #region constructors
        public LocalCourse(string courseName, Teacher teacher = null, string lab = null)
            : this(courseName, new List<Student>(), teacher, lab)
        {
        }

        public LocalCourse(string courseName, string lab)
            : this(courseName, new List<Student>(), null, lab)
        {
        }

        public LocalCourse(string courseName, IList<Student> students, string lab)
            : this(courseName, students, null, lab)
        {
        }

        public LocalCourse(string courseName, IList<Student> students, Teacher teacher = null, string lab = null)
            : base(courseName, students, teacher)
        {
            this.Lab = lab;
        }
        #endregion

        public string Lab
        {
            get
            {
                if (this.lab == null)
                {
                    return "N/A";
                }

                return this.lab;
            }

            set
            {
                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Local Course");
            result.Append(base.ToString());

            result.Append(" Lab = ");
            result.Append(this.Lab);
            result.Append(" }");

            return result.ToString();
        }
    }
}
