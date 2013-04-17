using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

class ReplaceWordsInTextFile
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
                    string replacedSubstring = Regex.Replace(line, "\\bstart\\b", "finish");
                    writer.WriteLine(replacedSubstring);
                    line = reader.ReadLine();

                }

            }

        }
    }
}
