using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class RemoveOddLines
{
    static void Main()
    {
        StreamReader reader = new StreamReader("subsIndexed.txt", Encoding.GetEncoding("windows-1251"));
        List<string> oddLines = new List<string>();
        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                oddLines.Add(line);
                line = reader.ReadLine();
                line = reader.ReadLine();
            }
                
        }
        StreamWriter writer = new StreamWriter("subsIndexed.txt", false, Encoding.GetEncoding("windows-1251"));
        using(writer)
	    {
		    for (int i = 0; i < oddLines.Count; i++)
            {
                writer.WriteLine(oddLines[i]);
            }
 
	    }    

    }
}
