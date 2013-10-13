////
namespace H04ComparesTwoFiles
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

   public class ComparesTwoFiles
    {
       private static void Main(string[] args)
        {
            StreamReader readerOne = new StreamReader(@"...\...\TextFile1.txt", Encoding.GetEncoding("windows-1251"));
            StreamReader readerTwo = new StreamReader(@"...\...\TextFile2.txt", Encoding.GetEncoding("windows-1251"));
            StreamWriter write = new StreamWriter(@"...\...\Result.txt", true, Encoding.GetEncoding("windows-1251"));

            using (readerOne)
            {
                using (readerTwo)
                {
                    using (write)
                    {
                        string line = string.Empty;

                        while (true)
                        {
                            line = readerOne.ReadLine();
                            if (line == null)
                            {
                                break;
                            }

                            if (line == readerTwo.ReadLine())
                            {
                                write.WriteLine(line);
                            }
                        }
                    }
                }
            }
        }
    }
}
