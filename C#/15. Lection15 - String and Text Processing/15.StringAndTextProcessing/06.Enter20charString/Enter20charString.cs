using System;
using System.Collections.Generic;

class Enter20charString
{
    static void Main()
    {
        string input = Console.ReadLine();
        if (input.Length < 20)
        {
            input = input.PadRight(20, '*');
        }

        Console.WriteLine(input);
    }

}
