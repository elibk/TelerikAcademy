using System;

class CompanyProfile
{
    static void Main()
    {
        Console.Write("Company name:");
        string company = Console.ReadLine();
        Console.WriteLine("Enter company address that includes:");
        Console.Write("Country:");
        string country = Console.ReadLine();
        Console.Write("Town:");
        string town = Console.ReadLine();
        Console.Write("Street:");
        string street = Console.ReadLine();
        Console.Write("Street number:");
        byte strNum = byte.Parse(Console.ReadLine());
        Console.Write("Manager's first name:");
        string firstName = Console.ReadLine();
        Console.Write("Manager's second name:");
        string midName = Console.ReadLine();
        Console.Write("Manager's last name:");
        string lastName = Console.ReadLine();
        Console.Write("Manager's age:");
        byte age = byte.Parse(Console.ReadLine());
        Console.Write("Manager's phone number:");
        string phone = Console.ReadLine();
        Console.WriteLine(
            "Congrats! Your profile is done. Company {0},placed in {1}/{2} on {3} street with current manager {4} {5} years old, with phone number {6}"
            ,company,town,country,street+strNum,firstName+" "+midName+" "+lastName,age,phone);
    }
}

