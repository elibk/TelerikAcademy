using Bookstore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SimpleSearchForBooks
{
   public static class SearchSimple
    {
        static void Main()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../simple-query.xml");
            string title = xmlDoc.GetChildText("/query/title");
            string author = xmlDoc.GetChildText("/query/author");
            string isbn = xmlDoc.GetChildText("/query/isbn");
            var books =
                BookstoreDAL.FindBooksByTitleAuthorAndIsbn(
                    title, author, isbn);
            if (books.Count > 0)
            {
                foreach (var book in books)
                {
                    int reviewsCount =  book.Reviews.Count;
                    if (reviewsCount > 0)
                    {
                        Console.WriteLine("{0}  --> {1} reviews", book.Title, reviewsCount);
                    }
                    else
                    {
                        Console.WriteLine("{0}  --> {1} reviews", book.Title, "no");
                    }
                   
                }
            }
            else
            {
                Console.WriteLine("Nothing found");
            }
        }

        private static string GetChildText(
            this XmlNode node, string xpath)
        {
            XmlNode childNode = node.SelectSingleNode(xpath);
            if (childNode == null)
            {
                return null;
            }
            return childNode.InnerText.Trim();
        }
    }
}
