using System;

class CharsToUnicode
{
    static void Main()
    {
        string input = "Hi!";
        foreach (var item in input)
        {
            Console.Write("\\u{0:x4}", (int)item);    
        }

        Console.WriteLine();
    }

}
