using System;
using System.Linq;
using TelerikAcademy.Data;

namespace TelerikAcademy.Client
{
    class Program
    {
        static void Main()
        {
            TelerikAcademyEntities dbContext = new TelerikAcademyEntities();
            
            // task 1
           PrintEmployeesWithQueryProblem(dbContext);
           PrintEmployeesWithoutQueryProblem(dbContext);

            //task 2

            EmployeesFormSofiaWithQueryProblem(dbContext);
            EmployeesFormSofiaWithoutQueryProblem(dbContext);
        }

        static void PrintEmployeesWithQueryProblem(TelerikAcademyEntities context)
        {
            foreach (var product in context.Employees)
            {
                Console.WriteLine("Product: {0}; Supplier: {1}; Category: {2}",
                    product.FirstName, product.MiddleName, product.LastName, product.Department, product.Address.Town);
            }
        }

        static void PrintEmployeesWithoutQueryProblem(TelerikAcademyEntities context)
        {
            foreach (var product in context.Employees.Include("Department").Include("Address"))
            {
                Console.WriteLine("Product: {0}; Supplier: {1}; Category: {2}",
                    product.FirstName, product.MiddleName, product.LastName, product.Department, product.Address.Town);
            }
        }

        static void EmployeesFormSofiaWithQueryProblem(TelerikAcademyEntities context)
        {
            var empTowns = (from emp in context.Employees.ToList() select emp.Address.Town).ToList().Where(x => x.Name == "Sofia").ToList();
        }

        static void EmployeesFormSofiaWithoutQueryProblem(TelerikAcademyEntities context)
        {
            var empTowns = (from emp in context.Employees select emp.Address.Town).Where(x => x.Name == "Sofia").ToList();
        }
    }
}
