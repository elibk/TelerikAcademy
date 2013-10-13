////
namespace H05StringToUpper
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

   public class StringToUpper
    {
       private static void Main(string[] args)
        {
            string substring = @">\w+<|\b\w+</|>\w+\b";

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

                    Match match = Regex.Match(line, substring);
                    while (match.Success)
                    {
                        string word = match.ToString();
                        int start = word.IndexOf('>');
                        int end = word.LastIndexOf('<');
                        if (start < 0)
                        {
                            start = 0;
                        }
                        else
                        {
                            start++;
                        }

                        if (end < 0)
                        {
                            end = word.Length - start;
                        }
                        else
                        {
                            end--;
                        }

                        line = Regex.Replace(line, word, word.Substring(start, end).ToUpper());
                        
                        match = match.NextMatch();
                    }

                    line = Regex.Replace(line, @"<*/*upcase>*", string.Empty);
                    Console.WriteLine(line);
                }              
            }
        }
    }
}
