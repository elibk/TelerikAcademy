////
namespace H02ConcatenateTextFiles
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class ConcatenateTextFiles
    {
       private static void Main(string[] args)
        {
            StreamReader read = new StreamReader(@"...\...\TextFile1.txt", Encoding.GetEncoding("windows-1251"));
            string textFile1 = string.Empty;
            
            using (read)
            {
                textFile1 = read.ReadToEnd();
            }

            string textFile2 = string.Empty;
            read = new StreamReader(@"...\...\TextFile2.txt", Encoding.GetEncoding("windows-1251"));

            using (read)
            {
                textFile2 = read.ReadToEnd();
            }

            StreamWriter write = new StreamWriter(@"...\...\Result.txt", true, Encoding.GetEncoding("windows-1251"));

            using (write)
            {
                write.WriteLine(textFile1);
                write.WriteLine();
                write.WriteLine(textFile2);
            }
        }
    }
}
