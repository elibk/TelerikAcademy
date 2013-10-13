using System;

class DeclareEmployeesVariables
{
    static void Main()
    {
        Console.WriteLine("Please enter your first name:");
        string firstName= Console.ReadLine();
        Console.WriteLine("Please enter your last name:");
        string lastName = Console.ReadLine();
        byte age;
        
        do
        {
          Console.WriteLine("Please enter your age(between 18 and 64):");
          age = byte.Parse(Console.ReadLine());
        } while (age < 18 || age > 64);

        char gender;
        do
        {
           Console.WriteLine("Please enter your gender (f/m):");
           char.TryParse(Console.ReadLine(), out gender);
        } while (gender != 'm' && gender != 'f');

        int employeeID;
        do
        {
            Console.WriteLine("Please enter your employee ID (number between 27560000 and 27569999)");
            employeeID = int.Parse(Console.ReadLine());
        } while ((employeeID < 27560000 || employeeID > 27569999));

        Console.WriteLine("You are:{0} {1},{2} years old.Personal ID: {3}.\nIf sth is not correct, start input again.", firstName, lastName, age, employeeID);
        //if ((gender == 'm' || gender == 'f') && (age >= 18 && age <= 64) && (employeeID >= 27560000 && employeeID <= 27569999))
        //{
        //    Console.WriteLine("You are:{0} {1},{2} years old.Personal ID: {3}.\nIf sth is not correct, start input again.", firstName, lastName, age, employeeID);
        //}
        //else 
        //{
        //    Console.WriteLine("Incorrect! Start input again!");
        //}
    }
}
