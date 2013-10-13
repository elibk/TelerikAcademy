using Bookstore.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SearchForReviews
{
   public static class Program
    {
        static void Main(string[] args)
        {

            Thread.CurrentThread.CurrentCulture =
                  CultureInfo.GetCultureInfo("en-US");
            string fileName = "../../search-results.xml";
            using (XmlTextWriter writer =
                new XmlTextWriter(fileName, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                Stopwatch st = new Stopwatch();
                st.Start();
                writer.WriteStartDocument();
                writer.WriteStartElement("search-results");

                ProcessSearchQueries(writer);

                writer.WriteEndDocument();
                st.Stop();
                Console.WriteLine(st.Elapsed);
            }		

           
        }

        private static void ProcessSearchQueries(XmlTextWriter writer)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../reviews-queries.xml");
            string xPathQuery = "/review-queries/query ";

            XmlNodeList reviewList = xmlDoc.SelectNodes(xPathQuery);
            foreach (XmlNode reviewNode in reviewList)
            {
                IList<Review> reviewFound = new List<Review>();
                string author = reviewNode.GetChildText("author-name");
                if (author != null)
                {
                    reviewFound = BookstoreDAL.FindReviewsByAuthor(author);
                }
                else
                {
                    string startDate = reviewNode.GetChildText("start-date");
                    string endDate = reviewNode.GetChildText("end-date");

                    reviewFound = BookstoreDAL.FindReviewsByPeriod(DateTime.Parse(startDate), DateTime.Parse(endDate));
                }

                WriteReviews(writer, reviewFound);
                //BookstoreDAL.AddBookmark(author, title, url, isbn, price);
                //AddBookmark(author, title, url, price, isbn);
            }
        }

        private static void WriteReviews(
            XmlTextWriter writer, IList<Review> reviews)
        {
            writer.WriteStartElement("result-set");
            foreach (var review in reviews)
            {
                writer.WriteStartElement("review");
                if (review.ReviewDate != null)
                {
                    writer.WriteElementString("date", review.ReviewDate.ToString());
                }
                //if (review.Author != null)
                //{
                //    writer.WriteElementString("title", review.Author.Name);
                //}
                if (review.ReviewText != null)
                {
                    writer.WriteElementString("content", review.ReviewText);
                }
                writer.WriteStartElement("book");

                if (review.Book.Title != null)
                {
                    writer.WriteElementString("title", review.Book.Title);
                }

                if (review.Book.Authors.Count > 0)
                {
                    string tags = string.Join(", ",
                        review.Book.Authors.Select(a => a.Name).OrderBy(a => a));
                    writer.WriteElementString("authors", tags);
                }

                if (review.Book.ISBN != null)
                {
                    writer.WriteElementString("isbn", review.Book.Title);
                }

                 if (review.Book.URL != null)
                {
                    writer.WriteElementString("url", review.Book.Title);
                }


                writer.WriteEndElement();

                writer.WriteEndElement();
            }
            writer.WriteEndElement();
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
