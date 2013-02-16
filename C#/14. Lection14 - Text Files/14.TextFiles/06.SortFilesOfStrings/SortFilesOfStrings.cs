using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class SortFilesOfStrings
{
    static void Main()
    {
        StreamReader reader = new StreamReader("list.txt");
        List<string> allLines = new List<string>();
        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                allLines.Add(line);
                line = reader.ReadLine();
            }

        }

        allLines.Sort();
        StreamWriter writer = new StreamWriter("result.txt");
        using (writer)
        {
            for (int i = 0; i < allLines.Count; i++)
            {
                writer.WriteLine(allLines[i]);
            }
        }
    }
}
