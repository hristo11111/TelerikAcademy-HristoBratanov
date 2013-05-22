using System;
using System.IO;
using System.Text;

class InsertLineNumbers
{
    static void Main()
    {
        StreamReader reader = new StreamReader("subs.txt", Encoding.GetEncoding("windows-1251"));
        using (reader)
        {
            int count = 1;
            string line;
            StreamWriter writer = new StreamWriter("subsIndexed.txt", false, Encoding.GetEncoding("windows-1251"));
            using (writer)
            {
                while ((line = reader.ReadLine()) != null)
                {
                    writer.Write("line {0}: ", count);
                    writer.WriteLine(line);
                    count++;
                }
 
            }
            
        }
    }
}
