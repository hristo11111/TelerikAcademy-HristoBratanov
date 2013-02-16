using System;
using System.Collections.Generic;
using System.Text;

class Dictionary
{
    static void Main()
    {
        List<string> words = new List<string>();
        List<string> definitions = new List<string>();
        string dictionary = ".NET – platform for applications from Microsoft\nCLR – managed execution environment for .NET\nnamespace – hierarchical organization of classes";
        Console.WriteLine(dictionary);
        int startIndex = 0;
        int indexOfNewLine = 0;
        int indexOfDefinition = 0;
        int add = 0;
        while (indexOfNewLine != dictionary.Length - 1)
        {
            int indexOfSpace = dictionary.IndexOf(" ", startIndex);
            string word = dictionary.Substring(startIndex, indexOfSpace - startIndex);
            words.Add(word);
            indexOfDefinition = indexOfSpace + 3;
            indexOfNewLine = dictionary.IndexOf('\n', startIndex);
            if (indexOfNewLine == -1)
            {
                indexOfNewLine = dictionary.Length - 1;
                add = 1;
            }
            string definition = dictionary.Substring(indexOfDefinition, indexOfNewLine - indexOfDefinition + add);
            definitions.Add(definition);
            startIndex = indexOfNewLine + 1;    
        }

        string input = Console.ReadLine();
        input = input.ToLower();
        int inputIndex = -1;
        for (int i = 0; i < words.Count; i++)
        {
            if (input == words[i].ToLower())
            {
                inputIndex = i;
                break;
            }
        }

        Console.WriteLine(definitions[inputIndex]);
        
    }
}
