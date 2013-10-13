using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataBindingHomework
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDetailsInForm_RedirectCommand(object sender, CommandEventArgs arg)
        {
            Response.Redirect("~/EmployeesFormView.aspx?id=" + int.Parse(arg.CommandArgument.ToString()));
        }

        protected void btnDetailsWithRepiter_RedirectCommand(object sender, CommandEventArgs arg)
        {
            Response.Redirect("~/EmployeesRepeater.aspx?id=" + int.Parse(arg.CommandArgument.ToString()));
        }

        protected void btnDetailsWithKistView_RedirectCommand(object sender, CommandEventArgs arg)
        {
            Response.Redirect("~/EmployeesInListView.aspx?id=" + int.Parse(arg.CommandArgument.ToString()));
        }
        
    }
}