using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Validation
{
    public partial class Task02 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void MatchingPasswordValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = this.TextBoxPasswordRepeat.Text == args.Value;
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Response.Write("Cool you passed the validation!");
                this.formForLogin.Visible = false;
            }

        }

        protected void AcceptValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = this.CheckboxAccept.Checked;
        }
    }
}