////
namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;

   public class CoursesExamples
    {
       internal static void Main()
        {
            LocalCourse localCourse = new LocalCourse("Databases");
            Console.WriteLine(localCourse);

            localCourse.Lab = "Enterprise";
            Console.WriteLine(localCourse);

            localCourse.Students = new List<Student>() { new Student("Peter"), new Student("Maria") };
            Console.WriteLine(localCourse);

            localCourse.Teacher = new Teacher("Svetlin Nakov");
            localCourse.Students.Add(new Student("Milena"));
            localCourse.Students.Add(new Student("Todor"));
            Console.WriteLine(localCourse);

            OffsiteCourse offsiteCourse = new OffsiteCourse(
                "PHP and WordPress Development",
                new List<Student>() 
                { 
                new Student("Thomas"), 
                new Student("Ani"), 
                new Student("Steve") 
                }, 
                new Teacher("Mario Peshev"));
            Console.WriteLine(offsiteCourse);

            //// uncomment to see constructor tests

            ////Course[] testOffsiteCourseConstructors = 
            ////{
            ////    new OffsiteCourse("Test Name", "Test Town"), 
            ////    new OffsiteCourse("Test Name", new Teacher("test teacher")),
            ////    new OffsiteCourse("Test Name", new Teacher("test teacher")),
            ////    new OffsiteCourse("Test Name", new Teacher("test teacher"), "Test Town"),
            ////    new OffsiteCourse("Test Name", new List<Student>()),
            ////    new OffsiteCourse("Test Name", new List<Student>(), new Teacher("test teacher")),
            ////    new OffsiteCourse("Test Name", new List<Student>(), "Test Town"),
            ////    new OffsiteCourse("Test Name", new List<Student>(), new Teacher("test teacher"),"Test Town"),
            ////};

            ////Course[] testLocalCourseConstructors = 
            ////{
            ////    new LocalCourse("Test Name", "Test Lab"), 
            ////    new LocalCourse("Test Name", new Teacher("test teacher")),
            ////    new LocalCourse("Test Name", new Teacher("test teacher")),
            ////    new LocalCourse("Test Name", new Teacher("test teacher"), "Test Lab"),
            ////    new LocalCourse("Test Name", new List<Student>()),
            ////    new LocalCourse("Test Name", new List<Student>(), new Teacher("test teacher")),
            ////    new LocalCourse("Test Name", new List<Student>(), "Test Lab"),
            ////    new LocalCourse("Test Name", new List<Student>(), new Teacher("test teacher"),"Test Lab"),
            ////};

            ////foreach (Course course in testOffsiteCourseConstructors)
            ////{
            ////    Console.WriteLine(course);
            ////}

            ////foreach (Course course in testLocalCourseConstructors)
            ////{
            ////    Console.WriteLine(course);
            ////}
        }
    }
}
