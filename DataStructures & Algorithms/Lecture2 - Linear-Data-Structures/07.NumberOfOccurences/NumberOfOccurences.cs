﻿using System;
using System.Collections.Generic;
using System.Linq;

class NumberOfOccurences
{
    static void Main(string[] args)
    {
        List<int> sequence = new List<int>() { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
        int[] occurances = new int[1001];

        for (int i = 0; i < sequence.Count; i++)
        {
            int number = sequence[i];
            occurances[number]++;
        }

        for (int i = 0; i < occurances.Length; i++)
        {
            int count = occurances[i];
            if (occurances[i] > 0)
            {
                Console.WriteLine("{0} -> {1} times", i, count);
            }
        }
    }
}