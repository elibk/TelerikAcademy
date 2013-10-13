////
namespace JustStudent
{
    using System;
    using System.Linq;

    public class Test
    {
        private static void Main(string[] args)
        {
            Student someStudent = new Student("Pesho", "Peshev", "Peshev", 20000, (University)1, (Faculty)1, (Specialty)1, new Address("Bulgaria", "Sofia", "SomeStreet", 12), "088888888", "pesho.peshev@gmail.bg");
            Student otherStudent = new Student("Gosho", "Goshev", "Goshev", 20001, (University)1, (Faculty)1, (Specialty)1, new Address("Bulgaria", "Sofia", "SomeStreet", 12), "088888888", "gosho.goshev@gmail.bg");
            Console.WriteLine(new string('-', Console.WindowWidth));
            Console.WriteLine(someStudent);
            Console.WriteLine(new string('-', Console.WindowWidth));
            Console.WriteLine(otherStudent);
            Console.WriteLine(new string('-', Console.WindowWidth));
            Console.WriteLine(someStudent.Equals(otherStudent));
            Console.WriteLine(someStudent == otherStudent);
            Console.WriteLine(someStudent != otherStudent);
            Console.WriteLine(someStudent.GetHashCode());
            Console.WriteLine(new string('-', Console.WindowWidth));
            Student newStudent = (Student)someStudent.Clone();

            someStudent.FirstName = "New";
            someStudent.MiddleName = "New";
            someStudent.Email = "new.email@gmail.bg";
            someStudent.PermanentAddress.Street = "New Street";
            someStudent.Speciality = (Specialty)3;
           
            Console.WriteLine(someStudent);
            Console.WriteLine(new string('-', Console.WindowWidth));
            Console.WriteLine(newStudent);
        }
    }
}
