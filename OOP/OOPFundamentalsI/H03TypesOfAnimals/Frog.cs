////
namespace H03TypesOfAnimals
{
    using System;
    using System.Linq;

   public class Frog : Animal, ISound
    {
        public Frog(string name, sbyte age, Sex sex)
           : base(name, age, sex) 
        {
        }

        public string Sound()
        {
            return "Kwak-Kwak";
        }
    }
}
