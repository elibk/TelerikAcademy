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
    public partial class CreateToDo : System.Web.UI.Page
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

        protected void Page_PreRender(object sender, EventArgs e)
        {
           TaskManagerDataSourceControlsEntities context = new TaskManagerDataSourceControlsEntities();
           var categories = context.Categories.ToList();
           this.CategoryDDL.DataSource = categories;
           this.CategoryDDL.DataBind();
           
        }
     
        protected void CreateToDoList_Click(object sender, EventArgs e)
        {
            using (TaskManagerDataSourceControlsEntities context = new TaskManagerDataSourceControlsEntities())
            {
                ToDoList list = new ToDoList();

                try
                {
                    list.Title = this.TextBoxTitleToDo.Text;
                    list.ContentText = this.TextBoxContentToDo.InnerText;
                    
                    var user = context.AspNetUsers.FirstOrDefault(u => u.Id == this.UserId);
                    list.AspNetUser = user;
                    list.ChangedOn = DateTime.Now;
                    var categoryId = Convert.ToInt32(this.CategoryDDL.SelectedValue);
                    var category = context.Categories.FirstOrDefault(c => c.Id == categoryId);
                    if (category == null)
                    {
                        ErrorSuccessNotifier.AddErrorMessage("Please select category.");
                        return;
                    }

                    
                    list.Category = category;
                    context.ToDoLists.Add(list);
                    context.SaveChanges();
                    ErrorSuccessNotifier.AddSuccessMessage("ToDo is created.");
                    ErrorSuccessNotifier.ShowAfterRedirect = true;
                    this.Response.Redirect("EditToDoList.aspx?id=" + list.Id, false);
                   
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }

           
        }
      
    }
}