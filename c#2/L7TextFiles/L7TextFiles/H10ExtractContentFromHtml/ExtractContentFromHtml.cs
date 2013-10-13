////
namespace H10ExtractContentFromHtml
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

   public class ExtractContentFromHtml
    {
       private static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"...\...\html.txt", Encoding.GetEncoding("windows-1251"));
            string file;
            using (reader)
            {
               file = reader.ReadToEnd(); 
            }
            
            StringBuilder result = new StringBuilder();
            int end = file.LastIndexOf('<');
            StreamWriter writer = new StreamWriter(@"...\...\output.txt", false, Encoding.GetEncoding("windows-1251"));

            for (int i = file.IndexOf('>'); i < end; i++)
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

            file = result.ToString();
            file = file.Replace("\r\n ", string.Empty);
            file = file.Replace("   ", " ");

            using (writer)
            {
                writer.Write(file);
            }   
        }
    }
}
