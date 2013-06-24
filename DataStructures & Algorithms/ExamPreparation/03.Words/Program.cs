using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    // not completed
    static Dictionary<string, List<string>> words = new Dictionary<string, List<string>>();

    static void Main()
    {
        int textRows = int.Parse(Console.ReadLine());

        StringBuilder text = new StringBuilder();
        for (int i = 0; i < textRows; i++)
        {
            string line = Console.ReadLine();

            text.Append(line + " ");
        }

        int wordsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < wordsCount; i++)
        {
            string word = Console.ReadLine();
            words.Add(word, new List<string>());
        }
        Console.WriteLine();

    }
}
