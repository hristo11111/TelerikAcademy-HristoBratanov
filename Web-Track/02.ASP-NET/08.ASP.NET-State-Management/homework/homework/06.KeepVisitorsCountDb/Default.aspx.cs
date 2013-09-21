using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06.KeepVisitorsCountDb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            Application.Lock();
            if (Application["Users"] == null)
            {
                Application["Users"] = 0;
            }
            Application.UnLock();

            Application.Lock();
            Application["Users"] = (int)Application["Users"] + 1;
            Application.UnLock();

            VisitorsEntities1 context = new VisitorsEntities1();
            var visitor = context.Visitors.Where(v => v.Id == 1).FirstOrDefault();
            visitor.Count++;

            context.SaveChanges();
        }
    }
}