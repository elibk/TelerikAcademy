using System;
using System.Linq;

namespace H01CheckIfThereIsALeap
{
    class CheckIfThereIsALeap
    {
        static void Main(string[] args)
        {
            DateTime today = DateTime.Now;
            DateTime givenDay = new DateTime();

            TimeSpan MiddDays = givenDay - today;
            givenDay = DateTime.Parse(Console.ReadLine());
            double totaldays = MiddDays.TotalDays;
            Console.WriteLine(totaldays);
        }
    }
}
