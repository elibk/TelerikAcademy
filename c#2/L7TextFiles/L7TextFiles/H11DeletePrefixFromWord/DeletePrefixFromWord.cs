using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace H11DeletePrefixFromWord
{
    class DeletePrefixFromWord
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"...\...\SomeText.txt", Encoding.GetEncoding("windows-1251"));
            StreamWriter writer = new StreamWriter(@"...\...\output.txt", false, Encoding.GetEncoding("windows-1251"));

            using (reader)
            {
                using (writer)
                {
                    while (true)
                    {
                        string line = reader.ReadLine();
                        
                        if (line == null)
                        {
                            break;
                        }

                        bool isMatch = true;

                        while (true)
                        {
                            isMatch = Regex.IsMatch(line, @"\btest_*\w+\b");
                            if (isMatch == false)
                            {
                                break;
                            }
                            string word = Regex.Match(line, @"\btest_*\w+\b").ToString();
                            line =  Regex.Replace(line,word,word.Substring(4));
                        }

                        writer.WriteLine(line);

                        
                    }
                }

               
                
            }

            File.Replace(@"...\...\output.txt", @"...\...\SomeText.txt", @"...\...\backup.txt");
        }
    }
}
