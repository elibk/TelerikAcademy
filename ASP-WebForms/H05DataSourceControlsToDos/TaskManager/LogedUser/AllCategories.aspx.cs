using Error_Handler_Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskManager.Models;

namespace TaskManager.LogedUser
{
    public partial class AllCategories : System.Web.UI.Page
    {

        private string userId;
        private string userName;

        public string UserId
        {
            get
            {
                if (userId == null)
                {
                    userId = GetCurrentUserId();
                }
                return userId;
            }
        }

        public string UserName
        {
            get
            {
                if (userName == null)
                {
                    userName = this.Page.User.Identity.Name;
                }
                return userName;
            }
        }

        public string GetCurrentUserId()
        {
            TaskManagerDataSourceControlsEntities context = new TaskManagerDataSourceControlsEntities();
            var id = context.AspNetUsers.FirstOrDefault(u => u.UserName == this.UserName).Id;
            return id;
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
        public IQueryable<Category> GridViewCategories_GetData()
        {
            TaskManagerDataSourceControlsEntities context = new TaskManagerDataSourceControlsEntities();
            return context.Categories;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewCategories_DeleteItem(int id)
        {
            ErrorSuccessNotifier.AddWarningMessage("Are you sure you want to delete this category and all to do lists in it?");
            this.ConfirmButton.Visible = true;
            this.CanselButton.Visible = true;
            this.storedValue.InnerText = id.ToString();
        }

        public void GridViewCategories_ActulalDeleteItem(int id)
        {
            TaskManagerDataSourceControlsEntities context = new TaskManagerDataSourceControlsEntities();
            var category = context.Categories.Find(id);
           

            var todos = category.ToDoLists.Where(l => l.UserId == this.UserId);

            context.ToDoLists.RemoveRange(todos);
            context.Categories.Remove(category);
            try
            {
                context.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Category is deleted.");

            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewCategories_UpdateItem(int id)
        {
            TaskManagerDataSourceControlsEntities context = new TaskManagerDataSourceControlsEntities();
            var category = context.Categories.Find(id);
            TryUpdateModel(category);
            if (ModelState.IsValid)
            {
                try
                {
                    context.SaveChanges();
                    ErrorSuccessNotifier.AddInfoMessage("Category is edited");
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex.Message);
                }

            }      
        }

        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            GridViewCategories_ActulalDeleteItem(Convert.ToInt32(this.storedValue.InnerText));
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

        protected void CreateCategory_Click(object sender, EventArgs e)
        {
            TaskManagerDataSourceControlsEntities context = new TaskManagerDataSourceControlsEntities();
            var newCategory = new Category() { Title= this.NewCategoryTitle.Text};
            context.Categories.Add(newCategory);
            try
            {
                context.SaveChanges();
                this.NewCategoryTitle.Text = string.Empty;
                ErrorSuccessNotifier.AddSuccessMessage("Category created.");
            }
            catch (Exception ex)
            {

                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
            
        }
    }
}