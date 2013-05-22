using System;
using System.Collections.Generic;

class ConvertAnyNumeralSystems
{
    static void Main()
    {
        string hexNumber = Console.ReadLine();
        int s = Int32.Parse(Console.ReadLine());
        int d = Int32.Parse(Console.ReadLine());
        List<char> result = ConvertDectoHex(ConvertSbaseToDec(hexNumber, s), d);
        PrintReversed(result);
    }
    static int ConvertSbaseToDec(string number, int s)
    {
        int sum = 0;
        int len = number.Length;
        for (int i = len - 1; i >= 0; i--)
        {
            switch (number[i])
            {
                case 'A': sum = sum + 10 * (int)(Math.Pow(s, len - i - 1)); break;
                case 'B': sum = sum + 11 * (int)(Math.Pow(s, len - i - 1)); break;
                case 'C': sum = sum + 12 * (int)(Math.Pow(s, len - i - 1)); break;
                case 'D': sum = sum + 13 * (int)(Math.Pow(s, len - i - 1)); break;
                case 'E': sum = sum + 14 * (int)(Math.Pow(s, len - i - 1)); break;
                case 'F': sum = sum + 15 * (int)(Math.Pow(s, len - i - 1)); break;
                default: sum = sum + (number[i] - 48) * (int)(Math.Pow(s, len - i - 1)); break;
            }
        }
        return sum;
    }

    static List<char> ConvertDectoHex(int numInt, int d)
    {
        int index = -1;
        List<char> result = new List<char>();
        while (numInt >= 1)
        {
            result.Add('0');
            int reminder = numInt % d;
            index++;
            switch (reminder)
            {
                case 10: result[index] = 'A'; break;
                case 11: result[index] = 'B'; break;
                case 12: result[index] = 'C'; break;
                case 13: result[index] = 'D'; break;
                case 14: result[index] = 'E'; break;
                case 15: result[index] = 'F'; break;
                default: result[index] = (char)(reminder + 48); break;
            }
            numInt = numInt / d;
        }
        return result;
    }

    static void PrintReversed(List<char> arr)
    {

        for (int i = arr.Count - 1; i >= 0; i--)
        {

            Console.Write((char)(arr[i]));
        }
        Console.WriteLine();
    }
}
