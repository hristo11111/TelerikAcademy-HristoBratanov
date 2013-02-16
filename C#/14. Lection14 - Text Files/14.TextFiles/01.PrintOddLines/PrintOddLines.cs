using System;
using System.IO;
using System.Text;

class PrintOddLines
{
    static void Main()
    {
        StreamReader reader = new StreamReader("subs.txt", Encoding.GetEncoding("windows-1251"));
        int count = 0;
        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                count++;
                if (count % 2 != 0)
                {
                    Console.WriteLine("line {0}: {1}", count, line);    
                }
                line = reader.ReadLine();
            }
            
        }
    }
}
