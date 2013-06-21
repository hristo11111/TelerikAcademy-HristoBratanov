using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // works with other values of "n" and "k" too
        int n=3;
        int k=2;
        string[] inputSet = new string[] { "hi", "a", "b"};

        string[] variation = new string[k];
        

        PrintVariations(variation, inputSet, 0);
    }

    private static void PrintVariations(string[] variation, string[] inputSet, int count)
    {
        if (count == variation.Length)
        {
            foreach (string item in variation)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            return;
        }

        for (int i = 0; i < inputSet.Length; i++)
        {
            variation[count] = inputSet[i];
            PrintVariations(variation, inputSet, count + 1);
        }
    }
}
