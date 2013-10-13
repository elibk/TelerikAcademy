namespace H03WordsCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TrieNode : IEquatable<TrieNode>
    {
        private TrieNode parent;
      
        private KeyValuePair<char, string> pair;
        private Dictionary<char, TrieNode> children;
        private int ocuurences;

        public TrieNode(TrieNode parent, KeyValuePair<char, string> keyAndValue)
        {
            this.Parent = parent;
            this.pair = keyAndValue;
            this.Ocuurences = 0;
            this.children = new Dictionary<char, TrieNode>();
        }

        public Dictionary<char, TrieNode> Children
        {
            get
            {
                return this.children;
            }

            set
            {
                this.children = value;
            }
        }

        public TrieNode Parent
        {
            get
            {
                return this.parent;
            }

            private set
            {
                this.parent = value;
            }
        }

        public char Key
        {
            get
            {
                return this.pair.Key;
            }
        }

        public string Value
        {
            get
            {
                return this.pair.Value;
            }
        }

        public int Ocuurences
        {
            get
            {
                return this.ocuurences;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                this.ocuurences = value;
            }
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as TrieNode);
        }

        public override int GetHashCode()
        {
            return this.pair.Key.GetHashCode() ^ this.Value.GetHashCode();
        }

        public bool Equals(TrieNode other)
        {
            if (other == null)
            {
                return false;
            }

            if (this.Key == other.Key)
            {
                return true;
            }

            return false;
        }
    }
}