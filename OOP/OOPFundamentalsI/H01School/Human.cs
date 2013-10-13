////
namespace H01School
{
    using System;
    using System.Linq;

    public class Human
    {
        private string name;

        public Human(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            protected set
            {
                this.name = value;
            }
        }
    }
}
