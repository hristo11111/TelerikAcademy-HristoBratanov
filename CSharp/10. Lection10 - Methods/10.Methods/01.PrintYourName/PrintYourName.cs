using System;
using System.Collections.Generic;

class PrintYourName
{
    static void Main()
    {
        Console.Write("What is your name?");
        PrintName(Console.ReadLine());    
    }
    static void PrintName(string name)
    {
        Console.WriteLine("Hello, {0}", name);
    }

}
