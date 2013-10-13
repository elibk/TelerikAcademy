using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntroWebForms
{
    public partial class H01HelloBox : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            this.Greeting.InnerText = "Hello bitch, <br/> I'm rich!";
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            var name = this.UsernameTxt.Text;
            this.Greeting.InnerText = "Hello " + name + " !";
        }
    }
}