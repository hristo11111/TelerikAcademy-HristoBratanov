using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] set = new string[] { "test", "rock", "fun" };

        int k = 2;

        string[] subsets = new string[k];

        PrintSubsets(set, subsets, 0, 0);

    }

    private static void PrintSubsets(string[] set, string[] subsets, int nextIndex, int startIndex)
    {
        if (nextIndex == subsets.Length)
        {
            foreach (string item in subsets)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            return;
        }

        for (int i = startIndex; i < set.Length; i++)
        {
            subsets[nextIndex] = set[i];
            PrintSubsets(set, subsets, nextIndex + 1, startIndex + 1);
            startIndex++;
        }
    }
}
