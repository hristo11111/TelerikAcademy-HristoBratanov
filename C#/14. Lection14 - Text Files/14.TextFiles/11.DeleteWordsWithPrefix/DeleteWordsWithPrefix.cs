using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class DeleteWordsWithPrefix
{
    static void Main()
    {
        StreamReader reader = new StreamReader("test.txt");
        StreamWriter writer = new StreamWriter("testOut.txt");
        string line = reader.ReadLine();
        using (writer)
        {
            using (reader)
            {
                while (line != null)
                {
                    string replaced = Regex.Replace(line, @"\btest([0-9a-zA-Z_])*\b", String.Empty);
                    writer.WriteLine(replaced);
                    line = reader.ReadLine();
                }   
 
            }

        }

    }

}
