using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataBindingHomework
{
    public partial class EmployeesDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            //check if the webpage is loaded for the first time. 
            {
                ViewState["PreviousPage"] = Request.UrlReferrer;//Saves the Previous page url in ViewState 
                NorthwindEntities db = new NorthwindEntities();
                var id = int.Parse(this.Request.QueryString["id"]);

                var employee = db.Employees.Include("Employees1").FirstOrDefault(x => x.EmployeeID == id);

                this.DetailsEmployeeDetails.DataSource = new List<Employee>
                    {
                        employee
                    };

                this.DataBind();
            }


        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            if (ViewState["PreviousPage"] != null) //Check if the ViewState  
                //contains Previous page URL        {
                Response.Redirect(ViewState["PreviousPage"].ToString());
            //Redirect to
            //Previous page by retrieving the PreviousPage Url from ViewState. 
        }
    }
}
