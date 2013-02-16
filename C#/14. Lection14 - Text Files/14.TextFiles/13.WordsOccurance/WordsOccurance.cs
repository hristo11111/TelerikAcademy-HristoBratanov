using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

class WordsOccurance
{
    static void Main()
    {
        try
        {
            StreamReader readText = new StreamReader("test.txt");
            string text;
            List<string> textWords = new List<string>();
            StreamReader readWords = new StreamReader("words.txt");
            string words;
            StreamWriter writer = new StreamWriter("result.txt");
            List<string> readWordsWords = new List<string>();
            Dictionary<string, int> wordsOccure = new Dictionary<string, int>();

            using (readText)
            {
                text = readText.ReadToEnd();
            }

            using (readWords)
            {
                words = readWords.ReadToEnd();
            }

            textWords = FindWords(text);
            readWordsWords = FindWords(words);

            foreach (string word in readWordsWords)
            {
                int sum = 0;
                foreach (string textWord in textWords)
                {

                    if (word == textWord)
                    {
                        sum++;
                    }

                }

                wordsOccure.Add(word, sum);
            }

            using (writer)
            {
                var items = from pair in wordsOccure orderby pair.Value descending select pair;
                foreach (KeyValuePair<string, int> pair in items)
                {
                    writer.WriteLine("'{0}' occured {1} times", pair.Key, pair.Value);
                }
            }
        }
        catch (FileNotFoundException exc)
        {
            Console.WriteLine(exc.Message);
        }
        catch (DirectoryNotFoundException exc)
        {
            Console.WriteLine(exc.Message);
        }
        catch (ArgumentNullException exc)
        {
            Console.WriteLine(exc.Message);
        }
        catch (ArgumentException exc)
        {
            Console.WriteLine(exc.Message);
        }
        catch (OutOfMemoryException exc)
        {
            Console.WriteLine(exc.Message);
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc.Message);
        }

    }

    static List<string> FindWords(string input)
    {
        List<string> wordsArr = new List<string>();
        string pattern = @"\b[a-zA-Z]+\b";
        MatchCollection words = Regex.Matches(input, pattern);
        foreach (Match item in words)
        {
            wordsArr.Add(item.Value);
        }

        return wordsArr;
    }

   
}
