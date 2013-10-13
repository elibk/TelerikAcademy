////
namespace SchoolTesT
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using H01School;

   public class Test
    {
       private static void Main(string[] args)
        {
            int studentsInClass = 10;
            
            string[] names = { "Pesho", "Gosho", "Kiro", "Buba", "Niki", "Lili", "Penka", "Gergana", "Monika", "Bobi" };

            School school = new School();

            school.Classes = new List<Class> { new Class("12A", "The nerds"), new Class("12B", "The dummies"), new Class("12C"), new Class("12D", "The cool") };

            Random randomGenerator = new Random();

            int studentNumber = 20000;

            for (int classInd = 0; classInd < school.Classes.Count; classInd++)
            {
                for (int i = 0; i < studentsInClass; i++)
                {
                    school.Classes[classInd].AddStudent(new Student(names[randomGenerator.Next(0, 10)], ++studentNumber));
                    if (i % 2 == 0)
                    {
                        school.Classes[classInd].AddTeacher(new Teacher(names[randomGenerator.Next(0, 10)]));
                    }
                }
            }

            for (int classInd = 0; classInd < school.Classes.Count; classInd++)
            {              
                 foreach (var teacher in school.Classes[classInd].SetOfTeachers)
                 {
                     int discipline = randomGenerator.Next(0, 10);

                     teacher.AddDiscipline(new Discipline((DisciplineObject)discipline, 12, 15));
                     discipline = randomGenerator.Next(0, 10);
                     teacher.AddDiscipline(new Discipline((DisciplineObject)discipline, 12, 15));
                     discipline = randomGenerator.Next(0, 10);
                     teacher.AddDiscipline(new Discipline((DisciplineObject)discipline, 12, 15));
                 }
            }

            Console.Write(school);
        }
    }
}
