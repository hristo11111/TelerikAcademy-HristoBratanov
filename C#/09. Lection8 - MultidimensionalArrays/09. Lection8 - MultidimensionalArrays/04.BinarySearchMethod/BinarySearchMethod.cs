using System;
using System.Collections.Generic;
using System.Linq;

class BinarySearchMethod
{
    static void Main()
    {
        Console.Write("N = ");
        int N = Int32.Parse(Console.ReadLine());
        int[] array = new int[N];
        for (int i = 0; i < N; i++)
        {
            Console.Write("array[{0}] = ", i);
            array[i] = Int32.Parse(Console.ReadLine());
        }
        Console.Write("K = ");
        int K = Int32.Parse(Console.ReadLine());
        Array.Sort(array);
        int index = Array.BinarySearch(array, K);
        if (index >= 0)
        {
            Console.WriteLine(array[index]);
        }
        else if (index == -1)
        {
            Console.WriteLine("no such number in the array");
        }
        else
        {
            Console.WriteLine(array[~index - 1]);
        }
    }
}
