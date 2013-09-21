using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void SumNumbers(object sender, EventArgs e)
        {
            try
            {
                decimal firstNum = decimal.Parse(this.firstNumber.Text);
                decimal secondNum = decimal.Parse(this.secondNumber.Text);
                this.result.Text = (firstNum + secondNum).ToString();
            }
            catch (Exception)
            {
                this.result.Text = "Ivalid operation";
            }
        }
    }
}