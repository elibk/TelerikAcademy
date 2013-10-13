////

namespace H03TypesOfAnimals
{
    using System;
    using System.Linq;

    public class Kitten : Cat
    {
        public Kitten(string name, sbyte age) : base(name, age, Sex.Female)
        {
        }
    }
}
