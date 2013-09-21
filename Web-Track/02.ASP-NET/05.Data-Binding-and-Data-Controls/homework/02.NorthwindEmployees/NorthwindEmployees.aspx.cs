using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.NorthwindEmployees
{
    public partial class NorthwindEmployees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var context = new northwindEntities1();
                var employees = context.Employees.ToList();

                this.GridViewEmployees.DataSource = employees;
                this.GridViewEmployees.DataBind();
            }
        }
    }
}