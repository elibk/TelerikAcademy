namespace CatalogFreeContent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface ICatalog
    {
        void Add(IContent content);

        IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList);

        int UpdateContent(string oldUrl, string newUrl);
    }
}
