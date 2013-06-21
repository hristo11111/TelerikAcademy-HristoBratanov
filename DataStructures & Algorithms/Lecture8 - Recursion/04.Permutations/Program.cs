using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());

        int[] permutation = new int[n];
        for (int i = 1; i <= n; i++)
        {
            permutation[i - 1] = i;
        }

        int start = 0;
        int end = permutation.Length - 1;

        Permute(permutation, start, end);
    }

    static void Permute(int[] permutation, int startIndex, int endIndex)
    {
        int currentIndex;
        if (startIndex == endIndex)
        {
            foreach (int item in permutation)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            return;
        }

        for (currentIndex = startIndex; currentIndex <= endIndex; currentIndex++)
        {
            Swap(ref permutation[currentIndex], ref permutation[startIndex]);
            Permute(permutation, startIndex + 1, endIndex);
            Swap(ref permutation[currentIndex], ref permutation[startIndex]);
        }
    }

    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}