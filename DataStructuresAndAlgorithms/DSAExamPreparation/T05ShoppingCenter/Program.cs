using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace T05ShoppingCenter
{
    class Program
    {

        private static ShoppingCenterRepository repository;
        private static StringBuilder output;
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            output = new StringBuilder();
            repository = new ShoppingCenterRepository();
            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                ParseCommand(Console.ReadLine());
            }

            Console.WriteLine(output);
        }

        private static void ParseCommand(string command)
        {
            string commandName = command.Substring(0, command.IndexOf(' '));
            string[] commandParameters = command.Substring(command.IndexOf(' ') + 1).Split(new char[]{';'},StringSplitOptions.RemoveEmptyEntries);


            switch (commandName)
            {
                case "AddProduct":
                    double price = double.Parse(commandParameters[1].Trim(), CultureInfo.InvariantCulture);
                    repository.AddProduct(commandParameters[0].Trim(), price, commandParameters[2].Trim());
                    output.AppendLine("Product added");
                    break;
                case "FindProductsByName":
                    {
                        var productsFound = repository.FindProductsByName(commandParameters[0].Trim()).OrderBy(x => x.Name).ThenBy(y => y.Provider);
                        bool isAnyFound = false;
                        foreach (var item in productsFound)
                        {
                            isAnyFound = true;
                            output.AppendLine(item.ToString());
                        }

                        if (!isAnyFound)
                        {
                            output.AppendLine("No products found");
                        }
                    }
                    break;
                case "FindProductsByProducer":
                    {
                        var productsFound = repository.FindProductsByProducer(commandParameters[0].Trim()).OrderBy(x => x.Name).ThenBy(y => y.Provider);
                        bool isAnyFound = false;
                        foreach (var item in productsFound)
                        {
                            isAnyFound = true;
                            output.AppendLine(item.ToString());
                        }

                        if (!isAnyFound)
                        {
                            output.AppendLine("No products found");
                        }
                    }
                    break;
                case "FindProductsByPriceRange":
                    {
                        var productsFound = repository.FindProductsByPriceRange(double.Parse(commandParameters[0].Trim(), CultureInfo.InvariantCulture), double.Parse(commandParameters[1].Trim(), CultureInfo.InvariantCulture)).OrderBy(x => x.Name).ThenBy(y => y.Provider);
                        bool isAnyFound = false;
                        
                        foreach (var item in productsFound)
                        {
                            isAnyFound = true;
                            output.AppendLine(item.ToString());
                        }

                        if (!isAnyFound)
                        {
                            output.AppendLine("No products found");
                        }
                    }
                    break;
                case "DeleteProducts":

                    int count = 0;

                    if (commandParameters.Length > 1)
                    {
                       count = repository.DeleteProducts(commandParameters[0].Trim(), commandParameters[1].Trim());
                    }
                    else
                    {
                        count = repository.DeleteProducts(commandParameters[0].Trim());
                    }

                    if (count != 0)
                    {
                        output.AppendFormat("{0} products deleted", count);
                        output.AppendLine();    
                    }
                    else
                    {
                        output.AppendLine("No products found");    
                    }

                    break;
                default:
                    throw new InvalidOperationException("Invalid command");
            }
            
        }
    }

    public class Product : IComparable
    {

        public string Name { get; set; }
        public string Provider { get; set; }
        public double Price { get; set; }

        public Product(string name, double price, string provider)
        {
            this.Name = name;
            this.Provider = provider;
            this.Price = price;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            
            result.Append('{');

            result.Append(this.Name);
            result.Append(';');

            result.Append(this.Provider);
            result.Append(';');

            result.AppendFormat("{0:0.00}", this.Price);

            result.Append('}');
            return result.ToString();
        }

        public override bool Equals(object obj)
        {
            return this.Provider== (obj as Product).Provider;
        }

        public int CompareTo(object obj)
        {
            int sort = this.Name.CompareTo((obj as Product).Name);

            if (sort == 0)
            {
                sort = this.Provider.CompareTo((obj as Product).Provider);
            }

            return sort;
        }
    }

    public class ShoppingCenterRepository
    {
        MultiDictionary<string, Product> dictByName;
        MultiDictionary<string, Product> dictByProducer;
        MultiDictionary<Tuple<string, string>, Product> dictByNameAndProducer;
        OrderedMultiDictionary<double, Product> dictByPrice;

        public ShoppingCenterRepository()
        {
            this.dictByName = new MultiDictionary<string, Product>(true);
            this.dictByProducer = new MultiDictionary<string, Product>(true);
            this.dictByNameAndProducer = new MultiDictionary<Tuple<string, string>, Product>(true);
            this.dictByPrice = new OrderedMultiDictionary<double, Product>(true);
        }

        public void AddProduct(string name, double price, string provider)
        {
            Product newProduct = new Product(name, price, provider);
            dictByName.Add(name, newProduct);
            dictByProducer.Add(provider, newProduct);
            this.dictByNameAndProducer.Add(new Tuple<string, string>(name, provider), newProduct);
            this.dictByPrice.Add(price, newProduct);
        }

        public int DeleteProducts(string name, string provider)
        {
           
            var matchingProducts = this.dictByNameAndProducer[new Tuple<string, string>(name, provider)];
            var result = matchingProducts.Count;
            foreach (var item in matchingProducts)
            {
                this.dictByName.Remove(item.Name, item);
                this.dictByProducer.Remove(item.Provider, item);
                this.dictByPrice.Remove(item.Price, item);
            }
            this.dictByNameAndProducer.Remove(new Tuple<string, string>(name, provider));
            return result;
        }

        public int DeleteProducts(string provider)
        {
            var matchingProducts = this.dictByProducer[provider];
            var result = matchingProducts.Count;
            
            foreach (var item in matchingProducts)
            {
                this.dictByName.Remove(item.Name, item);
                this.dictByNameAndProducer.Remove(new Tuple<string, string>(item.Name, item.Provider), item);
                this.dictByPrice.Remove(item.Price, item);
            }
            this.dictByProducer.Remove(provider);
            return result;
        }

        public IEnumerable<Product> FindProductsByName(string name)
        {
            return this.dictByName[name];
        }

        public IEnumerable<Product> FindProductsByProducer(string producer)
        {
            return this.dictByProducer[producer];
        }

        public IEnumerable<Product> FindProductsByPriceRange(double from, double to)
        {
            var all = this.dictByPrice.Range(from, true, to, true);
            List<Product> products = new List<Product>(all.Count);
            foreach (var item in all)
            {
                foreach (var subItem in item.Value)
                {
                    products.Add(subItem);
                }
            }
            return products;
        }
    }
}
