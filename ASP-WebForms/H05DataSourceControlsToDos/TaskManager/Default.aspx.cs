using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskManager.Models;

namespace TaskManager
{
    public partial class _Default : Page
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
           
            if (this.Page.User.Identity != null && this.Page.User.Identity.IsAuthenticated)
            {
                string userIdto = this.UserId;

                TaskManagerDataSourceControlsEntities context = new TaskManagerDataSourceControlsEntities();

                var tasksCount = context.ToDoLists.Where(t => t.UserId == userIdto).Count();

                this.greetingDisplay.InnerHtml = string.Format("Hello, {0}. You have <a href='LogedUser/AllToDoLists.aspx'>{1} ToDo-s waiting for you</a>.",
                   new Literal() { Text = this.UserName, Mode= LiteralMode.Encode}.Text, tasksCount); 
            }
            else
            {
                this.greetingDisplay.InnerHtml = string.Format("Make your life easier. <a href='Account/Register.aspx'>Sign in </a> to use your personal task manager");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

       
    }
}