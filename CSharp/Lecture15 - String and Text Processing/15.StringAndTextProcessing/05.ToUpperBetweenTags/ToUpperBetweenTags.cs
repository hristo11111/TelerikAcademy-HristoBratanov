using System;
using System.Text.RegularExpressions;

class ToUpperBetweenTags
{
    static void Main()
    {
        string input = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        int startIndex = 0;
        while (startIndex > -1)
        {
            int indexOpenTag = input.IndexOf("<upcase>", startIndex);
            if (indexOpenTag == -1)
            {
                break;
            }

            int indexCloseTag = input.IndexOf("</upcase>", indexOpenTag + 8);
            if (indexCloseTag == -1)
            {
                break;
            }

            string betweenTags = input.Substring(indexOpenTag + 8, indexCloseTag - indexOpenTag - 8);
            input = input.Replace(betweenTags, betweenTags.ToUpper());
            startIndex = indexCloseTag + 9;
        }

        input = input.Replace("<upcase>", "");
        input = input.Replace("</upcase>", "");

        Console.WriteLine(input);
    }
}
