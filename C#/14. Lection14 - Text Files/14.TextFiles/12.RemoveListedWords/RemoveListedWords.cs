using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class RemoveListedWords
{
    static void Main(string[] args)
    {
        try
        {
            StreamReader readInput = new StreamReader("input.txt");
            StreamReader readWords = new StreamReader("listedWords.txt");
            StreamWriter writer = new StreamWriter("output.txt");
            List<string> words = new List<string>();

            using (readWords)
            {
                string lineReaderWords = readWords.ReadLine();
                while (lineReaderWords != null)
                {
                    words.Add(lineReaderWords);
                    lineReaderWords = readWords.ReadLine();
                }

            }

            using (writer)
            {
                string result = "";
                using (readInput)
                {
                    string readAll = readInput.ReadToEnd();
                    foreach (var word in words)
                    {
                        readAll = readAll.Replace(word, "");
                    }
                    result = readAll;
                }

                writer.WriteLine(result);
            }
        }
        catch (FileNotFoundException exc)
        {
            Console.WriteLine(exc.Message);
        }
        catch (DirectoryNotFoundException exc)
        {
            Console.WriteLine(exc.Message);
        }
        catch (ArgumentNullException exc)
        {
            Console.WriteLine(exc.Message);
        }
        catch (ArgumentException exc)
        {
            Console.WriteLine(exc.Message);
        }
        catch (OutOfMemoryException exc)
        {
            Console.WriteLine(exc.Message);
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc.Message);
        }
        
        

        
	   
    }
}
