using LibrarySystem.Models;
using Error_Handler_Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystem
{
    public partial class _Default : Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<LibrarySystem.Models.Category> ListViewBooks_GetData()
        {
            LibrarySystemDBEntities context = new LibrarySystemDBEntities();

            return context.Categories.Include("Books").OrderBy(c => c.Title);
        }

        protected void SerachButton_Click(object sender, EventArgs e)
        {
            var queryWord = this.SearchInput.Value;

            if (queryWord == null || queryWord == string.Empty)
            {
                ErrorSuccessNotifier.AddErrorMessage("The serach input can not be empty.");
                return;
            }

            if (queryWord.Length > 20000)
            {
                ErrorSuccessNotifier.AddErrorMessage("Too long query string.");
                return;
            }

            this.Response.Redirect("~/Search.aspx?q=" + queryWord);
        }
    }
}