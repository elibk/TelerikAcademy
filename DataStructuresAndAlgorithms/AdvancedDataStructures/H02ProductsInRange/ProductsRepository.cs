namespace H02ProductsInRange
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class ProductsRepository
    {
        private OrderedBag<Product> repository = new OrderedBag<Product>();

        public int Count
        {
            get 
            {
                return this.repository.Count;
            }
        }

        public void AddProduct(Product newProduct) 
        {
            this.repository.Add(newProduct);
        }

        public void AddProducts(IEnumerable<Product> products)
        {
            this.repository.AddMany(products);
        }

        public IEnumerable<Product> GetProductInPriceRange(int productCounts, double from, double to) 
        {
            var all = this.repository.Range(new Product("Test", from), true, new Product("Test", to), true);
            return all.Take(productCounts);
        }
    }
}
