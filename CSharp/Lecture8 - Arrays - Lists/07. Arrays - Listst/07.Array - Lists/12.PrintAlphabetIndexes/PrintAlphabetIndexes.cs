using System;
using System.Collections.Generic;
using System.Linq;

class PrintAlphabetIndexes
{
    static void Main()
    {
        List<char> alphabet = new List<char>();
        for (int i = 65; i <= 90; i++)
        {
            alphabet.Add((char)i);
        }
        Console.Write("enter a word (A-Z): ");
        string word = Console.ReadLine();
        List<char> inputWord = new List<char>();
        inputWord = word.ToList<char>();
        for (int i = 0; i < inputWord.Count; i++)
        {
            for (int j = 0; j <= 25; j++)
            {
                if (alphabet[j] == inputWord[i])
                {
                    Console.WriteLine("index of letter {0} is = {1} ", (char)inputWord[i], j);
                }
            }
        }
    }
}
