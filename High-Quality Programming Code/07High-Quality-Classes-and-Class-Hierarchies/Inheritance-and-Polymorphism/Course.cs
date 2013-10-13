////
namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Course
    {
        private string name;
        private Teacher teacher;
        private IList<Student> students;

        public Course(string courseName, IList<Student> students, Teacher teacher)
        {
            this.Name = courseName;
            this.Students = students;
            this.Teacher = teacher;
        }

        #region properties
        public string Name
        {
            get
            {
                if (this.name == null)
                {
                    return "N/A";
                }

                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public Teacher Teacher
        {
            get
            {
                if (this.teacher == null)
                {
                    return new Teacher("N/A");
                }

                return this.teacher;
            }

            set
            {
                this.teacher = value;
            }
        }

        public IList<Student> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                this.students = value;
            }
        }
        #endregion

        public override string ToString()
        {
            char propertiesDivider = ';';
            StringBuilder result = new StringBuilder();
            
            result.Append(" { Name = ");
            result.Append(this.Name);

            result.Append(" Teacher = ");
            result.Append(this.Teacher);
            result.Append(propertiesDivider);

            result.Append(" Students = ");
            result.Append(this.GetStudentsAsString());
            result.Append(propertiesDivider);

            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}
