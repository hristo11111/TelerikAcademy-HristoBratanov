using System;
using System.Collections.Generic;
using System.Linq;

class SortStringArrByLength
{
    static void Main()
    {
        Console.Write("number of strings in array = ");
        int N = Int32.Parse(Console.ReadLine());
        string[] array = new string[N];
        for (int i = 0; i < N; i++)
        {
            Console.Write("string {0} = ", i);
            array[i] = Console.ReadLine();
        }
        Array.Sort(array,(x,y) => x.Length.CompareTo(y.Length));
        Console.WriteLine();
        Console.WriteLine("the sorted string array:");
        Console.WriteLine();
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array[i].Length; j++)
            {
                Console.Write(array[i][j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
