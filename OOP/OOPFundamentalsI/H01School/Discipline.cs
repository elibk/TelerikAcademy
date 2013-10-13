////
namespace H01School
{
    using System;
    using System.Linq;
    using System.Text;

   public class Discipline
    {
        private DisciplineObject name;
        private int numberOfLectures;
        private int numberOfExercises;
        private string additionalInfo;

        public Discipline(DisciplineObject name, int numberOfLectures, int numberOfExercises)
            : this(name, numberOfLectures, numberOfExercises, null)
        {
        }

        public Discipline(DisciplineObject name, int numberOfLectures, int numberOfExercises, string additionalInfo)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExercises = numberOfExercises;
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

        public DisciplineObject Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public int NumberOfLectures
        {
            get
            {
                return this.numberOfLectures;
            }

            set
            {
                this.numberOfLectures = value;
            }
        }

        public int NumberOfExercises
        {
            get
            {
                return this.numberOfExercises;
            }

            set
            {
                this.numberOfExercises = value;
            }
        }

        public Teacher Teacher
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
            info.Append(this.Name + " " + this.NumberOfExercises + "/" + this.NumberOfLectures);

            if (this.additionalInfo != null)
            {
                info.Append(Environment.NewLine + "|" + this.AdditionalInfo + "|");
            }

            return info.ToString();
        }
    }
}
