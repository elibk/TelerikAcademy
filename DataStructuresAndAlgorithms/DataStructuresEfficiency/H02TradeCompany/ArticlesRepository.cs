namespace H02TradeCompany
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class ArticlesRepository
    {
        private OrderedMultiDictionary<double, Article> repository = new OrderedMultiDictionary<double, Article>(true);

        public int Count
        {
            get
            {
                return this.repository.Count;
            }
        }

        public void AddProduct(Article newProduct)
        {
            this.repository.Add(newProduct.Price, newProduct);
        }

        public IEnumerable<Article> GetArticleInPriceRange(int articlesCounts, double from, double to)
        {
            var all = this.repository.Range(from, true, to, true);
            var forReturn = all.Values.Take(articlesCounts);

            return forReturn;
        }
    }
}
