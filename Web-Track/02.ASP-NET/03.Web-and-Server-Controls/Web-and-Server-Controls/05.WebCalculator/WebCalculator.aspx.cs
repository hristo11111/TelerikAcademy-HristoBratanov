using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _05.WebCalculator
{
    public partial class WebCalculator : System.Web.UI.Page
    {
        protected void AddForCalculation(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string textBoxText = Server.HtmlEncode(this.TbCalculateField.Text);

            if (textBoxText == string.Empty || textBoxText == null )
	        {
		        this.TbCalculateField.Text = btn.Text;
	        }
            else
	        {
		        this.TbCalculateField.Text += btn.Text;
	        }
        }

        protected void Button0Click(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            string textBoxText = Server.HtmlEncode(this.TbCalculateField.Text);
	        //Check the input status

            if (textBoxText.Length >= 1)
		    {
			    //Add our zero
                this.TbCalculateField.Text += btn.Text;
		    }
        }
        
        protected void CalculateSQRT(object sender, System.EventArgs e)
        {
            if (this.TbCalculateField.Text.Length != 0)
            {
                double tmpValue = System.Double.Parse(this.TbCalculateField.Text);
                tmpValue = System.Math.Sqrt(tmpValue);
                this.TbCalculateField.Text = tmpValue.ToString();
            }
        }

        protected void Clear(object sender, System.EventArgs e)
        {
            this.TbCalculateField.Text = string.Empty;
        }

        protected void CalculateTotals(object sender, System.EventArgs e)
        {
            string expression = Server.HtmlEncode(this.TbCalculateField.Text);
            int lastSignIndex = 0;

            if (expression.Contains('+'))
            {
                int lastPlusIndex = expression.LastIndexOf('+');
                if (lastPlusIndex > lastSignIndex)
                {
                    lastSignIndex = lastPlusIndex;
                }
            }
            if (expression.Contains('-'))
            {
                int lastMinusIndex = expression.LastIndexOf('-');
                if (lastMinusIndex > lastSignIndex)
                {
                    lastSignIndex = lastMinusIndex;
                }
            }
            if (expression.Contains('x'))
            {
                int lastMultiplyIndex = expression.LastIndexOf('x');
                if (lastMultiplyIndex > lastSignIndex)
                {
                    lastSignIndex = lastMultiplyIndex;
                }
            }
            if (expression.Contains('/'))
            {
                int lastDivideIndex = expression.LastIndexOf('/');
                if (lastDivideIndex > lastSignIndex)
                {
                    lastSignIndex = lastDivideIndex;
                }
            }
            else if(lastSignIndex == 0)
            {
                this.TbCalculateField.Text = "No operation assigned!";
            }

            this.TbCalculateField.Text = lastSignIndex.ToString();

            string sign = expression.Substring(lastSignIndex, 1);
            double firstOperand = double.Parse(expression.Substring(0, lastSignIndex));
            double secondOperand = double.Parse(expression.Substring(
                lastSignIndex+1, expression.Length - lastSignIndex - 1));

            double result = 0;
            switch (sign)
            {
                case "+": result = firstOperand + secondOperand; break;
                case "-": result = firstOperand - secondOperand; break;
                case "x": result = firstOperand * secondOperand; break;
                case "/": result = firstOperand / secondOperand; break;
                default:
                    break;
            }

            this.TbCalculateField.Text = result.ToString();
        }
    }
}