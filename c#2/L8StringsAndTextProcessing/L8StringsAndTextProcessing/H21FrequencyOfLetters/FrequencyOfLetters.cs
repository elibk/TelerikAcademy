using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace H21FrequencyOfLetters
{
    class FrequencyOfLetters
    {
        static void Main(string[] args)
        {
            //string input = "aaaaabb bbb3cdd,deeeedssaa";
            string input = Console.ReadLine();

            List<char> letters = new List<char>();
            List<int> lettersFreq = new List<int>();

            Match match = Regex.Match(input, "^[A-Z]|[a-z]{1}");
            int count = new int();
            while (match.Success)
            {
                char letter =char.Parse(match.ToString());
                letters.Add(letter);
                match = Regex.Match(input, letter.ToString());
                while (match.Success)
                {
                    count++;
                    match = match.NextMatch();
                }
                lettersFreq.Add(count);
                count = 0;
                input = input.Replace(letter.ToString(), string.Empty);
                match = Regex.Match(input, "[A-Za-z]{1}");

            }

            for (int i = 0; i < letters.Count; i++)
            {
                Console.WriteLine("{0} - {1} times",letters[i],lettersFreq[i]);
            }
        }
    }
}
