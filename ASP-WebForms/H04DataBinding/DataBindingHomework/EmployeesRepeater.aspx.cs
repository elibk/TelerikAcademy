using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataBindingHomework
{
    public partial class EmployeesRepeater : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = int.Parse(this.Request.QueryString["id"]);

            this.EntityDataSourceEmployees.Where = "it.EmployeeID = @EmpID";
            this.EntityDataSourceEmployees.WhereParameters.Add(new Parameter("EmpID", TypeCode.Int32, id.ToString()));
            this.RepeaterViewEmployee.DataSource = this.EntityDataSourceEmployees;

            this.DataBind();
        }
    }
}