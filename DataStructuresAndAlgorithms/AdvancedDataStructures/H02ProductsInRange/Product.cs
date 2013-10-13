namespace H02ProductsInRange
{
    using System;
    using System.Linq;

    public class Product : IComparable<Product>, IComparable
    {
        private string name;
        private double price;

        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Value can not contain only white spaces, be null or empty string", "Name");
                }

                this.name = value;
            }
        }

        public double Price
        {
            get
            {
                return this.price;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price", value, "Value can not be negative number");
                }

                this.price = value;
            }
        }

        public int CompareTo(object obj)
        {
            return this.CompareTo(obj as Product);
        }

        public int CompareTo(Product other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Can not compare product with null.");
            }

            return this.Price.CompareTo(other.Price);
        }
    }
}
