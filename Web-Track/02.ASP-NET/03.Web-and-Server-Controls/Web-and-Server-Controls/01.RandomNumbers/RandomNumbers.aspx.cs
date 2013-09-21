using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.RandomNumbers
{
    public partial class RandomNumbers : System.Web.UI.Page
    {
        protected void GenerateRandNumber(object sender, EventArgs e)
        {
            Random rand = new Random();
            int from = int.Parse(this.tbFrom.Value);
            int to = int.Parse(this.tbTo.Value);

            this.labelResult.InnerHtml = rand.Next(from, to).ToString();
        }
    }
}