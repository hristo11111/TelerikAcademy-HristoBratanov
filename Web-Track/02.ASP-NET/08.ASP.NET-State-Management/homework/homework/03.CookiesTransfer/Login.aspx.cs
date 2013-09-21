using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.CookiesTransfer
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Login_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                HttpCookie cookie = new HttpCookie("UserName", Server.HtmlEncode(this.TextBox_UserName.Text));
                cookie.Expires = DateTime.Now.AddMinutes(1);

                Response.Cookies.Add(cookie);
                this.Label_Errors.Text = "";
                Page.Response.Redirect("Home.aspx");
            }
            else
            {
                this.Label_Errors.Text = "Username reuqired";
            }
        }
    }
}