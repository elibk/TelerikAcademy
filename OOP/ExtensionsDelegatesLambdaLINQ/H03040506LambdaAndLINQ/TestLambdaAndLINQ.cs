////
namespace H03040506LambdaAndLINQ
{
    using System;
    using System.Linq;
    using H0102ExtensionMethods;

   public class TestLambdaAndLINQ
    {
       private static readonly Random RandonGenerator = new Random();

       private static void Main(string[] args)
        {
            string[] firstNames = { "Atanas", "Anton", "Kiril", "Ivan", "Petko" };
            string[] lastNames = { "Atanasov", "Antonov", "Kirilov", "Ivanov", "Petkov" };

            Student[] students = new Student[10];

            for (int i = 0; i < students.Length; i++)
            {
                int firstNameIndex = RandonGenerator.Next(0, 5);
                int lastNameIndex = RandonGenerator.Next(0, 5);
                sbyte age = (sbyte)RandonGenerator.Next(17, 35);
                students[i] = new Student(firstNames[firstNameIndex], lastNames[lastNameIndex], age);
            }

            var sortedStudentsLambada = students.OrderByDescending(student => student.FirstName)
                                                .ThenByDescending(student => student.LastName);
            sortedStudentsLambada.PrintOnConsole();
            Console.WriteLine(new string('-', Console.WindowWidth));
            var sortedStudents = from student in students orderby student.FirstName descending, student.LastName descending select student;

            sortedStudents.PrintOnConsole();
            Console.WriteLine(new string('-', Console.WindowWidth));
            var studentsFirstNameBeforeLast = from student in students where student.FirstName.CompareTo(student.LastName) < 0 select student;

            foreach (var student in studentsFirstNameBeforeLast)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine(new string('-', Console.WindowWidth));
            var studentsAtSomeAgeNames = from student in students where student.Age >= 17 && student.Age <= 24 select new { FirstName = student.FirstName, LastName = student.LastName };

            foreach (var student in studentsAtSomeAgeNames)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine(new string('^', Console.WindowWidth));
            int[] numbers = { 1, 3, 5, 14, 21, 30, 28, 210 };

            var dividersLambada = numbers.Where(number => number % 3 == 0 && number % 7 == 0);
            dividersLambada.PrintOnConsole();
            Console.WriteLine(new string('-', Console.WindowWidth));
            var dividers = from number in numbers where number % 3 == 0 && number % 7 == 0 select number;
            dividers.PrintOnConsole();
        }
    }
}
