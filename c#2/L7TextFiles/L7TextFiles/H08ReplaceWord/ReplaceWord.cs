﻿////
namespace H08ReplaceWord
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

   public class ReplaceWord
    {
       private static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"...\...\SomeText.txt", Encoding.GetEncoding("windows-1251"));
            StreamWriter writer = new StreamWriter(@"...\...\output.txt", false, Encoding.GetEncoding("windows-1251"));

            string text = string.Empty;
            using (reader)
            {
                using (writer)
                {
                    while (true)
                    {
                        text = reader.ReadLine();
                        if (text == null)
                        {
                            break;
                        }

                        text = Regex.Replace(text, @"\bfinish\b", "start");

                        writer.WriteLine(text);
                    }
                }
            }

            File.Replace(@"...\...\output.txt", @"...\...\SomeText.txt", @"...\...\backup.txt");
        }
    }
}
