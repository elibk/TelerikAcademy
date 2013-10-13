////
namespace H13ReversesWordsInSentence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ReversesWordsInSentence
    {
       private static void Main(string[] args)
        {
            string sentence = "C# is, not, C++, not PHP and not Delphi.";

            sentence = ReverseWords(sentence);

            Console.WriteLine(sentence);
        }

        private static string ReverseWords(string sequence)
        {
            List<string> words = new List<string>();
            int count = new int();
            List<int> commaPositions = new List<int>();
            char endOfsentence = sequence[sequence.Length - 1];

            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] == ',')
                {
                    words.Add(sequence.Substring(i - count, count) + " ");
                    count = 0;
                    commaPositions.Add(words.Count);
                    i++;
                }
                else if (sequence[i] == ' ')
                {
                    words.Add(sequence.Substring(i - count, count + 1));
                    count = 0;                  
                }
                else
                {
                    count++;
                }
            }

            words.Add(sequence.Substring(sequence.Length - count, count - 1) + " ");
            count = 0;

            words[0] = words[0].Substring(0, words[0].Length - 1);
            ////removing the space before the end

            StringBuilder reversed = new StringBuilder();

            for (int i = 0, wordInd = words.Count - 1; wordInd >= 0; i++, wordInd--)
            {
                if (commaPositions.IndexOf(i) >= 0)
                {
                    reversed.Append(", ");
                }

                reversed.Append(words[wordInd]);
            }

            reversed.Append(endOfsentence);

            sequence = reversed.ToString();
            sequence = sequence.Replace(" ,", ",");

            return sequence;
        }
    }
}
