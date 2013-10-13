using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace H20ExtractPalindromes
{
    class ExtractPalindromes
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"...\...\text.txt", Encoding.GetEncoding("windows-1251"));
            string datePattern = @"\b[A-Za-z]{2,}|[1-9]{2,}\b";

            List<string> palindromes = new List<string>();

            using (reader)
            {
                while (true)
                {
                    string line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }
                    Match match = Regex.Match(line, datePattern);
                    while (match.Success)
                    {
                        string palindrome = match.ToString().ToUpper();
                        bool check = true;
                        for (int beginning = 0, ending = palindrome.Length-1; beginning < palindrome.Length/2; beginning++,ending--)
                        {
                            if (palindrome[beginning] != palindrome[ending])
                            {
                                check = false;
                                break;
                            }
                        }
                        if (check && palindromes.IndexOf(palindrome) < 0)
                        {
                            palindromes.Add(palindrome);
                        }
                        
                        match = match.NextMatch();

                    }
                    
                }
                for (int i = 0; i < palindromes.Count; i++)
                {
                    Console.WriteLine(palindromes[i]);
                }
            }
        }
    }
}
