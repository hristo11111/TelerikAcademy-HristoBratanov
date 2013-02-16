using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class ExtractSentences
{
    static void Main(string[] args)
    {
        Console.Write("search in: ");
        string input = Console.ReadLine();
        Console.Write("search for: ");
        string searchFor = Console.ReadLine();
        string searchForCopy = searchFor;
        searchFor = searchFor.ToLower();
        int startIndex = 0;
        StringBuilder sb = new StringBuilder();

        while (startIndex != -1)
	    {
            int indexOfPoint = input.IndexOf('.', startIndex);
            if (indexOfPoint == -1)
            {
                break;
            }
            
            string substring = input.Substring(startIndex, indexOfPoint - startIndex + 1);
            string copyOfSubstring = substring;
            substring = substring.ToLower();
            if (Regex.IsMatch(substring, @"\b" + searchFor + @"\b"))
            {
                sb.Append(copyOfSubstring);
            }

            startIndex = indexOfPoint + 1;
	    }

        Console.WriteLine("sentences with {0} in them are: {1}", searchForCopy, sb.ToString());
        
    }

}
