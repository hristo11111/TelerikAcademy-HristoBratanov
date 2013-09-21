using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.PrintBrowserAndClien
{
    public partial class BrowserAndClientIP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonPrint_OnClick(object sender, EventArgs e)
        {
            this.LiteralResult.Text += "Browser type: " + Request.Browser.Type + "<br />";
            this.LiteralResult.Text += "Client IP Address: " + Request.ServerVariables["REMOTE_ADDR"];
        }
    }
}