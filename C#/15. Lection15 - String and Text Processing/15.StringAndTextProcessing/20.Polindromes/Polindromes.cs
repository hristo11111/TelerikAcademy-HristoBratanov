using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Polindromes
{
    static void Main()
    {
        List<string> poliString = new List<string>();
        string text = "edna duma e ABBA, druga e lamal, treta e exe";
        string pattern = @"\w+";
        MatchCollection polindromes = Regex.Matches(text, pattern);
        foreach (Match item in polindromes)
        {
            poliString.Add(item.Value);
        }

        for (int i = 0; i < poliString.Count; i++)
        {
            if (poliString[i].Length == 1)
            {
                poliString.Remove(poliString[i]);
                i--;
            }

        }

        for (int i = 0; i < poliString.Count; i++)
        {
            if (CheckIfPolindromes(poliString[i]) == true)
            {
                Console.WriteLine(poliString[i]);
            }

        }

    }

    static bool CheckIfPolindromes(string word)
    {
        bool isPolindrome = true;
        for (int i = 0; i < word.Length/2; i++)
        {
            if (word[i] != word[word.Length - i - 1])
            {
                isPolindrome = false;
            }

        }

        return isPolindrome;
    }
}
