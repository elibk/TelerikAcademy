using Error_Handler_Control;
using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystem.LoggedUser
{
    public partial class Books : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<LibrarySystem.Models.Book> GridViewBooks_GetData()
        {
            LibrarySystemDBEntities context = new LibrarySystemDBEntities();

            return context.Books.Include("Category").OrderBy(x => x.Title);
        }

        public IQueryable<LibrarySystem.Models.Category> GridViewEditCategories_GetData()
        {
            LibrarySystemDBEntities context = new LibrarySystemDBEntities();

            return context.Categories.OrderBy(c => c.Title);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewBooks_UpdateItem(int id)
        {
            LibrarySystemDBEntities context = new LibrarySystemDBEntities();
            var book = context.Books.Find(id);
            TryUpdateModel(book);
            if (ModelState.IsValid)
            {
                try
                {
                    context.SaveChanges();
                    ErrorSuccessNotifier.AddInfoMessage("Book is edited");
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }

            }      
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewBooks_DeleteItem(int id)
        {
            ErrorSuccessNotifier.AddWarningMessage("Are you sure you want to delete this to do list?");
            this.ConfirmButton.Visible = true;
            this.CanselButton.Visible = true;
            this.storedValue.InnerText = id.ToString();
        }

        public void ActulalDeleteItem(int id)
        {
            LibrarySystemDBEntities context = new LibrarySystemDBEntities();
            var book = context.Books.Find(id);
            context.Books.Remove(book);

            try
            {
                context.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Book is deleted.");

            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }


        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            ActulalDeleteItem(Convert.ToInt32(this.storedValue.InnerText));
        }

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            this.ConfirmButton.Visible = false;
            this.CanselButton.Visible = false;
        }

        protected void CanselButton_Click(object sender, EventArgs e)
        {
            storedValue.InnerText = string.Empty;
        }

        protected void CreateBook_Click(object sender, EventArgs e)
        {
            this.CreateNewBookForm.Visible = true;
            this.CreateBook.Visible = false;
        }

        protected void SubmitBookCreation_Click(object sender, EventArgs e)
        {
            LibrarySystemDBEntities context = new LibrarySystemDBEntities();

            var newBook = new Book()
            {
                Title = this.BookTitle.Value,
                Author = this.BookAuthor.Value,
                Description = this.BookDescription.Value,
                ISBN = this.BookISBN.Value,
                CategoryId = Convert.ToInt32(this.CategoriesDDLNewBook.SelectedValue),
                WebSite = this.BookWebSite.Value
            };

            try
            {
                context.Books.Add(newBook);
                context.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Book added.");
                this.CreateNewBookForm.Visible = false;
                this.CreateBook.Visible = true;
                ClearFields();
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
               
            }
        }

        protected void CancelBookCreation_Click(object sender, EventArgs e)
        {
            this.CreateNewBookForm.Visible = false;
            this.CreateBook.Visible = true;
            ClearFields();

        }

        private void ClearFields()
        {
            this.BookTitle.Value = string.Empty;
            this.BookAuthor.Value = string.Empty;
            this.BookDescription.Value = string.Empty;
            this.BookISBN.Value = string.Empty;

            this.BookWebSite.Value = string.Empty;
        }


    }


}