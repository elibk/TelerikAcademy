////
namespace H09ForbiddenWords
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

   public class ForbiddenWords
    {
       private static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"...\...\text.txt", Encoding.GetEncoding("windows-1251"));
            
            string forbiddenWords = "PHP, CLR, Microsoft";

            RemoveWords(reader, forbiddenWords);
        }

        private static void RemoveWords(StreamReader reader, string sequence)
        {
            StreamWriter writer = new StreamWriter(@"...\...\output.txt", false, Encoding.GetEncoding("windows-1251"));
            List<string> words = ConvertToSequenceOfIntegers(sequence);

            string line = string.Empty;
            using (reader)
            {
                using (writer)
                {
                    while (true)
                    {
                        line = reader.ReadLine();
                        if (line == null)
                        {
                            break;
                        }

                        for (int i = 0; i < words.Count; i++)
                        {
                            string replace = "\\b" + words[i] + "\\b";
                            
                            line = Regex.Replace(line, replace, new string('*', replace.Length - 4));
                            //// -4 becouse \b
                        }

                        writer.WriteLine(line);
                    }
                }
            }

            File.Replace(@"...\...\output.txt", @"...\...\text.txt", @"...\...\backup.txt");
        }

        private static List<string> ConvertToSequenceOfIntegers(string sequence)
        {
            List<string> words = new List<string>();
            int count = new int();

            sequence = Regex.Replace(sequence, " ", string.Empty);

            if (sequence.LastIndexOf(',') == sequence.Length - 1)
            {
                sequence = sequence.Substring(0, sequence.Length - 1);
            }

            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] == ',')
                {
                    words.Add(sequence.Substring(i - count, count));
                    count = 0;
                }
                else
                {
                    count++;
                }
            }

            words.Add(sequence.Substring(sequence.Length - count, count));
            count = 0;

            return words;
        }
    }
}
