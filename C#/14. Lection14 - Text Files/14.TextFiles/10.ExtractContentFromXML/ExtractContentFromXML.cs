using System;
using System.Collections.Generic;
using System.IO;

class ExtractContentFromXML
{
    static void Main()
    {
        StreamReader reader = new StreamReader("content.xml");
        List<string> linesWithTags = new List<string>();
        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                    int startTagIndex = line.IndexOf('<');    
                    int endTagIndex = line.IndexOf('>', startTagIndex + 1);
                    string initialLineValue = line;
                    while (startTagIndex != -1)
                    {
                                                                                                 
                        line = initialLineValue.Substring(startTagIndex, endTagIndex - startTagIndex+1);  
                        startTagIndex = initialLineValue.IndexOf('<', endTagIndex + 1);
                        endTagIndex = initialLineValue.IndexOf('>', startTagIndex + 1);
                        linesWithTags.Add(line);
                    }
                            
                    line = reader.ReadLine();
            }
            
        }

        //rewrite the file "content.xml" with tags only
        StreamWriter writer = new StreamWriter("content.xml"); //
        using (writer)
        {
            for (int i = 0; i < linesWithTags.Count; i++)
            {
                writer.Write(linesWithTags[i]);
            }    
        }
        
    }
}
