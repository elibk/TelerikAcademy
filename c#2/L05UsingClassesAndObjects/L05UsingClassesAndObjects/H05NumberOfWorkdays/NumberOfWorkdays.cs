////
namespace H05NumberOfWorkdays
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

   public class NumberOfWorkdays
    {
       private static readonly DateTime[] OfficialHolidays = 
                                                            {  
                                                               new DateTime(2013, 1, 1),
                                                               new DateTime(2013, 3, 3),
                                                               new DateTime(2013, 5, 6),
                                                               new DateTime(2013, 5, 24),
                                                               new DateTime(2013, 9, 6),
                                                               new DateTime(2013, 12, 24),
                                                               new DateTime(2013, 12, 25),
                                                               new DateTime(2013, 12, 31) 
                                                            };

       private static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            Console.WriteLine("Countdown till holiday!");
            DateTime today = DateTime.Now;
            DateTime someDay = new DateTime();

            do
            {
                Console.WriteLine("Enter the date of the first day of your next holiday.");
                Console.Write("Enter year:");
                short year = short.Parse(Console.ReadLine());
                Console.Write("Enter mounth:");
                byte mounth = byte.Parse(Console.ReadLine());
                Console.Write("Enter day:");
                byte day = byte.Parse(Console.ReadLine());
                someDay = new DateTime(year, mounth, day);
            }
            while (today > someDay);

            int workdays = CountWorkDays(today, someDay);
            Console.Clear();

            Console.WriteLine("From {0:dd/MM/yyyy}(today) to {1:d} there are {2} workdays.", DateTime.Now, someDay, workdays);
            //// including today if it's a workday.
        }

        private static int CountWorkDays(DateTime today, DateTime someDay)
        {
            string saturday = "Saturday",
                   sunday = "Sunday";

            int workdays = new int();

            while (today.Day != someDay.Day || today.Month != someDay.Month || today.Year != someDay.Year)
            {               
                if (today.DayOfWeek.ToString() == saturday || today.DayOfWeek.ToString() == sunday)
                {
                    ////isn't a workday
                }
                else
                {
                    bool workday = true;
                    for (int i = 0; i < OfficialHolidays.Length; i++)
                    {
                        if (today.Month == OfficialHolidays[i].Month && today.Day == OfficialHolidays[i].Day)
                        {
                            workday = false;
                            break;
                        }
                    }

                    if (workday && (today.Day != someDay.Day || today.Month != someDay.Month || today.Year != someDay.Year))                       
                    {
                        workdays++;
                    }
                    //// counting is inclusive, and first day of the holiday isn't a workday. 
                }

                today = today.AddDays(1);
            }

            return workdays;
        }
    }
}
