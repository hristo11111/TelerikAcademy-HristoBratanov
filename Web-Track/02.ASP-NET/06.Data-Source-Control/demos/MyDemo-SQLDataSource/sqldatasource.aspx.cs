using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyDemo_SQLDataSource
{
    public partial class sqldatasource : System.Web.UI.Page
    {

        //protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    this.FormView1.PageIndex = this.ListBox1.SelectedIndex;
        //    this.FormView1.DataBind();
        //}

        protected void ButtonInsert_Click(object sender, EventArgs e)
        {
            this.ListView1.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void ListViewCustomers_ItemInserted(object sender,
            ListViewInsertedEventArgs e)
        {
            this.ListView1.InsertItemPosition = InsertItemPosition.None;
        }
    }
}