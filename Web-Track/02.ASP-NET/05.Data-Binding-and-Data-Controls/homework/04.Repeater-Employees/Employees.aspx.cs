using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _04.Repeater_Employees
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var context = new NorthwindEntities();
                var employees =
                    (from eml in context.Employees
                    select new EmployeeModel
                    {
                        FirstName = eml.FirstName,
                        LastName = eml.LastName,
                        Title = eml.Title
                    }).ToList();

                this.RepeaterEmloyees.DataSource = employees;
                this.RepeaterEmloyees.DataBind();
            }
        }
    }
}