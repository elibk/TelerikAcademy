namespace H03WordsCounter.Test
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TireNodeTest
    {
        [TestMethod]
        public void Add_ThreeWords()
        {
            Trie trie = new Trie();
            trie.Add("Hello");
            trie.Add("Hey");
            trie.Add("Hali");

            Stack<TrieNode> stack = new Stack<TrieNode>();
            stack.Push(trie.Root);

            StringBuilder result = new StringBuilder();
            while (stack.Count > 0)
            {
                var currentElement = stack.Pop();

                if (currentElement.Children.Count == 0)
                {
                    result.Append(string.Format("Key -> {0} value -> {1} |", currentElement.Key, currentElement.Value));
                }

                foreach (var item in currentElement.Children)
                {
                    stack.Push(item.Value);
                }
            }
            ////Assert.AreEqual(" ",result.ToString());
        }

        [TestMethod]
        [Timeout(TestTimeout.Infinite)]
        public void Add_1000WordsIn173MbText()
        {
            WordsReader wordReader = new WordsReader();

            Trie trie = wordReader.ReadSearchedWords("words.txt");

            wordReader.CountOccurencesForSearchedWords("text.txt", trie);
            wordReader.GetOcurrences("result.txt", trie);
        }

        [TestMethod]
        [Timeout(TestTimeout.Infinite)]
        public void Add_SomeWordsInSomeText()
        {
            WordsReader wordReader = new WordsReader();

            Trie trie = wordReader.ReadSearchedWords("words - Copy.txt");

            wordReader.CountOccurencesForSearchedWords("text - Copy.txt", trie);
            wordReader.GetOcurrences("result - Copy.txt", trie);
        }
    }
}