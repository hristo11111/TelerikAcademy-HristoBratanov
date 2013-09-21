using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_forms_Intro
{
    public partial class HelloName : System.Web.UI.Page
    {
        protected void PrintName(object sender, EventArgs e)
        {
            string name = this.tbInputName.Text;
            this.lblOutputName.Text = name;

            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            this.lblPath.Text = path;
        }
    }
}