using System;
using System.Text.RegularExpressions;
using System.Text;

class ReplaceTags
{
    static void Main()
    {
        string html = @"<p>Please visit <a href=""http://academy.telerik. com"">our site</a> to choose a training course. Also visit <a href=""www.devbg.org"">our forum</a> to discuss the courses.</p>";
        string openTag = @".\ba\s+\bhref=""";
        string openTagEnd = @"\b("">)";
        string closeTag = @"\b(</a>)";
        html = Regex.Replace(html, openTag, "[URL=");
        html = Regex.Replace(html, openTagEnd, "]");
        html = Regex.Replace(html, closeTag,"[/URL]");
        Console.WriteLine(html);
    }
}
