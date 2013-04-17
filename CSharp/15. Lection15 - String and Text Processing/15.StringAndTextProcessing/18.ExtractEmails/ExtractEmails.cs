using System;
using System.Text.RegularExpressions;

class ExtractEmails
{
    static void Main()
    {
        string mails = "bob@mail.bg\n\nfn12345@fmi.uni-sofia.bg\nmente@eu.int | , , ;;; gero@dir.bg";
        string pattern = @"[a-zA-Z0-9_\-\.]+@[a-zA-Z0-9_\-\.]+\.[a-zA-Z]{2,5}";
        MatchCollection res = Regex.Matches(mails, pattern);
        foreach (Match item in res)
        {
            Console.WriteLine(item.Value);
        }
    }
}
