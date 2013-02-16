using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

class ReadPrintWordItsLetters
{
    static void Main()
    {
        string word = "alabala123nicabira, rrggttt!";
        string pattern = @"[a-zA-Z]*";
        StringBuilder sb = new StringBuilder();
        List<char> letters = new List<char>();
        MatchCollection wordsOnly = Regex.Matches(word, pattern);
        for (int i = 0; i < wordsOnly.Count -1; i++)
        {
            sb.Append(wordsOnly[i]);
        }

        for (int i = 0; i < sb.Length; i++)
        {
            letters.Add(sb[i]);
        }

        letters.Sort();
        char letter = letters[0];
        int sum = 1;
        for (int i = 1; i < letters.Count; i++)
        {
            if (letter == letters[i])
            {
                sum++;    
            }

            else
            {
                Console.WriteLine("letter {0} occured {1} times", letter, sum);
                letter = letters[i];
                sum = 1;
            }

        }

        Console.WriteLine("letter {0} occured {1} times", letter, sum);
    }

}