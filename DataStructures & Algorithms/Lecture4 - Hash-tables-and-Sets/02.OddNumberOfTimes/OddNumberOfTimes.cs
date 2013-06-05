using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class OddNumberOfTimes
{
    static void Main()
    {
        string[] array = { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
        Dictionary<string, int> occurances = new Dictionary<string, int>();

        foreach (string word in array)
        {
            int count = 1;
            if (occurances.ContainsKey(word))
            {
                occurances[word]++;
            }
            else
            {
                occurances[word] = count;
            }
        }

        StringBuilder output = new StringBuilder();
        output.Append("{");
        foreach (var pair in occurances)
        {
            if (occurances[pair.Key] % 2 != 0)
            {
                output.Append(pair.Key);
                output.Append(",");
            }
        }

        if (output.Length > 1) 
        {
            output.Remove(output.Length - 1, 1);
        }

        output.Append("}");

        Console.WriteLine(output.ToString());
    }
}
