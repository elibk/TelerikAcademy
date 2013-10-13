using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace H19ExtractAllDates
{
    class ExtractAllDates
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"...\...\SomeText.txt", Encoding.GetEncoding("windows-1251"));
            string datePattern = @"(0*[1-9]|[12][0-9]|3[01])[.](0*[1-9]|1[012])[.][0-9]{4}";

            List<DateTime> dates = new List<DateTime>();

            using (reader)
            {
                while (true)
                {
                    string line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }
                    Match match = Regex.Match(line, datePattern);
                    while (match.Success)
                    {
                        string date = match.ToString();
                        dates.Add(DateTime.Parse(date));
                        match = match.NextMatch();

                    }

                }
            }
            //(new CultureInfo("en-CA")
            //Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-CA");
            foreach (var date in dates)
            {
                Console.WriteLine(date.ToString(new CultureInfo("en-CA")));
            }
        }
    }
}
