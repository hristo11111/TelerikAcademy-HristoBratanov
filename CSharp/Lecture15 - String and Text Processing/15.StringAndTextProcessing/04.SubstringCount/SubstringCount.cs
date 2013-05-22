using System;
using System.Collections.Generic;

class SubstringCount
{
    static void Main()
    {
        Console.Write("search in: ");
        string input = Console.ReadLine();
        string inputCopy = input;

        Console.Write("search for: ");
        string searchFor = Console.ReadLine();
        string searchForCopy = searchFor;

        int startIndex = 0;
        int count = 0;

        input = input.ToLower();
        searchFor = searchFor.ToLower();
        while (true)
        {
            int occur = input.IndexOf(searchFor, startIndex);
            if (occur == -1)
            {
                break;
            }

            else
            {
                count++;
            }

            startIndex = occur + searchFor.Length;
        }

        Console.WriteLine("\"{0}\" occures {1} times in \"{2}\"", searchForCopy, count, inputCopy);
        Console.WriteLine(count);
    }
    
}
