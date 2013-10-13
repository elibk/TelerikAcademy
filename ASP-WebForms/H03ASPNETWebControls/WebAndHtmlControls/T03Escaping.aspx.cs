using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAndHtmlControls
{
    public partial class T03Escaping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ButtonExchangeValues_Click(object sender, EventArgs e)
        {
            var firstValue = this.firstTxtBox.Text;
            var secondVal = this.secondTxtBox.Text;

            this.firstTxtBox.Text = secondVal;
            this.secondTxtBox.Text = firstValue;

            this.displayField.Text = string.Format("Exchanged '{0}' with '{1}'.", firstValue, secondVal);
        }
    }
}