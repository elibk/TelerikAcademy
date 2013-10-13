using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagment
{
    public partial class Task02 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitUserInput_Click(object sender, EventArgs e)
        {
            if (Session["userInputs"] == null)
	        {
                Session.Add("userInputs", new List<string>());
	        }

           var userInputs = (Session["userInputs"] as List<string>);
           userInputs.Add(this.UserInput.Text);

           this.UserInputs.Text = Server.HtmlEncode(string.Join(", ", userInputs));
        }
    }
}