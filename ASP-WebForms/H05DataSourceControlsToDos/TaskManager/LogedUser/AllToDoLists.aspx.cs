using Error_Handler_Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskManager.Models;

namespace TaskManager
{
    public partial class AllToDoLists : System.Web.UI.Page
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
            this.ContentToDoDisplay.InnerText = string.Empty;
        }
    
        public IQueryable<ToDoList> GridViewToDoLists_GetData()
        {
            TaskManagerDataSourceControlsEntities context = new TaskManagerDataSourceControlsEntities();
            return context.ToDoLists.Include("Category").Where(
                    a => a.UserId == this.UserId).OrderBy(l => l.Category.Title);
        }

        public IQueryable<Category> DropDownList_Categories()
        {
            TaskManagerDataSourceControlsEntities context = new TaskManagerDataSourceControlsEntities();
            return context.Categories.OrderBy(c => c.Title);
        }
        protected void GridViewQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaskManagerDataSourceControlsEntities context = new TaskManagerDataSourceControlsEntities();
            int todDoId = Convert.ToInt32(
                this.GridViewToDoLists.SelectedDataKey.Value);
            this.ContentToDoDisplay.InnerText = context.ToDoLists.FirstOrDefault(t => t.Id == todDoId).ContentText;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewToDoLists_RequestDelete(int id)
        {
            ErrorSuccessNotifier.AddWarningMessage("Are you sure you want to delete this to do list?");
            this.ConfirmButton.Visible = true;
            this.CanselButton.Visible = true;
            this.storedValue.InnerText = id.ToString();
        }

        public void GridViewToDoLists_ActulalDeleteItem(int id)
        {
            TaskManagerDataSourceControlsEntities context = new TaskManagerDataSourceControlsEntities();
            var toDo = context.ToDoLists.Find(id);
            context.ToDoLists.Remove(toDo);

            try
            {
                context.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("To Do is deleted.");
                
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }
     
        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewToDoLists_UpdateItem(int id)
        {
            TaskManagerDataSourceControlsEntities context = new TaskManagerDataSourceControlsEntities();
            var product = context.ToDoLists.Find(id);
            TryUpdateModel(product);
            if (ModelState.IsValid)
            {
                try
                {
                    context.SaveChanges();
                    ErrorSuccessNotifier.AddInfoMessage("ToDoList is edited");
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }

            }      
        }

        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            GridViewToDoLists_ActulalDeleteItem(Convert.ToInt32(this.storedValue.InnerText));
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
    }
}