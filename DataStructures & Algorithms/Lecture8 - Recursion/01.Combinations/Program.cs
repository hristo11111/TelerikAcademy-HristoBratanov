using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Enter integer: ");
        int n = int.Parse(Console.ReadLine());
        int[] vector = new int[n];

        PrintCombinations(vector, 0);
    }

    private static void PrintCombinations(int[] vector, int currentIndex)
    {
        if (currentIndex == vector.Length)
        {
            foreach (var item in vector)
            {
                Console.Write(item + " ");
                
            }

            Console.WriteLine();
            return;
        }

        for (int i = 1; i <= vector.Length; i++)
        {
            vector[currentIndex] = i;
            PrintCombinations(vector, currentIndex + 1);
        }
    }
}
