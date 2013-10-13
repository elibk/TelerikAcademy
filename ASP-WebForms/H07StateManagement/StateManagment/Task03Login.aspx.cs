using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagment
{
    public partial class Task03Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Random randomGenerator = new Random();

            HttpCookie cookie = new HttpCookie("UserLogedIn", "Loged" + randomGenerator.NextDouble() + DateTime.Now);
            cookie.Expires = DateTime.Now.AddMinutes(1);
            Response.Cookies.Add(cookie);

            this.Response.Redirect("~/Task03Home.aspx");
        }
    }
}