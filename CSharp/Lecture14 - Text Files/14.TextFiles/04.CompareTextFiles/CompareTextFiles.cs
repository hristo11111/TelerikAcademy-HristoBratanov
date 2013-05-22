using System;
using System.IO;
using System.Text;

class CompareTextFiles
{
    static void Main()
    {
        StreamReader reader1 = new StreamReader("subs.txt", Encoding.GetEncoding("windows-1251"));
        StreamReader reader2 = new StreamReader("subs2.txt", Encoding.GetEncoding("windows-1251"));
        using (reader1)
        {
            using (reader2)
            {
                int count = 1;
                string lineReader1 = reader1.ReadLine();
                string lineReader2 = reader2.ReadLine();
                while (lineReader1 != null)
                {
                    if (lineReader1.Equals(lineReader2))
                    {
                        Console.WriteLine("lines {0} in both files are equal", count);
                    }
                    count++;
                    lineReader1 = reader1.ReadLine();
                    lineReader2 = reader2.ReadLine();
                }
            }
            
        }
    }
}
