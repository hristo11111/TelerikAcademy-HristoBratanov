using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class CountWordsInFile
{
    static void Main()
    {
        StreamReader sr = new StreamReader("../../textFiles/words.txt");
        Dictionary<string, int> occurances = new Dictionary<string, int>();

        using (sr)
        {
            string line;
            char[] separators = { ' ', ',', '.', '!', '?', '–' };

            while ((line = sr.ReadLine()) != null)
            {
                string[] words = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in words)
                {
                    string wordToLower = word.ToLower();
                    int count = 1;
                    if (occurances.ContainsKey(wordToLower))
                    {
                        occurances[wordToLower]++;
                    }
                    else
                    {
                        occurances[wordToLower] = count;
                    }
                }
            }
        }

        var sortedByValue =
            from pair in occurances
            orderby pair.Value
            select pair;
        
        List<KeyValuePair<string, int>> sorted = sortedByValue.ToList();

        foreach (var pair in sorted)
        {
            Console.WriteLine(pair.Key + " -> " + pair.Value);
        }
    }
}
