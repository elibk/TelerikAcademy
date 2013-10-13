namespace Academy.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Academy.Models;


    public sealed class Configuration : DbMigrationsConfiguration<Academy.Data.AcademyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Academy.Data.AcademyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            Student[] students = new Student[] 
            {
                
                new Student { Name = "Andrew Peters" },
                new Student { Name = "Brice Lambson" },
                new Student { Name = "Rowan Miller" } 
            };

            Course[] courses = new Course[] 
            { 
                new Course { Name = "JS Apps" }, 
                new Course { Name = "Photoshop" }, 
                new Course { Name = "CMS" } 
            };


            students[0].Courses.Add(courses[0]);
            students[1].Courses.Add(courses[0]);
            students[1].Courses.Add(courses[1]);
            students[2].Courses.Add(courses[1]);
            students[2].Courses.Add(courses[2]);

            context.Students.AddOrUpdate(
                s => s.Name,

                students[0],
                students[1],
                students[2]
            );

            context.Courses.AddOrUpdate(
                c => c.Name,

                courses[0],
                courses[1],
                courses[2]
            );

            context.Homeworks.AddOrUpdate(
                h => h.Content,
              new Homework { Content = "Probability Theory", Owner = students[1], TimeSent = new DateTime(2013, 1, 1), CourseAssigned = courses[0] },
              new Homework { Content = "Photoshop basics", Owner = students[2], TimeSent = new DateTime(2013, 2, 12), CourseAssigned = courses[1] },
              new Homework { Content = "KendoUI", Owner = students[1], TimeSent = new DateTime(2013, 2, 17), CourseAssigned = courses[0] }
            );
            
        }
    }
}
