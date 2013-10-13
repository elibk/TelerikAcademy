namespace H03WordsCounter
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class WordsReader
    {
        public Trie ReadSearchedWords(string path)
        {
            StreamReader reader = new StreamReader(path);
            Trie words = new Trie();
            string line;
            StringBuilder word = new StringBuilder();
            using (reader)
            {
                line = reader.ReadLine();
                while (line != null)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] >= 'A' && line[i] <= 'Z')
                        {
                            word.Append((char)(line[i] - 'A' + 'a'));
                        }
                        else if (line[i] >= 'a' && line[i] <= 'z')
                        {
                            word.Append(line[i]);
                        }
                        else
                        {
                            words.Add(word.ToString());
                            word.Clear();
                        }
                    }

                    if (word.Length > 0)
                    {
                        words.Add(word.ToString());
                        word.Clear();
                    }

                    line = reader.ReadLine();
                }
            }

            return words;
        }

        public void CountOccurencesForSearchedWords(string textFilePath, Trie searchedWords)
        {
            StreamReader reader = new StreamReader(textFilePath);
         
            string line;
            StringBuilder word = new StringBuilder();
            using (reader)
            {
                line = reader.ReadLine();
                while (line != null)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] >= 'A' && line[i] <= 'Z')
                        {
                            word.Append((char)(line[i] - 'A' + 'a'));
                        }
                        else if (line[i] >= 'a' && line[i] <= 'z')
                        {
                            word.Append(line[i]);
                        }
                        else
                        {
                            searchedWords.IncreaseWordCount(word.ToString());
                            word.Clear();
                        }
                    }

                    if (word.Length > 0)
                    {
                        searchedWords.IncreaseWordCount(word.ToString());
                        word.Clear();
                    }

                    line = reader.ReadLine();
                }
            }
        }

        public void GetOcurrences(string resultPath, Trie searchedWords)
        {
            StreamWriter writer = new StreamWriter(resultPath);
           
            using (writer)
            {
                Stack<TrieNode> stack = new Stack<TrieNode>();
                stack.Push(searchedWords.Root);

                while (stack.Count > 0)
                {
                    var currentElement = stack.Pop();

                    if (currentElement.Children.Count == 0)
                    {
                        writer.WriteLine(string.Format("'{0}' : occurence -> {1}", currentElement.Value.PadLeft(15), currentElement.Ocuurences.ToString().PadLeft(10)));
                    }

                    foreach (var item in currentElement.Children)
                    {
                        stack.Push(item.Value);
                    }
                }
            }
        }
    }
}