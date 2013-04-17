using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;

class ExtractContentBetweenTags
{
    static void Main()
    {
        string html = @"<html><head><title>News</title></head><body><p><a href=""http://academy.telerik.com"">TelerikAcademy</a>aims to provide free real-world practical training for young people who want to turn into skillful .NET software engineers.</p></body></html>";
        StringBuilder result = new StringBuilder();
        int indexOfTitle = html.IndexOf("<title>");
        int indexOfEndOfTitle = indexOfTitle + 6;
        for (int i = indexOfEndOfTitle + 1; i < html.Length; i++)
		{
		    if (html[i] != '<')
            {
                result.Append(html[i]);
            }

            else
            {
                break;
            }

		}
        result.AppendLine();

        int indexOfBody = html.IndexOf("<body>");

        bool afterTag = false;

        for (int i = indexOfBody + 6; i < html.Length; i++)
        {
            if (afterTag)
            {
                if (html[i] == '<')
                {
                    afterTag = false;
                }

                else
                {
                    result.Append(html[i]);
                    if (html[i+1] == '<')
                    {
                        result.AppendLine();
                    }

                }

            }
            if (html[i] == '>' && i+1 < html.Length)
            {
                afterTag = true;
                continue;
            }

        }

        Console.WriteLine(result.ToString());
        
    }
}