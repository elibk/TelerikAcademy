using Bookstore.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ComplexBooksImport
{
  public static class ComplexImport
    {
        public static void Main(string[] args)
      {
          XDocument xmlDoc = XDocument.Load("../../complex-books.xml");
          var books =
              from book in xmlDoc.Descendants("book")
              select
                  new Book 
                  {
                      Title = book.Element("title").Value,
                      ISBN = GetChildText(book, "isbn"),
                      URL = GetChildText(book, "web-site"),
                      Price = GetChildDecimal(book, "price"),
                      Authors = GetChildAuthors(book, "authors"),
                      Reviews = GetChildReviews(book, "reviews")
                  };

          BookstoreDAL.AddBookmarkWithReviews(books);
         
        }

        private static ICollection<Review> GetChildReviews(XElement element, string elName)
        {
            List<Review> reviews = new List<Review>();

            var reviewEl = element.Element(elName);
            if (reviewEl != null)
            {
                foreach (XElement review in reviewEl.Elements())
                {
                    bool hasDate = false;
                    Review reviewObj = new Review();
                    reviewObj.ReviewText = review.Value;
                    foreach (var atr in review.Attributes())
                    {
                        if (atr.Name == "date")
                        {
                            reviewObj.ReviewDate = DateTime.Parse(atr.Value);
                            hasDate = true;
                        }
                        else if (atr.Name == "author")
                        {
                            reviewObj.Author = new Author { Name = atr.Value };
                        }
                    }
                    if (!hasDate)
                    {
                        reviewObj.ReviewDate = DateTime.Now;
                    }
                    reviews.Add(reviewObj);
                }
            }

            return reviews;
        }

        private static ICollection<Author> GetChildAuthors(XElement element, string elName)
        {
            List<Author> authors = new List<Author>();

            var authorsEl = element.Element(elName);
            if (authorsEl != null)
            {
                foreach (XElement author in authorsEl.Elements())
                {
                    authors.Add(new Author { Name = author.Value });
                }
            }

            return authors;
        }

        private static string GetChildText(XElement element, string elName)
        {
            var innerElement = element.Element(elName);
            if (innerElement != null)
            {

                return innerElement.Value;
            }
            else
            {
                return null;
            }
        }

        private static decimal? GetChildDecimal(XElement element, string elName)
        {
            var innerElement = element.Element(elName);
            if (innerElement != null)
            {

                return decimal.Parse(innerElement.Value, CultureInfo.InvariantCulture);
            }
            else
            {
                return null;
            }
        }

    }
}
