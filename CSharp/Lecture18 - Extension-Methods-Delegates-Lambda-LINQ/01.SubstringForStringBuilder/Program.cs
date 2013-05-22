// Implement an extension method Substring(int index, int length) for the class StringBuilder that 
// returns new StringBuilder and has the same functionality as Substring in the class String.

using System;
using System.Text;

class Program
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder("abrakadabra");
        
        Console.WriteLine(sb.Substring(4));
        Console.WriteLine(sb.Substring(2,8));
    }
}
