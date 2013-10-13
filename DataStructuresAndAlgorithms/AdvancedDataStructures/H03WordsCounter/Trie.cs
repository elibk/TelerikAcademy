namespace H03WordsCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Trie
    {
        private TrieNode root;

        public Trie()
        {
            this.root = new TrieNode(null, new KeyValuePair<char, string>(' ', string.Empty));
        }

        public TrieNode Root
        {
            get
            {
                return this.root;
            }
        }

        public void Add(string word) 
        {
            TrieNode newParent = this.root;
            for (int i = 0; i < word.Length; i++)
            {
                if (!newParent.Children.ContainsKey(word[i]))
                {
                    var newNode = new TrieNode(newParent, new KeyValuePair<char, string>(word[i], newParent.Value + word[i]));
                    newParent.Children.Add(word[i], newNode);
                    newParent = newNode;
                }
                else
                {
                    newParent = newParent.Children[word[i]];
                }
            }
        }

        public void IncreaseWordCount(string word)
        {
            TrieNode newParent = this.root;
            for (int i = 0; i < word.Length; i++)
            {
                if (newParent.Children.ContainsKey(word[i]))
                {
                    newParent = newParent.Children[word[i]];
                }
                else
                {
                    return;
                }
            }

            newParent.Ocuurences++;
        }

        public int FindWordOccurence(string word)
        {
            TrieNode newParent = this.root;
            for (int i = 0; i < word.Length; i++)
            {
                if (newParent.Children.ContainsKey(word[i]))
                {
                    newParent = newParent.Children[word[i]];
                }
                else
                {
                    return -1;
                }
            }

            return newParent.Ocuurences;
        }
    }
}