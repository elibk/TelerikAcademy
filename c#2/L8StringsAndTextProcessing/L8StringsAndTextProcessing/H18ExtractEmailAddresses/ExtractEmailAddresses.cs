using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace H18ExtractEmailAddresses
{
    class ExtractEmailAddresses
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"...\...\SomeText.txt", Encoding.GetEncoding("windows-1251"));
            string emailPattern = @"\b[A-Z0-9a-z._%+-]+@[A-Z0-9a-z.-]+\.[A-Za-z]{2,4}\b";

            List<string> emails = new List<string>();

            using (reader)
            {
                while (true)
                {
                    string line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }
                    Match match = Regex.Match(line, emailPattern);
                    while (match.Success)
                    {
                        string email = match.ToString();
                        emails.Add(email);
                        match = match.NextMatch();

                    }
                    
                }
            }

            foreach (var item in emails)
            {
                Console.WriteLine(item);
            }
        }
    }
}
