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
    public partial class EditToDoList : System.Web.UI.Page
    {

        private int toDoListId;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.toDoListId =
                Convert.ToInt32(Request.Params["id"]);
        }

        protected void UpdateToDoList_Click(object sender, EventArgs e)
        {
            using (TaskManagerDataSourceControlsEntities context = new TaskManagerDataSourceControlsEntities())
            {
                ToDoList list = context.ToDoLists.Find(this.toDoListId);
                
                try
                {
                    list.Title = this.TextBoxTitleToDo.Text;
                    list.ContentText = this.TextBoxContentToDo.InnerText;
                    context.SaveChanges();
                    ErrorSuccessNotifier.AddInfoMessage("ToDo is updated.");
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            using (TaskManagerDataSourceControlsEntities context = new TaskManagerDataSourceControlsEntities())
            {
                ToDoList list = context.ToDoLists.Find(toDoListId);
                this.TextBoxTitleToDo.Text = list.Title;
                this.TextBoxContentToDo.InnerText = list.ContentText;
            }
        }
    }
}