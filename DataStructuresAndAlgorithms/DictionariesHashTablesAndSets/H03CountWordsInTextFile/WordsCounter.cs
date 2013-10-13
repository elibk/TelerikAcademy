namespace H03CountWordsInTextFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class WordsCounter
    {
        public static void Main(string[] args)
        {
            StreamReader strReader = new StreamReader("input.txt");
            IDictionary<string, int> wordsAndOccurrences = new Dictionary<string, int>();

            using (strReader)
            {
                string line = strReader.ReadLine();
                StringBuilder word = new StringBuilder();
                while (line != null)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] >= 'a' && line[i] <= 'z')
                        {
                            word.Append(line[i]);
                        }
                        else if (line[i] >= 'A' && line[i] <= 'Z')
                        {
                            word.Append((char)(line[i] - 'A' + 'a'));
                        }
                        else
                        {
                            if (word.Length > 0)
                            {
                                AddInDictionary(wordsAndOccurrences, word.ToString());
                                word.Clear();
                            }
                        }
                    }

                    if (word.Length > 0)
                    {
                        AddInDictionary(wordsAndOccurrences, word.ToString());
                        word.Clear();
                    }

                    line = strReader.ReadLine();
                }

                DisplayResult(wordsAndOccurrences);
            }
        }

        private static void AddInDictionary(IDictionary<string, int> wordsAndOccurrences, string word)
        {
            if (!wordsAndOccurrences.ContainsKey(word))
            {
                wordsAndOccurrences.Add(word, 0);
            }

            wordsAndOccurrences[word]++;
        }

        private static void DisplayResult(IDictionary<string, int> numbersAndOccurrences)
        {
            foreach (var number in numbersAndOccurrences)
            {
                Console.WriteLine("{0} --> {1} times.", number.Key, number.Value);
            }
        }
    }
}
