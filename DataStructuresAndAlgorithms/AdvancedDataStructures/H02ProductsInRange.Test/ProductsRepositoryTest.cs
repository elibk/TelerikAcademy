namespace H02ProductsInRange.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ProductsRepositoryTest
    {
        [TestMethod]
        public void GetProductInPriceRange_GetFiveOfTwo()
        {
            Product[] products = 
            {
                new Product("foo", 2.3),
                new Product("foo", 6.3),
                new Product("foo2", 2.3),
                new Product("foo", 3.3),
                new Product("foo1", 5.3),
                new Product("foo2", 1.3),
            };

            ProductsRepository repository = new ProductsRepository();
            repository.AddProducts(products);

            IEnumerable<Product> actual = repository.GetProductInPriceRange(5, 2, 3);

            Assert.AreEqual(2, actual.Count());
        }

        [TestMethod]
        [Timeout(TestTimeout.Infinite)]
        public void GetProductInPriceRange_500000ProductsAnd10000Searches()
        {
            ProductsRepository repository = new ProductsRepository();

            IEnumerable<Product> actual = repository.GetProductInPriceRange(5, 2, 3);

            for (int i = 0; i < 100000; i++)
            {
                repository.AddProduct(new Product("foo", 2.3 + i));
                repository.AddProduct(new Product("foo", 12.3 + i));
                repository.AddProduct(new Product("foo", 6.5 + i));
                repository.AddProduct(new Product("foo", 3.3 + i));
                repository.AddProduct(new Product("foo", 67.3 + i));
            }

            for (int i = 0; i < 5000; i++)
            {
                repository.GetProductInPriceRange(20, 2, 5);
                repository.GetProductInPriceRange(20, 5, 100);
            }

            Assert.AreEqual(500000, repository.Count);
        }
    }
}