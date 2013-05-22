using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class ReadsWordsAndSort
{
    static void Main()
    {
        string input = "ala bala nica    turska      panica"; 
        string pattern = @"\b[a-zA-Z]+\b";
        List<string> wordsArray = new List<string>();
        MatchCollection words = Regex.Matches(input, pattern);
        foreach (Match word in words)
        {
            wordsArray.Add(word.Value);
        }

        wordsArray.Sort();
        foreach (string word in wordsArray)
        {
            Console.WriteLine(word);
        }

    }

}
