using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.RandomNumbersWebServerControls
{
    public partial class RandomNumberWebServerCls : System.Web.UI.Page
    {
        protected void GenerateRandomNumbers(object sender, EventArgs e)
        {
            Random rand = new Random();
            int from = int.Parse(this.tbFromNumber.Text);
            int to = int.Parse(this.tbToNumber.Text);

            this.labelResult.Text = rand.Next(from, to).ToString();
        }
    }
}