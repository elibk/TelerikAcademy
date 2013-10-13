using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace H17DateAndTimeLater
{
    class DateAndTimeLater
    {
        static void Main(string[] args)
        {
            string time = "12.12.12 12:00:00";
            DateTime t = DateTime.Parse(time);

            DateTime later = t.AddHours(6).AddMinutes(30);

            //string dayName = later.ToString("dddd", CultureInfo.GetCultureInfo("bg-BG"));
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("bg-BG");
            Console.WriteLine("{0:d.MM.yyyy HH:mm:ss dddd} ", later);
        }
    }
}
