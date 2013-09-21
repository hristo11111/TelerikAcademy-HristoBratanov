using PollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PollSystem
{
    public partial class ViewAllResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MyPollSystemEntities context = new MyPollSystemEntities();
            var questions = context.Questions.ToList();
            this.GridView.DataSource = questions;
            this.DataBind();
        }
    }
}