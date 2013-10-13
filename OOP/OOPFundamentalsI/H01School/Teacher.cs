////
namespace H01School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Teacher : Human 
    {
        private List<Discipline> setOfDisciplines = new List<Discipline>();
        private string additionalInfo;

        public Teacher(string name)
            : this(name, null)
        {             
        }

        public Teacher(string name, string additionalInfo)
            : base(name)
        {
            this.AdditionalInfo = additionalInfo;
        }

        public List<Discipline> SetOfDisciplines
        {
            get
            {
                return this.setOfDisciplines;
            }
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

        public Class Class
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public void AddDiscipline(Discipline discipline)
        {
            this.setOfDisciplines.Add(discipline);
        }

        public void RemoveDiscipline(Discipline discipline)
        {
            this.setOfDisciplines.Remove(discipline);
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.Append(this.Name + " " + "Teaches: ");

            foreach (var discipline in this.SetOfDisciplines)
            {
               info.Append(discipline + " ");
            }

            if (this.additionalInfo != null)
            {
                info.Append(Environment.NewLine + "|" + this.AdditionalInfo + "|");
            }

            return info.ToString();
        }
    }
}
