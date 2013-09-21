using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _05.GraphWebCounter
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

            string count = Application["Users"].ToString();

            Bitmap generatedImage = new Bitmap(200, 200);
            using (generatedImage)
            {
                Graphics gr = Graphics.FromImage(generatedImage);
                using (gr)
                {
                    var font = new Font("Arial", 14, FontStyle.Bold);
                    gr.FillRectangle(Brushes.MediumSeaGreen, 0, 0, 200, 200);
                    gr.DrawString(count, font, SystemBrushes.WindowText, new PointF(80, 80));

                    // Set response header and write the image into response stream
                    Response.ContentType = "image/jpeg";

                    //Response.AppendHeader("Content-Disposition",
                    //    "attachment; filename=\"Financial-Report-April-2013.gif\"");

                    generatedImage.Save(Response.OutputStream, ImageFormat.Jpeg);
                }
            }
        }
    }
}