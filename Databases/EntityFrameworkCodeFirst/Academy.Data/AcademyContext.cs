using System;
using System.Data.Entity;
using System.Linq;
using Academy.Models;


namespace Academy.Data
{
    public class AcademyContext : DbContext
    {
        public AcademyContext()
        : base("AcademyDb") 
        { 
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
    }
}
