using System;
using System.Collections.Generic;
using System.IO;

class ReplaceOccurrences
{
    static void Main()
    {
        StreamReader reader = new StreamReader("large.txt");
        StreamWriter writer = new StreamWriter("changed.txt");
        using (writer)
        {
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string replacedSubstring = line.Replace("start", "finish");
                    writer.WriteLine(replacedSubstring);
                    line = reader.ReadLine();

                } 
   
            }
            
        }

    }
}
