using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class AlphabetArray
{
    static void Main()
    {
        char[] alphabet = new char[26];
        for (int i = 0; i < 26; i++)
        {
            alphabet[i] = (char)(i + 65);
        }
        Console.Write("word (Letters upper case A-Z): ");
        string input = Console.ReadLine();
        char[] inputArray = input.ToCharArray();
        for (int i = 0; i < inputArray.Length; i++)
        {
            for (int j = 0; j < alphabet.Length; j++)
            {
                if (inputArray[i] == alphabet[j])
                {
                    Console.WriteLine(j);
                }
            }
        }
    }
}
