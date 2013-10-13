////
namespace H03InsertsLineNumbers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

   public class InsertsLineNumbers
    {
       private static void Main(string[] args)
        {
            StreamReader read = new StreamReader(@"...\...\TextFile.txt", Encoding.GetEncoding("windows-1251"));
            StreamWriter write = new StreamWriter(@"...\...\Result.txt", true, Encoding.GetEncoding("windows-1251"));
            using (read)
            {
                using (write)
                {
                    int countLine = 1;
                    string line = string.Empty;

                    while (true)
                    {
                        line = read.ReadLine();
                        if (line == null)
                        {
                            break;
                        }

                        write.WriteLine(countLine + " " + line);
                        countLine++;
                    }
                }
            }
        }
    }
}
