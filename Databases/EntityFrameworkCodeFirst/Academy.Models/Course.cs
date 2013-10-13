using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Models
{
    public class Course
    {
       ICollection<Student> students;

       public int CourseId { get; set; }
       public string Name { get; set; }
       public string[] Materials { get; set; }

        public Course()
        {
            this.students = new HashSet<Student>();
        }
        public virtual ICollection<Student> Students
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
    }
}
