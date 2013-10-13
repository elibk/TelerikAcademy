using Error_Handler_Control;
using HambergiteConquistador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HambergiteConquistador.Admin
{
    public partial class EditUsers : System.Web.UI.Page
    {


        private IQueryable<AspNetUser> users = new ConquistadorEntities().AspNetUsers.Include("AspNetUserManagement").OrderBy(x => x.UserName);
        private void LoadAllUsers()
        {
            ConquistadorEntities context = new ConquistadorEntities();

            this.users = context.AspNetUsers.Include("AspNetUserManagement");
            this.GridViewEditUsers.DataBind();
        }

        private void LoadActiveUsers()
        {
            ConquistadorEntities context = new ConquistadorEntities();

            this.users = context.AspNetUsers.Include("AspNetUserManagement").Where(u => u.AspNetUserManagement.DisableSignIn == false).OrderBy(x => x.UserName);
            this.GridViewEditUsers.DataBind();
        }


        private void LoadDisabledUsers()
        {
            ConquistadorEntities context = new ConquistadorEntities();

            this.users = context.AspNetUsers.Include("AspNetUserManagement").Where(u => u.AspNetUserManagement.DisableSignIn == true);
            this.GridViewEditUsers.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.User.IsInRole("Admin"))
            //{
            //    this.Response.Redirect("/");
            //}
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<AspNetUser> GridViewEditUsers_GetData()
        {
            return this.users;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewEditUsers_UpdateItem(string id)
        {
            ConquistadorEntities context = new ConquistadorEntities();
            var product = context.AspNetUsers.Find(id);
            TryUpdateModel(product);
            if (ModelState.IsValid)
            {
                try
                {
                    context.SaveChanges();
                    ErrorSuccessNotifier.AddInfoMessage("User is edited");
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }

            }      
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewEditUsers_DeleteItem(string id)
        {
            ConquistadorEntities context = new ConquistadorEntities();
            var user = context.AspNetUsers.Find(id);

            user.AspNetUserManagement.DisableSignIn = true;

            try
            {
                context.SaveChanges();
                ErrorSuccessNotifier.AddInfoMessage("User is disable from sign in");
            }
            catch (Exception ex)
            {

                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
           

        }

        protected void ShowActive_Click(object sender, EventArgs e)
        {
            LoadActiveUsers();
        }

        protected void ShowDisabled_Click(object sender, EventArgs e)
        {
            LoadDisabledUsers();
        }

        protected void ShowAll_Click(object sender, EventArgs e)
        {
            LoadAllUsers();
        }
    }
}