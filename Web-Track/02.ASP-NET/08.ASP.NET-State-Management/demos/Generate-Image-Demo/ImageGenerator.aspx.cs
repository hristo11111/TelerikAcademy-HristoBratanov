﻿using System;
using System.Drawing;
using System.Drawing.Imaging;

public partial class ImageGenerator : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        int num = 4;

        Bitmap generatedImage = new Bitmap(200, 200);
		using (generatedImage)
		{
			Graphics gr = Graphics.FromImage(generatedImage);
			using (gr)
			{
                var fonttt = new Font("Arial", 14, FontStyle.Bold);
				gr.FillRectangle(Brushes.MediumSeaGreen, 0, 0, 200, 200);
				gr.FillPie(Brushes.Yellow, 25, 25, 150, 150, 0, 45);
				gr.FillPie(Brushes.Green, 25, 25, 150, 150, 45, 315);
                gr.DrawString(num.ToString(), fonttt, SystemBrushes.WindowText, new PointF(10, 40));

				// Set response header and write the image into response stream
				Response.ContentType = "image/gif";

				//Response.AppendHeader("Content-Disposition",
				//    "attachment; filename=\"Financial-Report-April-2013.gif\"");

				generatedImage.Save(Response.OutputStream, ImageFormat.Gif);
			}
		}
    }
}
