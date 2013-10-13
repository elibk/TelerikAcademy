namespace CatalogFreeContent
{
    using System;
    using System.Linq;

    public class ContentItem : IComparable, IContent
    {
        private string url;

        public ContentItem(ContentType type, string[] commandParams)
        {
            this.Type = type;
            this.Title = commandParams[(int)ContentPropertie.Title];
            this.Author = commandParams[(int)ContentPropertie.Author];
            this.Size = long.Parse(commandParams[(int)ContentPropertie.Size]);
            this.URL = commandParams[(int)ContentPropertie.Url];
        }

        public string URL
        {
            get
            {
                return this.url;
            }

            set
            {
                this.url = value;
                this.TextRepresentation = this.ToString(); // To update the text representation
            }
        }

        public string Title { get; set; }

        public string Author { get; set; }

        public long Size { get; set; }

        public ContentType Type { get; set; }

        public string TextRepresentation { get; set; }

        public int CompareTo(object obj)
        {
            if (null == obj)
            {
                return 1;
            }

            ContentItem otherContent = obj as ContentItem;
            if (otherContent != null)
            {
                int comparisonResul = this.TextRepresentation.CompareTo(otherContent.TextRepresentation);

                return comparisonResul;
            }

            throw new ArgumentException("Object is not a Content");
        }

        public override string ToString()
        {
            string output = string.Format("{0}: {1}; {2}; {3}; {4}", this.Type.ToString(), this.Title, this.Author, this.Size, this.URL);

            return output;
        }
    }
}
