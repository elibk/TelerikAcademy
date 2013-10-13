namespace H02PersonMaker
{
    using System;
    using System.Linq;

    public class PersonMaker
    {
        public enum SexType
        {
            CoolDude,
            HotChick
        }

        public class Person
        {
            public SexType Sex { get; set; }

            public string Name { get; set; }

            public int Age { get; set; }

            public void MakePerson(int age)
            {
                Person newPerson = new Person();
                newPerson.Age = age;
                if (age % 2 == 0)
                {
                    newPerson.Name = "Батката";
                    newPerson.Sex = SexType.CoolDude;
                }
                else
                {
                    newPerson.Name = "Мацето";
                    newPerson.Sex = SexType.HotChick;
                }
            }
        }
    }
}
