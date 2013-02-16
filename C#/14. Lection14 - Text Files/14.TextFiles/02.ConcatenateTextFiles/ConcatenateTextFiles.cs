using System;
using System.IO;
using System.Text;

class ConcatenateTextFiles
{
    static void Main()
    {
        StreamReader readerFirstFile = new StreamReader("subs.txt", Encoding.GetEncoding("windows-1251"));
        StreamReader readerSecondFile = new StreamReader("subs(2).txt", Encoding.GetEncoding("windows-1251"));
        using (readerFirstFile)
        {
            StreamWriter writer = new StreamWriter("conc.txt", false, Encoding.GetEncoding("windows-1251"));
            using (writer)
            {
                string s;
                while ((s = readerFirstFile.ReadLine()) != null)
                {
                    writer.WriteLine(s);
                }
            }
            
        }
        using (readerSecondFile)
        {
            StreamWriter writer = new StreamWriter("conc.txt", true, Encoding.GetEncoding("windows-1251"));
            using (writer)
            {
                string s;
                while ((s = readerSecondFile.ReadLine()) != null)
                {
                    writer.WriteLine(s);
                }

            }
            
        }

    }
}
