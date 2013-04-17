using System;
using System.Collections.Generic;

class HexToDecimal
{
    static void Main()
    {
        string hexNumber = Console.ReadLine();
        ConvertHecToDec(hexNumber);
    }
    static void ConvertHecToDec(string number)
    {
        int sum = 0;
        int len = number.Length;
        for (int i = len - 1; i >= 0; i--)
        {
            switch (number[i])
            {
                case 'A': sum = sum + 10 * (int)(Math.Pow(16, len - i - 1)); break;
                case 'B': sum = sum + 11 * (int)(Math.Pow(16, len - i - 1)); break;
                case 'C': sum = sum + 12 * (int)(Math.Pow(16, len - i - 1)); break;
                case 'D': sum = sum + 13 * (int)(Math.Pow(16, len - i - 1)); break;
                case 'E': sum = sum + 14 * (int)(Math.Pow(16, len - i - 1)); break;
                case 'F': sum = sum + 15 * (int)(Math.Pow(16, len - i - 1)); break;
                default: sum = sum + (number[i] - 48) * (int)(Math.Pow(16, len - i - 1)); break;
            }
        }
        Console.WriteLine(sum);
    }
}