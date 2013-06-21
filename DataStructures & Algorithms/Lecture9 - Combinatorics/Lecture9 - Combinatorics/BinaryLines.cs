using System;
using System.Linq;
using System.Numerics;

class BinaryLines
{
    // 100/100 in bgcoder
    // http://bgcoder.com/Contest/Practice/59

    static void Main()
    {
        string input = Console.ReadLine();
        int starCount = 0;

        foreach (char symbol in input)
        {
            if (symbol == '*')
            {
                starCount++;
            }
        }

        
        BigInteger[] results = new BigInteger[10000];
        results[0] = 1;

        BigInteger result = 0;

        for (int i = 1; i <= starCount; i++)
        {
            results[i] = results[i - 1] * 2;
        }

        Console.WriteLine(results[starCount]);
    }
}
