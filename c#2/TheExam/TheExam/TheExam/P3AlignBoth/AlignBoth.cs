using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P3AlignBoth
{
    class AlignBoth
    {
        static void Main(string[] args)
        {
            //int numberOfrows = int.Parse(Console.ReadLine());
            int widht = 20;

            //string[] lines = new string[numberOfrows];

            //for (int i = 0; i < lines.Length; i++)
            //{
            //    lines[i] = Console.ReadLine();
            //}

            StreamReader read = new StreamReader(@"...\...\TextFile.txt", Encoding.GetEncoding("windows-1251"));
            StringBuilder strbulder = new StringBuilder();
            List<string> words = new List<string>();
            using (read)
            {
                while (true)
                {
                    string line = read.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    Match match = Regex.Match(line, @"\b[A-Za-z]+\b");
                    while (match.Success)
                    {
                        string word = match.ToString();
                        words.Add(word);
                        match = match.NextMatch();

                    }
                }
                
            }

            List<string> corectLines = new List<string>();

            int currentWord = 0;

            while (currentWord < words.Count - 1)
            {
                for (int i = currentWord; currentWord < words.Count - 1; i++)
                {
                    currentWord = i;
                    if (strbulder.Length - 1 + words[i].Length < widht)
                    {                     
                        strbulder.Append(words[i] + " ");
                    }
                    
                    else
                    {
                        corectLines.Add(strbulder.ToString().TrimEnd());
                        break;
                    }
                }
                strbulder.Clear();
            }

            for (int i = 0; i < corectLines.Count; i++)
            {
                while (true)
                {
                    if (corectLines[i].Length < widht)
                    {
                        corectLines[i] = Regex.Replace(corectLines[i], " ", "  ");
                    }
                    else
                    {
                        Console.WriteLine(corectLines[i]);
                        break;
                    }
                }

            }
            Console.WriteLine(words[words.Count-1]);

           

        }
    }
}
