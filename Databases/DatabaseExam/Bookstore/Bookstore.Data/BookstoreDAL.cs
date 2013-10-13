using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Transactions;
using System.Text.RegularExpressions;

namespace Bookstore.Data
{
    public static class BookstoreDAL
    {

        public static void AddBookmark(string author,
             string title, string url, string isbn, decimal? price)
        {
            BookstoreEntities context = new BookstoreEntities();
            Book newBook = new Book();
            Author authorObj = CreateOrLoadAuthor(context, author);

            newBook.Title = title;
            newBook.URL = url;
            newBook.Price = price;
            newBook.ISBN = isbn;
            newBook.Authors.Add(authorObj);

            context.Books.Add(newBook);
            context.SaveChanges();
        }

        public static void AddBookmarkWithReviews(IEnumerable<Book> books)
        {
            BookstoreEntities context = new BookstoreEntities();


            foreach (var book in books)
            {
                TransactionScope tran = new TransactionScope(
            TransactionScopeOption.Required,
                new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.RepeatableRead
                });

                using (tran)
                {
                    List<Author> updatedAuthors = new List<Author>();
                    if (book.Authors != null)
                    {
                        foreach (var author in book.Authors)
                        {
                            var updatedAuthor = CreateOrLoadAuthor(context, author.Name);
                            updatedAuthors.Add(updatedAuthor);
                        }
                    }

                    if (updatedAuthors.Count > 0)
                    {
                        book.Authors = updatedAuthors;
                    }

                    if (book.Reviews != null)
                    {
                        foreach (var review in book.Reviews)
                        {
                            if (review.Author != null)
                            {
                                var updatedAuthor = CreateOrLoadAuthor(context, review.Author.Name);
                                review.Author = updatedAuthor;
                            }
                        }
                    }

                    context.Books.Add(book);
                    context.SaveChanges();
                    tran.Complete();
                }

            }
        }

        private static Author CreateOrLoadAuthor(
            BookstoreEntities context, string authorName)
        {
            Author existingUser =
                (from a in context.Authors
                 where a.Name.ToLower() == authorName.ToLower()
                 select a).FirstOrDefault();
            if (existingUser != null)
            {
                return existingUser;
            }

            Author newUser = new Author();
            newUser.Name = authorName;
            context.Authors.Add(newUser);
            context.SaveChanges();

            return newUser;
        }

        public static IList<Book> FindBooksByTitleAuthorAndIsbn(
            string title, string author, string isbn)
        {
            BookstoreEntities context = new BookstoreEntities();
            var bookQuery =
                from b in context.Books.Include("Review")
                select b;
            if (title != null)
            {
                bookQuery =
                    from b in context.Books
                    where b.Title == title
                    select b;
            }

            if (isbn != null)
            {
                bookQuery = bookQuery.Where(
                    b => b.ISBN == isbn);
            }
            if (author != null)
            {
                bookQuery = bookQuery.Where(
                    b => b.Authors.Any(a => a.Name == author));
            }
            bookQuery = bookQuery.OrderBy(b => b.Title);

            return bookQuery.ToList();
        }

        public static IList<Review> FindReviewsByAuthor(string author)
        {
            BookstoreEntities context = new BookstoreEntities();
            var booksQuery =
                from r in context.Reviews.Include("Book").Include("Author")
                select r;
           
                booksQuery = booksQuery.Where(
                    r => r.Author.Name == author);
         
            booksQuery = booksQuery.OrderBy(r => r.ReviewDate);
            return booksQuery.ToList();
            
        }

        public static IList<Review> FindReviewsByPeriod(DateTime startDate, DateTime endDate)
        {
            BookstoreEntities context = new BookstoreEntities();
            var booksQuery =
                from r in context.Reviews.Include("Book").Include("Author")
                select r;

            booksQuery = booksQuery.Where(
                r => (r.ReviewDate >= startDate && r.ReviewDate <= endDate));

            booksQuery = booksQuery.OrderBy(r => r.ReviewDate);
            return booksQuery.ToList();
        }
    }

}
