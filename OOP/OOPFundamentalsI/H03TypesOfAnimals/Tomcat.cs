////
namespace H03TypesOfAnimals
{
    using System;
    using System.Linq;

    public class Tomcat : Cat
    {
         public Tomcat(string name, sbyte age)
           : base(name, age, Sex.Male) 
        {
        }
    }
}
