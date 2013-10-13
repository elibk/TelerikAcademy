////
namespace H03TypesOfAnimals
{
    using System;
    using System.Linq;

   public class Dog : Animal, ISound
    {
       public Dog(string name, sbyte age, Sex sex)
           : base(name, age, sex) 
        {
        }

       public string Sound()
       {
           return "Bay-Bay";
       }
    }
}
