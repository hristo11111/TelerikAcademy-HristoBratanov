using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;

namespace demo
{
    public partial class mycontrol : System.Web.UI.UserControl
    {
        public void LoadData(Menu menu)
        {
            this.DataList.DataSource = menu.MenuItems;
            this.DataList.DataBind();
        }

        private Color fontColor;

        public Color FontColor
        {
            get { return this.fontColor; }
            set { this.fontColor = value; }
        }

        private string fontName;

        public string FontName
        {
            get { return this.fontName; }
            set { this.fontName = value; }
        }

        protected void DataList_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
        {
            foreach (DataListItem item in this.DataList.Items)
            {
                HyperLink link = (HyperLink)item.FindControl("hyperlink1");
                link.ForeColor = this.fontColor;
                link.Font.Name = this.fontName;
            }
        }
    }
}