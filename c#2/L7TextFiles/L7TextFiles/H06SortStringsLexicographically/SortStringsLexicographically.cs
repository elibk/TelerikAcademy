////
namespace H06SortStringsLexicographically
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

   public class SortStringsLexicographically
    {
       private static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"...\...\input.txt", Encoding.GetEncoding("windows-1251"));
            StreamWriter writer = new StreamWriter(@"...\...\output.txt", true, Encoding.GetEncoding("windows-1251"));
            List<string> strings = new List<string>();

            using (reader)
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    strings.Add(line);
                }
            }

            strings.Sort();

            using (writer)
            {
                foreach (var str in strings)
                {
                    writer.WriteLine(str);
                } 
            }         
        }
    }
}
