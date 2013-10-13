using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1NextDate
{
    class NextDate
    {
        static void Main(string[] args)
        {
            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            DateTime today = new DateTime(year, month, day);
            DateTime tomorrow = today.AddDays(1);
            Console.WriteLine(tomorrow.ToString("d.M.yyyy",
                   CultureInfo.CreateSpecificCulture("en-US")));
        }
    }
}
