using Error_Handler_Control;
using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystem
{
    public partial class BookDetails : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            var bookId = Convert.ToInt32(this.Request.Params["id"]);

            if (bookId == 0)
            {
                ErrorSuccessNotifier.AddErrorMessage("Invalid book id parameter");
                return;
            }

            LibrarySystemDBEntities context = new LibrarySystemDBEntities();

            var book = context.Books.FirstOrDefault(b => b.Id== bookId);

            if (book == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("Book not found.");
                return;
            }

            this.BookTitle.InnerText = book.Title;
            this.BookAuthor.InnerText = "by " + book.Author;
            this.BookISBN.InnerText = "ISBN: " + book.ISBN;
            this.BookWebSite.InnerHtml = string.Format("Web site <a href='{0}'>{0}</a>", Server.HtmlEncode(book.WebSite));

            this.BookDescription.InnerText = book.Description;
        }
    }
}