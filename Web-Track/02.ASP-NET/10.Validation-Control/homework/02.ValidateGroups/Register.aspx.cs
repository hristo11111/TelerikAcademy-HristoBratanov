using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.ValidateGroups
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_ValidateLogon_Click(object sender, EventArgs e)
        {
            this.Page.Validate("ValidationGroupLogon");
            if (Page.IsValid)
            {
                this.LabelLogon.Text = "Logon info correct!";
            }
        }
    }
}