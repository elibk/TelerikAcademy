////
namespace H01School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class School
    {
       private List<Class> classes = new List<Class>();

        public List<Class> Classes
        {
            get
            {
                return this.classes;
            }

            set
            {
                this.classes = value;
            }
        }

        public void AddClass(Class schoolClass)
        {
            this.classes.Add(schoolClass);
        }

        public void RemoveClass(Class schoolClass)
        {
            this.classes.Remove(schoolClass);
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.Append("School Info:" + Environment.NewLine);
            foreach (var schoolClass in this.Classes)
            {
                info.Append(schoolClass + Environment.NewLine);
            }

            return info.ToString();
        }
    }
}
