////
namespace H03TypesOfAnimals
{
    using System;
    using System.Linq;
    using System.Text;

    public abstract class Animal
    {
        private string name;
        private sbyte age;
        private Sex sex; 

        protected Animal(string name, sbyte age, Sex sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;            
        }

        public Sex Sex
        {
            get
            {
                return this.sex;
            }

            set
            {
                this.sex = value;
            }
        }

        public string Name
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

        public sbyte Age
        {
            get
            {
                return this.age;
            }

            set
            {
                this.age = value;
            }
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.Append(" " + this.Name + " " + this.Age + " years old " + this.Sex);
            return this.GetType().Name + info.ToString();
        }
    }
}
