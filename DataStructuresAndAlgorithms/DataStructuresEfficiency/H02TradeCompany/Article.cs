namespace H02TradeCompany
{
    using System;
    using System.Linq;

    public class Article : IComparable<Article>, IComparable
    {
        private string title;
        private string vendor;
        private string barcode;
        private double price;

        public Article(string vendor, string barcode, string title, double price)
        {
            this.Vendor = vendor;
            this.Barcode = barcode;
            this.Title = title;
            this.Price = price;
        }

        public string Vendor
        {
            get
            {
                return this.vendor;
            }

            protected set
            {
                this.vendor = value;
            }
        }

        public string Barcode
        {
            get
            {
                return this.barcode;
            }

            protected set
            {
                this.barcode = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Value can not contain only white spaces, be null or empty string", "Name");
                }

                this.title = value;
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
            return this.CompareTo(obj as Article);
        }

        public int CompareTo(Article other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Can not compare product with null.");
            }

            return this.Price.CompareTo(other.Price);
        }
    }
}
