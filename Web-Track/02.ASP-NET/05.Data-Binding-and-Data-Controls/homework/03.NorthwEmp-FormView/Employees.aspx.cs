using _03.NorthwEmp_FormView.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.NorthwEmp_FormView
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var context = new NorthwindEntities();
                var employees = context.Employees.ToList();

                this.GridViewEmployees.DataSource = employees;
                this.GridViewEmployees.DataBind();
            }
        }

        protected void gridMembersList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "More")
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                var context = new NorthwindEntities();
                var employee = context.Employees.Where(emp => emp.EmployeeID == id).ToList();

                this.FormViewEmplDetails.DataSource = employee;
                this.FormViewEmplDetails.DataBind();
            }
        }  
    }
}