using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.NorthwindEmployees
{
    public partial class EmpDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(this.Request["id"]);
            var context = new northwindEntities1();
            var employee = context.Employees.Where(emp => emp.EmployeeID == id).ToList();

            this.DetailsViewEmployee.DataSource = employee;
            this.DetailsViewEmployee.DataBind();
        }
    }
}