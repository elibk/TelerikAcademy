using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagment
{
    public partial class Task03Home : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UserLogedIn"];
            
            if (cookie == null || cookie.Value == string.Empty)
            {
                this.Response.Redirect("~/Task03Login.aspx");
            }
        }
    }
}