namespace CatalogFreeContent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Catalog : ICatalog
    {
        private readonly MultiDictionary<string, IContent> url;
        private readonly OrderedMultiDictionary<string, IContent> title;

        public Catalog()
        {
            bool allowDuplicateValues = true;
            this.title = new OrderedMultiDictionary<string, IContent>(allowDuplicateValues);
            this.url = new MultiDictionary<string, IContent>(allowDuplicateValues);
        }

        /// <summary>
        /// Adds the new content element.
        /// </summary>
        /// <param name="content">The content.</param>
        public void Add(IContent content)
        {
            this.title.Add(content.Title, content);
            this.url.Add(content.URL, content);
        }

        /// <summary>
        /// Match content elements in the catalog.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="numberOfContentElementsToList">The number of content elements.</param>
        /// <returns>Matched content elemnts</returns>
        public IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList)
        {
            IEnumerable<IContent> contentToList = from c in this.title[title] select c;

            return contentToList.Take(numberOfContentElementsToList);
        }

        /// <summary>
        /// Updates the content.
        /// </summary>
        /// <param name="oldUrl">The old URL.</param>
        /// <param name="newUrl">The new URL.</param>
        /// <returns></returns>
        public int UpdateContent(string oldUrl, string newUrl)
        {
            int theElements = 0;

            List<IContent> contentToList = this.url[oldUrl].ToList();

            foreach (ContentItem content in contentToList)
            {
                this.title.Remove(content.Title, content);
                theElements++;
            }

            this.url.Remove(oldUrl);

            foreach (IContent content in contentToList)
            {
                content.URL = newUrl;
            }

            ////again
            foreach (IContent content in contentToList)
            {
                this.title.Add(content.Title, content);
                this.url.Add(content.URL, content);
            }

            return theElements;
        }
    }
}
