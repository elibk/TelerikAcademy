////
namespace H03TypesOfAnimals
{
    using System;
    using System.Linq;

   public abstract class Cat : Animal, ISound
    {
        public Cat(string name, sbyte age, Sex sex)
           : base(name, age, sex) 
        {
        }

        public string Sound()
        {
            return "Miaou";
        }
    }
}
