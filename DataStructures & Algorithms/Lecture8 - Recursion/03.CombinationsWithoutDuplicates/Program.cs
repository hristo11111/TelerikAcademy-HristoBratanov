using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("k = ");
        int k = int.Parse(Console.ReadLine());

        int[] combination = new int[k];
        int currentIndex = 0;
        int start = 1;
        int end = n;

        PrintCombinations(combination, currentIndex, start, end);
    }

    private static void PrintCombinations(int[] combination, int currentIndex, int start, int end)
    {
        if (start > end + 1)
        {
            return;
        }

        if (currentIndex == combination.Length)
        {
            foreach (int num in combination)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine();
            return;
        }

        for (int i = start; i <= end; i++)
        {
            combination[currentIndex] = i;
            PrintCombinations(combination, currentIndex + 1, start + 1, end);
            start++;
        }
    }
}