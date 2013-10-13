using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAndHtmlControls
{
    public partial class T02WebControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonGenerateRandom_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int firstNumber;
            int secondNumber;
            bool isFirstNumber = int.TryParse(this.minValue.Value, out firstNumber);
            bool isSecondNumber = int.TryParse(this.maxValue.Value, out secondNumber);
            if (isFirstNumber && isSecondNumber)
            {
                secondNumber += 1;
                try
                {
                    Response.Write("<h1>" + Convert.ToString(rand.Next(firstNumber, secondNumber)) + "</h1>");
                }
                catch (Exception ex)
                {
                    Response.Write("<h1>" + ex.Message + "</h1>");
                }

            }
            else
            {
                Response.Write("<h1>Invalid input.</h1>");
            }
        }
    }
}