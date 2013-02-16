using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class WordsAppearance
{
    static void Main()
    {
        List<string> wordsArray = new List<string>();
        string text = "ala bala portukala, kyde li e portukala ala bala, ala bala?";
        string pattern = @"\b[a-zA-Z]+\b";
        MatchCollection words = Regex.Matches(text, pattern);
        foreach (Match item in words)
        {
            wordsArray.Add(item.Value);
        }

        PrintWordsPlusInfo(wordsArray);
    }

    static void PrintWordsPlusInfo(List<string> arr)
    {
        arr.Sort();
        string word = arr[0];
        int sum = 1;
        for (int i = 1; i < arr.Count; i++)
        {
            if (word == arr[i])
            {
                sum++;
            }

            else
            {
                Console.WriteLine("word {0} occured {1} times", word, sum);
                word = arr[i];
                sum = 1;
            }

        }

        Console.WriteLine("word {0} occured {1} times", word, sum);
    }

}
