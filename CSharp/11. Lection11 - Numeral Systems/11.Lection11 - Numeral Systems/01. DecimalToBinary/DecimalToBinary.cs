using System;
using System.Collections.Generic;

class DecimalToBinary
{
    static void Main()
    {
        string number = Console.ReadLine();
        PrintArray(DecToBinary(number));
    }

    static List<byte> DecToBinary(string num)
    {
        List<byte> arr = new List<byte>();
        int dec = Int32.Parse(num);
        while (dec >= 1)
        {
            arr.Add((byte)(dec % 2));
            dec = (short)(dec / 2);
        }

        return arr;
    }

    static void PrintArray(List<byte> arr)
    {
        for (int i = arr.Count - 1; i >= 0; i--)
        {
            Console.Write(arr[i]);
        }

        Console.WriteLine();
    }

}
