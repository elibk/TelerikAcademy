using Bookstore.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SimpleBooksImport
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../simple-books.xml");
            string xPathQuery = "/catalog/book";

            XmlNodeList booksList = xmlDoc.SelectNodes(xPathQuery);
            foreach (XmlNode bookNode in booksList)
            {
                string author = bookNode.GetChildText("author");
                string title = bookNode.GetChildText("title");
                string url = bookNode.GetChildText("web-site");
                string priceStr = bookNode.GetChildText("price");
                decimal? price = null;
                if (priceStr != null)
                {
                    price = decimal.Parse(priceStr, CultureInfo.InvariantCulture);
                }
               
                string isbn = bookNode.GetChildText("isbn");
                
                BookstoreDAL.AddBookmark(author, title, url, isbn, price);
               // AddBookmark(author, title, url, price, isbn);
            }
        }

        private static string GetChildText(this XmlNode node, string tagName)
        {
            XmlNode childNode = node.SelectSingleNode(tagName);
            if (childNode == null)
            {
                return null;
            }
            return childNode.InnerText.Trim();
        }

        private static void AddBookmark(string author,
            string title, string url, decimal? price, string isbn)
        {
            Console.WriteLine("{0} {1} {2} {3} {4}",
                author, title, url, price, isbn);
        }
    }
}