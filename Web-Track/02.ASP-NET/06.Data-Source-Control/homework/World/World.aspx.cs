using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace World
{
    public partial class World : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ListBoxContintents_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GridView1.PageIndex = this.ListBoxContintents.SelectedIndex;
            this.GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ListView1.SelectedIndex = this.GridView1.SelectedIndex;
            this.ListView1.DataBind();
        }

    }
}