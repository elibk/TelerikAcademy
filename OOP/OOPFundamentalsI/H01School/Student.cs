////
namespace H01School
{
    using System;
    using System.Linq;
    using System.Text;

    public class Student : Human 
    {
        private int uniqueNumber;
        private string additionalInfo;

        public Student(string name, int uniqueNumber)
            : this(name, uniqueNumber, null)
        {          
        }

        public Student(string name, int uniqueNumber, string additionalInfo)
            : base(name)
        {
            this.AdditionalInfo = additionalInfo;
            this.UniqueNumber = uniqueNumber;
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

        public int UniqueNumber
        {
            get
            {
                return this.uniqueNumber;
            }

            set
            {
                this.uniqueNumber = value;
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

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.Append(this.Name + " " + this.UniqueNumber);

            if (this.additionalInfo != null)
            {
                info.Append("|" + this.AdditionalInfo + "|");
            }

            return info.ToString();
        }
    }
}
