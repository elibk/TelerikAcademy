////
namespace H01School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Class
    {
        private readonly List<Student> schoolClass = new List<Student>();
        private readonly List<Teacher> setOfTeachers = new List<Teacher>();
        private string identifier;
        private string additionalInfo;

        public Class(string identifier)
            : this(identifier, null)
        {      
        }

        public Class(string identifier, string additionalInfo)
        {
            this.Identifier = identifier;
            this.AdditionalInfo = additionalInfo;
        }

        public string AdditionalInfo
        {
            get
            {
                return this.additionalInfo;
            }

            set
            {
                this.additionalInfo = value;
            }
        }

        public List<Student> SchoolClass
        {
            get
            {
                return this.schoolClass;
            }
        }

        public List<Teacher> SetOfTeachers
        {
            get
            {
                return this.setOfTeachers;
            }
        }

        public string Identifier
        {
            get
            {
                return this.identifier;
            }

            set
            {
                this.identifier = value;
            }
        }

        public School School
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public void AddStudent(Student student)
        {
            this.SchoolClass.Add(student);
        }

        public void AddTeacher(Teacher teacher)
        {
            this.SetOfTeachers.Add(teacher);
        }

        public void RemoveStudent(Student student)
        {
            this.SchoolClass.Remove(student);
        }

        public void RemoveTeacher(Teacher teacher)
        {
            this.SetOfTeachers.Remove(teacher);
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.Append("Class: " + this.Identifier + Environment.NewLine);

            if (this.additionalInfo != null)
            {
                info.Append("|" + this.AdditionalInfo + "|" + Environment.NewLine);
            }

            info.Append("Students:" + Environment.NewLine);
            foreach (var student in this.SchoolClass)
            {
                info.Append(student + Environment.NewLine);
            }

            info.Append("Teachers:" + Environment.NewLine);
            foreach (var teacher in this.SetOfTeachers)
            {
                info.Append(teacher + Environment.NewLine);
            }

            return info.ToString();
        }
    }
}
