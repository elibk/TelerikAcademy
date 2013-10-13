using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfrows = int.Parse(Console.ReadLine());
            int widht = int.Parse(Console.ReadLine());
            StringBuilder strbulder = new StringBuilder();
            string[] lines = new string[numberOfrows];

            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = Console.ReadLine();
            }

            List<string> words = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                Match match = Regex.Match(lines[i], @"\b[A-Za-z]+\b");
                while (match.Success)
                {
                    string word = match.ToString();
                    words.Add(word);
                    match = match.NextMatch();

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
                    else if (strbulder.Length - 1 == widht)
                    {
                        Console.WriteLine(strbulder.ToString().TrimEnd());
                        break;
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
            Console.WriteLine(words[words.Count - 1]);

        }
    }
}
