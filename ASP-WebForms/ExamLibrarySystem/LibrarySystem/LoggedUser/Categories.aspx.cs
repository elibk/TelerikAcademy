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
    public partial class Categories : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<LibrarySystem.Models.Category> GridViewEditCategories_GetData()
        {
            LibrarySystemDBEntities context = new LibrarySystemDBEntities();

             

            return context.Categories.OrderBy(c => c.Title);
        }

        protected void RequestDeleteCategory_Command(object sender, CommandEventArgs e)
        {
            this.FormCommand.Visible = true;
            ClearSessionRequests();
            var categoryID = Convert.ToInt32(e.CommandArgument);

            if (categoryID == 0)
            {
                ErrorSuccessNotifier.AddErrorMessage("Invalid category Id.");
                return;
            }

            this.RequestCommandText.InnerText = "Confirm Category Deletion?";
            this.RequestedCategoryName.Disabled = true;
            this.Session["DeleteCategory"] = categoryID;
        }

        protected void RequestEditCategory_Command(object sender, CommandEventArgs e)
        {
            ClearSessionRequests();
           
            this.FormCommand.Visible = true;

            var categoryID = Convert.ToInt32(e.CommandArgument);

            if (categoryID == 0)
            {
                ErrorSuccessNotifier.AddErrorMessage("Invalid category Id.");
                return;
            }

            LibrarySystemDBEntities context = new LibrarySystemDBEntities();

            var category = context.Categories.Include("Books").FirstOrDefault(c => c.Id == categoryID);

            if (category != null)
            {
                this.RequestedCategoryName.Value = category.Title;
            }

            this.RequestCommandText.InnerText = "Edit Category";

            this.Session["EditCategory"] = categoryID;
        }

        protected void RequestCreateCategory_Command(object sender, CommandEventArgs e)
        {
            this.FormCommand.Visible = true;
            this.RequestedCategoryName.Value = string.Empty;
            ClearSessionRequests();
            this.Session["CreateNewCategory"] = true;

            this.RequestCommandText.InnerText = "Create New Category";
            this.RequestCreateCategoryButton.Visible = false;
        }

        protected void Comfirm_Click(object sender, EventArgs e)
        {
            if ( this.Session["EditCategory"] != null)
            {
                var categoryId = Convert.ToInt32(this.Session["EditCategory"]);
                var name = this.RequestedCategoryName.Value;
                if (ActualEditCategory(categoryId, name))
                {
                    this.FormCommand.Visible = false;

                    ClearSessionRequests();

                    
                }
            }
            else if (this.Session["CreateNewCategory"] != null)
            {
                var name = this.RequestedCategoryName.Value;
                if (ActualCreateCategory(name))
                {
                    this.FormCommand.Visible = false;


                    ClearSessionRequests();

                    this.RequestCreateCategoryButton.Visible = true;
                } 
            }
            else if (this.Session["DeleteCategory"] != null)
            {
                var categoryId = Convert.ToInt32(this.Session["DeleteCategory"]);
                if ( ActualDeleteCategory(categoryId))
                {
                    this.FormCommand.Visible = false;

                    ClearSessionRequests();
                }
             
            }

            ClearSessionRequests();
        }

        private bool ActualDeleteCategory(int id)
        {
            LibrarySystemDBEntities context = new LibrarySystemDBEntities();

            var category = context.Categories.Include("Books").FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("Category not found.");
                return false;
            }
         
            try
            {
                context.Books.RemoveRange(category.Books);
                context.Categories.Remove(category);
                context.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Category is deleted.");
                return true;
            }
            catch (Exception ex)
            {

                ErrorSuccessNotifier.AddErrorMessage(ex);
                return false;
            }
        }

        private bool ActualCreateCategory( string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                ErrorSuccessNotifier.AddErrorMessage("Category name can not be empty.");
                return false;
            }

            LibrarySystemDBEntities context = new LibrarySystemDBEntities();

            var category = new Category();

            try
            {
                category.Title = name;
                context.Categories.Add(category);
                context.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Category is added.");
                return true;
            }
            catch (Exception ex)
            {

                ErrorSuccessNotifier.AddErrorMessage(ex);
                return false;
            }
        }

        private bool ActualEditCategory(int id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                ErrorSuccessNotifier.AddErrorMessage("Category name can not be empty.");
                return false;
            }

            LibrarySystemDBEntities context = new LibrarySystemDBEntities();

            var category = context.Categories.Include("Books").FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("Category not found.");
                return false;
            }

            try
            {
                category.Title = name;
                context.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Category is edited.");
                return true;
            }
            catch (Exception ex)
            {

                ErrorSuccessNotifier.AddErrorMessage(ex);
                return false;
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            ClearSessionRequests();

            this.FormCommand.Visible = false;
            this.RequestCreateCategoryButton.Visible = true;
        }

        private void ClearSessionRequests()
        {
            this.Session["EditCategory"] = null;

            this.Session["CreateNewCategory"] = null;

            this.Session["DeleteCategory"] = null;
        }

       


    }
}