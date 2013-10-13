using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace H25HTMLContent
{
    class HTMLContent
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"...\...\html.txt",Encoding.GetEncoding("windows-1251"));
            string file = reader.ReadToEnd();
            StringBuilder result = new StringBuilder();
            int end = file.LastIndexOf('<');
            using (reader)
            {
                for (int i = 0; i < end; i++)
                {
                    if (file[i] == '>')
                    {
                        int index = i + 1;
                        while (file[index] != '<')
                        {
                            index++;
                        }

                        result.Append(file.Substring(i + 1, index - (i + 1)));

                        i = index;
                    }
                }


            }

            file = result.ToString();
            file = Regex.Replace(file,@"\s+", " ");
            file = Regex.Replace(file, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);
            Console.WriteLine(file);
        }
    }
}
