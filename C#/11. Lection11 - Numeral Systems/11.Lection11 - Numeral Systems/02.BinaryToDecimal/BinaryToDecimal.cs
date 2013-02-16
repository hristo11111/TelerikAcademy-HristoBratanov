using System;
using System.Collections.Generic;

class BinaryToDecimal
{
    static void Main()
    {
        Console.WriteLine(ConvertBinaryToDec(Console.ReadLine())); 
    }

    static int ConvertBinaryToDec(string binary)
    {
        int sum = 0;
        int count = 0;
        for (int i = binary.Length-1; i >= 0; i--, count++)
        {
            sum = (int)(sum + (binary[i]-48)*Math.Pow(2,count));
        }
        return sum;
    }
}
