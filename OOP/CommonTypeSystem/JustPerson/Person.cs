////
namespace JustPerson
{
    using System;
    using System.Linq;

    public class Person
    {
        #region Fields
        private string name;
        private uint? age;
        #endregion

        #region Constructor
        public Person(string name, uint? age = null)
        {
            this.Name = name;
            this.Age = age;
        }
        #endregion

        #region Properties
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

        public uint? Age
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
        #endregion

        #region Override_official_Methods
        public override string ToString()
        {
            if (this.Age != null)
            {
                return string.Format("Name: {0} | Age:{1}", this.Name, this.Age.ToString());
            }
            else
            {
                return string.Format("Name: {0} | Age: NA", this.Name);
            }
        }
        #endregion
    }
}
