////
namespace H04CountSubstring
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

   public class CountSubstring
    {
       private static void Main(string[] args)
        {
            string substring = "in";
            int count = 0;

            StreamReader reader = new StreamReader(@"...\...\text.txt", Encoding.GetEncoding("windows-1251"));

            using (reader)
            {
                while (true)
                {
                    string line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    Match match = Regex.Match(line, substring, RegexOptions.IgnoreCase);
                    while (match.Success)
                    {
                        count++;
                        match = match.NextMatch();
                    }
                }

                Console.WriteLine(count);
            }           
        }
    }
}
