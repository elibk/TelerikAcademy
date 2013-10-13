using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CatalogFreeContent.Test
{
    [TestClass]
  
    public class CatalogTest
    {
        [TestMethod]
        public void Add_AddOneBook()
        {
            IContent contentObject = new ContentItem(ContentType.Book, new string[] {
                "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" });

            Catalog catalog = new Catalog();
            catalog.Add(contentObject);

            IEnumerable<IContent> listOfItems = catalog.GetListContent("Intro C#", 1);
            List<IContent> items = GetNumberOfItems(listOfItems, 1);

            Assert.IsTrue(AreEqual(contentObject, items[0]));
            
        }

        [TestMethod]
        public void CatalogGetTest_WithSetIn()
        {
            Catalog catalog = new Catalog();
            var bookCsharp = new ContentItem(ContentType.Book,
                new string[] { "Intro C#", "C.Nakov", "12763892", "http://www.introprogramming.info" });
            var otherbookCsharp = new ContentItem(ContentType.Book,
                new string[] { "Intro C#", "B.Nakov", "12763892", "http://www.introprogramming.info" });
            var bookJava = new ContentItem(ContentType.Book,
                new string[] { "Intro C#", "A.Nakov", "12763892", "http://www.introprogramming.info" });
            var bookPerl = new ContentItem(ContentType.Book,
                new string[] { "Intro Perl", "S.Nakov", "12763892", "http://www.introprogramming.info" });


            catalog.Add(bookPerl);
            catalog.Add(otherbookCsharp);
            catalog.Add(bookCsharp);
            catalog.Add(bookJava);
            var matchingElements = catalog.GetListContent("Intro C#", 3);
            Assert.AreEqual(3, GetCountOfItems(matchingElements));

            string[] actual = 
            { 
               "Book: Intro C#; A.Nakov; 12763892; http://www.introprogramming.info",
               "Book: Intro C#; B.Nakov; 12763892; http://www.introprogramming.info",
               "Book: Intro C#; C.Nakov; 12763892; http://www.introprogramming.info"
                                                                                    };
            string[] expected = new string[3];

            var i = 0;
            foreach (var item in matchingElements)
            {
                expected[i] = item.ToString();
                i++;
            }

            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void CatalogUpdateContent_ThreeMatchingElements()
        {
            Catalog catalog = new Catalog();
            var bookCsharp = new ContentItem(ContentType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.csharp.info" });
            var bookJava = new ContentItem(ContentType.Book,
                new string[] { "Intro Java", "S.Nakov", "12763892", "http://www.java.info" });
            var bookPerl = new ContentItem(ContentType.Book,
                new string[] { "Intro Perl", "S.Nakov", "12763892", "http://www.perl.info" });

            catalog.Add(bookCsharp);
            catalog.Add(bookJava);
            catalog.Add(bookPerl);
            catalog.UpdateContent("http://www.java.info", "http://www.csharp.info");
            catalog.UpdateContent("http://www.csharp.info", "http://telerikacademy.com");
            catalog.UpdateContent("http://www.perl.info", "http://telerikacademy.com");
            var matching = catalog.UpdateContent("http://telerikacademy.com", "http://telerik.com");

            Assert.AreEqual(3, matching);
        }

        [TestMethod]
        public void CatalogUpdateContent_OneMatchingAndFewNot()
        {
            Catalog catalog = new Catalog();
            var bookCsharp = new ContentItem(ContentType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.csharp.info" });
            var bookJava = new ContentItem(ContentType.Book,
                new string[] { "Intro Java", "S.Nakov", "12763892", "http://www.java.info" });
            var bookPerl = new ContentItem(ContentType.Book,
                new string[] { "Intro Perl", "S.Nakov", "12763892", "http://www.perl.info" });

            catalog.Add(bookCsharp);
            // catalog.Add(bookCsharp);
            //  catalog.Add(bookCsharp);
            catalog.Add(bookJava);
            catalog.Add(bookPerl);
            var updatedItems = catalog.UpdateContent("http://www.java.info", "http://www.csharp.info");


            Assert.AreEqual(1, updatedItems);
        }


        [TestMethod]
        public void CatalogUpdateContent_3000Items()
        {
            StringBuilder input = new StringBuilder();

            for(var i=0;i<3000;i++)
            {
                input.AppendLine("Add movie: mov; au; 42323723; http://movie.com");
            }
            input.AppendLine("Update: http://movie.com; http://othermovie.com");
            input.AppendLine("End");

            var expectedOutput = new StringBuilder();

            for (var i = 0; i <3000; i++)
            {
                expectedOutput.AppendLine("Movie added");
            }
            expectedOutput.AppendLine("3000 items updated");
            
            //redirecting console 
            Console.SetIn(new StringReader(input.ToString()));
            StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            CatalogFreeContent.Program.Main();

            //Assert 
            string expected = expectedOutput.ToString();
            string actual = consoleOutput.ToString();
            Assert.AreEqual(expected, actual);
            
        }

        private bool AreEqual(IContent firstItem, IContent secondItem)
        {
            if (firstItem.Title == secondItem.Title &&
                firstItem.Type.Equals(secondItem.Type) &&
                firstItem.Author == secondItem.Author &&
                firstItem.URL == secondItem.URL)
            {
                return true;
            }

            return false;
        }

        private List<IContent> GetNumberOfItems(IEnumerable<IContent> listOfItems, uint itemsCount)
        {
            List<IContent> items = new List<IContent>();
            uint count = 1;
            foreach (var item in listOfItems)
            {
                if (count > itemsCount)
                {
                    break;
                }
                items.Add(item);
                count++;
            }

            return items;
        }

        private int GetCountOfItems(IEnumerable<IContent> listOfItems)
        {
           
            int count = 0;
            foreach (var item in listOfItems)
            {
                count++;
            }

            return count;
        }
    }
}
