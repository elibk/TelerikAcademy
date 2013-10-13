////
namespace TypesOfPeopleTest
{  
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using H02TypesOfPeople;

   public class Test
    {
       private static void Main(string[] args)
        {
            Random randonGenerator = new Random();
            //// some names
            string[] firstNames = { "Atanas", "Anton", "Kiril", "Ivan", "Petko" };
            string[] lastNames = { "Atanasov", "Antonov", "Kirilov", "Ivanov", "Petkov" };

            List<Student> students = new List<Student>(10);
           
            //// fill students
            for (int i = 0; i < students.Capacity; i++)
            {
                int firstNameIndex = randonGenerator.Next(0, 5);
                int lastNameIndex = randonGenerator.Next(0, 5);
                sbyte grade = (sbyte)randonGenerator.Next(0, 7);
                students.Add(new Student(firstNames[firstNameIndex], lastNames[lastNameIndex], grade));
            }

            PrintOnConsole(students);
            var studentsOrdered = from student in students orderby student.Grade select student;

            PrintOnConsole(studentsOrdered);

            List<Worker> workers = new List<Worker>(10);
            //// fill workers
            for (int i = 0; i < workers.Capacity; i++)
            {
                int firstNameIndex = randonGenerator.Next(0, 5);
                int lastNameIndex = randonGenerator.Next(0, 5);
                uint weekSalary = (uint)randonGenerator.Next(100, 2000);
                float workHoursPerDay = randonGenerator.Next(1, 25);
                workers.Add(new Worker(firstNames[firstNameIndex], lastNames[lastNameIndex], weekSalary, workHoursPerDay));
            }

            PrintOnConsole(workers);

            var workersOrdered = from worker in workers orderby worker.MoneyPerHour() descending select worker;

            PrintOnConsole(workersOrdered);

            List<Human> people = new List<Human>();
            people.AddRange(students);
            people.AddRange(workers);

            PrintOnConsole(people);

            var peopleOrdered = from human in people orderby human.FirstName, human.SecondName select human;

            PrintOnConsole(peopleOrdered);
        }

        private static void PrintOnConsole(IEnumerable<Human> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', Console.WindowWidth));
        }
    }
}
