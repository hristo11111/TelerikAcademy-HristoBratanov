using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class ReverseWordsInSentence
{
    static void Main()
    {
        string input = @"C# is not C++, not PHP and not Delphi!";
        string patternSymbols = @"\,\s*|\!\s*|\.\s*|\?\s*|\-\s*|\:\s*|\;\s*|\s+";
        MatchCollection symbols = Regex.Matches(input, patternSymbols);
        string[] words = Regex.Split(input, patternSymbols);
        List<string> symbolsArray = new List<string>();
        foreach (Match item in symbols)
        {
            symbolsArray.Add(item.Value);
        }

        List<string> reversed = new List<string>();
        for (int i = 0; i < words.Length - 1; i++)
        {
            reversed.Add(words[words.Length - 2 - i] + symbolsArray[i]);
        }

        Console.WriteLine(String.Concat(reversed));
    }
}
