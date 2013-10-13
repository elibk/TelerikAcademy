////
namespace H09DeleteOddLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

   public class DeleteOddLines
    {
       private static void Main(string[] args)
        {
            StreamReader read = new StreamReader(@"...\...\input.txt", Encoding.GetEncoding("windows-1251"));
            StreamWriter writer = new StreamWriter(@"...\...\output.txt", false, Encoding.GetEncoding("windows-1251"));

            using (read)
            {
                using (writer)
                {
                    int countLine = 1;
                    string line = string.Empty;

                    while (true)
                    {
                        if (countLine % 2 != 0)
                        {
                            line = read.ReadLine();
                            if (line == null)
                            {
                                break;
                            }

                            writer.WriteLine();
                        }
                        else
                        {
                            line = read.ReadLine();
                            writer.WriteLine(line);
                        }

                        countLine++;
                    }
                }
            }

            File.Replace(@"...\...\output.txt", @"...\...\input.txt", @"...\...\backup.txt");
        }
    }
}
