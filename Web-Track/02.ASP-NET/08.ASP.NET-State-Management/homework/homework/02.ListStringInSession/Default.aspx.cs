using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.ListStringInSession
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Save_Click(object sender, EventArgs e)
        {
            List<string> storageList = (List<string>)Session["storage"];
            if (storageList == null)
            {
                storageList = new List<string>();
            }
            string input = Server.HtmlEncode(this.TextBox_Input.Text);
            storageList.Add(input);
            Session["storage"] = storageList;
        }
    }
}