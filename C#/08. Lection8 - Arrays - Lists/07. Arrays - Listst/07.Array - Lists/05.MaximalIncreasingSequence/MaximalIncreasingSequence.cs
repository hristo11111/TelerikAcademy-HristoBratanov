using System;
using System.Collections.Generic;
using System.Linq;

class MaximalIncreasingSequence
{
    static void Main()
    {
        List<int> numbers = new List<int>() { 3, 2, 3, 4, 2, 2, 4 };
        int len = 1;
        int maxLen = 0;
        int lastMemberIndex = 0;
        List<int> result = new List<int>();
        for (int i = 0; i < numbers.Count - 1; i++)
        {
            if (numbers[i+1] > numbers[i])
            {
                len++;
                if (len > maxLen)
                {
                    maxLen = len;
                    lastMemberIndex = i + 1;
                }
            }
            else
            {
                len = 1;
            }
        }
        Console.Write("{ ");
        for (int j = lastMemberIndex - maxLen + 1; j <= lastMemberIndex; j++)
        {
            Console.Write(numbers[j]);
            if (j != lastMemberIndex )
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine(" }");
    }
}
