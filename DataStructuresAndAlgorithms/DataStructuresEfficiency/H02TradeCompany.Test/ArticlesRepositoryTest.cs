namespace H02TradeCompany.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ArticlesRepositoryTest
    {
        [TestMethod]
        public void GetProductInPriceRange_GetFiveOfTwo()
        {
            Article[] products = 
            {
                new Article("foo", "21323", "foo", 2.3),
                new Article("foo", "21323", "foo", 6.3),
                new Article("foo2", "21323", "foo", 2.3),
                new Article("foo", "21323", "foo", 3.3),
                new Article("foo1", "21323", "foo", 5.3),
            };

            ArticlesRepository repository = new ArticlesRepository();
            for (int i = 0; i < 5; i++)
            {
                repository.AddProduct(products[i]);
            }
            
            IEnumerable<Article> actual = repository.GetArticleInPriceRange(5, 2, 3);

            Assert.AreEqual(2, actual.Count());
        }

        [TestMethod]
        [Timeout(TestTimeout.Infinite)]
        public void GetProductInPriceRange_500000ProductsAnd10000Searches()
        {
            ArticlesRepository repository = new ArticlesRepository();

            for (int i = 0; i < 100000; i++)
            {
                repository.AddProduct(new Article("foo", "212414", "foo", 2.3 + i));
                repository.AddProduct(new Article("foo", "212414", "foo", 12.3 + i));
                repository.AddProduct(new Article("foo", "212414", "foo", 6.5 + i));
                repository.AddProduct(new Article("foo", "212414", "foo", 3.3 + i));
                repository.AddProduct(new Article("foo", "212414", "foo", 67.3 + i));
            }

            for (int i = 0; i < 5000; i++)
            {
                repository.GetArticleInPriceRange(20, 2, 5);
                repository.GetArticleInPriceRange(20, 5, 10000);
            }
        }
    }
}
