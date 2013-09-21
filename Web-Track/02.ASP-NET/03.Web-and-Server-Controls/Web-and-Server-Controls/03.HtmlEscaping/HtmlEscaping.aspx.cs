using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.HtmlEscaping
{
    public partial class HtmlEscaping : System.Web.UI.Page
    {
        protected void ShowInput(object sender, EventArgs e)
        {
            string input = this.tbInput.Text;
            literalEscapedInput.Visible = false;
            literalEscapedInput.Text = Server.HtmlEncode(input);
            string encoded = literalEscapedInput.Text;
            this.tbResult.Text = encoded;
            this.labelResult.Text = encoded;
        }
    }
}