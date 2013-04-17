using System;
using System.Collections.Generic;

class ReverseString
{
    static void Main()
    {
        Console.Write("string = ");
        string input = Console.ReadLine();
        List<char> inputToList = new List<char>();
        for (int i = 0; i < input.Length; i++)
        {
            inputToList.Add(input[i]);
        }
        inputToList.Reverse();
        Console.WriteLine(String.Concat(inputToList));
    }

}
