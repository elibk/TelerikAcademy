////

namespace InheritanceAndPolymorphism
{
    using System;
    using System.Linq;

    public abstract class Person
    {
        private string name;

        public Person(string name)
        {
            this.Name = name;
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

        public override string ToString()
        {
            return this.Name;
        }
    }
}
