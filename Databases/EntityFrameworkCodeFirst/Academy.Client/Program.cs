using System;
using System.Linq;
using Academy.Data;
using Academy.Data.Migrations;
using System.Data.Entity;

namespace Academy.Client
{
   public class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AcademyContext, Configuration>());
            
            AcademyContext dbContext = new AcademyContext();

            foreach (var homework in dbContext.Homeworks.Include("Owner"))
            {
                Console.WriteLine("Homework: {0} -> Student: {1}", homework.Content, homework.Owner.Name);
                
            }
            Console.WriteLine();
            foreach (var student in dbContext.Students.Include("Homeworks"))
            {
                Console.WriteLine("Student: {0}", student.Name);
                Console.WriteLine("-----------Homeworks------------");
                foreach (var homework in student.Homeworks)
                {
                    Console.WriteLine(homework.Content);
                }
                Console.WriteLine("-----------------------");
            }
        }
    }
}
