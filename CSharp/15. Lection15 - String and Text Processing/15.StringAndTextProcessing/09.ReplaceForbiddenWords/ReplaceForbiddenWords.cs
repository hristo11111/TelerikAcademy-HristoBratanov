using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class ReplaceForbiddenWords
{
    static void Main()
    {
        List<string> forbiddenWords = new List<string>();
        string forbidden = "PHP, CLR, Microsoft";
        string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        string pattern = @"\b[A-Za-z]+\b";
        MatchCollection match = Regex.Matches(forbidden, pattern);
        foreach (Match item in match)
        {
            forbiddenWords.Add(item.Value);
        }

        foreach (string item in forbiddenWords)
        {
            Regex rep = new Regex(@"\b" + item + @"\b");
            text = rep.Replace(text, new string('*', item.Length));
        }

        Console.WriteLine(text);
    }
}
