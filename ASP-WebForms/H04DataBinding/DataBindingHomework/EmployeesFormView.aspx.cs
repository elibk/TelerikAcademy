using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataBindingHomework
{
    public partial class EmployeesFormView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = int.Parse(this.Request.QueryString["id"]);

            NorthwindEntities db = new NorthwindEntities();

            var employee = db.Employees.Include("Employees1").FirstOrDefault(x => x.EmployeeID == id);


            this.FormViewEmployee.DataSource = new List<Employee>
            {
                employee
            };

            this.DataBind();
        }
    }
}