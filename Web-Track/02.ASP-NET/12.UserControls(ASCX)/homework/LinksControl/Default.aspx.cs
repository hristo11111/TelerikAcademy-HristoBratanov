using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinksControl
{
    public partial class Default : System.Web.UI.Page
    {
        private Menu menu = new Menu()
        {
            MenuItems = new List<MenuItem>()
                {
                    new MenuItem() {Url = "http://nakov.com", Title = "Nakov site"},
                    new MenuItem() {Url = "http://telerikacademy.com", Title = "Telerik Academy site"}
                }
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            this.lbl.LoadData(menu);
        }
    }
}