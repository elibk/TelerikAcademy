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
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            var queryWord = this.Request.Params["q"];
            this.SerchResultsTitle.InnerText = string.Format("Search Results for Query “{0}”:", queryWord);
        }

        public IEnumerable<LibrarySystem.Models.Book> ListSerachResults_GetData()
        {
            var queryWord = this.Request.Params["q"];

            if (queryWord == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("Query is missing.");
                return null;
            }

            LibrarySystemDBEntities context = new LibrarySystemDBEntities();

            return context.Books.Include("Category").Where( x => x.Title.Contains(queryWord) || x.Author.Contains(queryWord)).OrderBy(x => x.Title).OrderBy(x => x.Title).ThenBy(x => x.Author);
        }
    }
}