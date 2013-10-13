using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace H22FrequencyOfWords
{
    class FrequencyOfWords
    {
        static void Main(string[] args)
        {
            //@"\b([A-Za-z]+(-[A-Za-z]+)|[A-Za-z]+\b";
            ///string input ="I strong-armed one boy to get me (bring me) one non-alcoholic drink, while I was playnig one last game on the one-armed bandit.";
            string input = Console.ReadLine();
            string pattern = @"\b([A-Za-z]+-?[A-Za-z]+)|[A-Za-z]+\b";
            List<string> words = new List<string>();
            List<int> wordsFreq = new List<int>();

            Match match = Regex.Match(input, pattern);
            int count = new int();
            while (match.Success)
            {
                string word = match.ToString();
                words.Add(word);
                match = Regex.Match(input, "\\b"+word+@"[.,!?;:)\s]+");
                while (match.Success)
                {
                    count++;
                    match = match.NextMatch();
                }
                wordsFreq.Add(count);
                count = 0;
                input = Regex.Replace(input, "\\b" + word + @"[.,!?;:)\s]+", string.Empty);
                match = Regex.Match(input, pattern);

            }

            for (int i = 0; i < words.Count; i++)
            {
                Console.WriteLine("{0} - {1} times", words[i], wordsFreq[i]);
            }
        }
    }
}
