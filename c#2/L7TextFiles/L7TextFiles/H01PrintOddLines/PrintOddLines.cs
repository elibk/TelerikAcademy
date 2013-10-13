////
namespace H01PrintOddLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

   public class PrintOddLines
    {
       private static void Main(string[] args)
        {
            StreamReader read = new StreamReader(@"...\...\input.txt", Encoding.GetEncoding("windows-1251"));

            using (read)
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

                        Console.WriteLine(line);
                    }
                    else
                    {
                        line = read.ReadLine();
                    }

                    countLine++;
                }
            }
        }
    }
}
