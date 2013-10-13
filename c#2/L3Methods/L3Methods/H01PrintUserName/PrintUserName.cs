////
namespace H01PrintUserName
{
    using System;
    using System.Linq;

    public class PrintUserName
    {
        private static void PrintName(string name) 
        {
            Console.WriteLine("Hello, {0}! What's up?", name);
        }

        private static void Main(string[] args)
        {
           Console.Write("Enter your name:");
           string name = Console.ReadLine();
           PrintName(name); 
        }
    }
}
