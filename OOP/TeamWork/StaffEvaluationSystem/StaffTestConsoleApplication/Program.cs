////
namespace StaffTestConsoleApplication
{
    using System;
    using System.Linq;
    using UserInterface;

   public class Program
    {
       public static void Main(string[] args)
        {
            UIConsole ui = new UIConsole();
            Console.WriteLine("Please enter your client Email.");

            if (Authorization.EmailValidator(Console.ReadLine()))
            {
                Console.WriteLine(Authorization.LoadGreeting()); 
            }
            else
            {
                Console.WriteLine(Authorization.LoadGreeting());
                Environment.Exit(0);
            }

            ui.ShowStartScreen();

            while (true)
            {
                ui.ProcessInput(Console.ReadLine());
            }
        }
    }
}
