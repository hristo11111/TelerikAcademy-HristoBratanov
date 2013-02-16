using System;
using System.Collections.Generic;
using System.Linq;

class CombinationsOfEliments
{
    static void Main()
    {
        Console.Write("size of the subset: ");
        int variationsSizeK = int.Parse(Console.ReadLine());
        Console.Write("array length: ");
        int arrayLengthN = int.Parse(Console.ReadLine());
        int[] array = new int[arrayLengthN];

        for (int i = 0; i < arrayLengthN; i++)
        {
            array[i] = i + 1;
        }

        List<string> subsets = new List<string>();
        int maxSubset = (int)Math.Pow(2, arrayLengthN) - 1;
        for (int i = 1; i <= maxSubset; i++)
        {
            string iToBin = Convert.ToString(i, 2);
            int counter = 0;
            for (int index = 0; index < iToBin.Length; index++)
            {
                if (iToBin[index] == '1')
                {
                    counter++;
                }

            }

            if (counter == variationsSizeK)
            {
                string currentSubset = "";

                for (int j = 0; j <= arrayLengthN; j++)
                {
                    int mask = 1 << j;
                    int nAndMask = mask & i;
                    if (nAndMask > 0)
                    {
                        currentSubset += array[j] + " ";
                    }

                }

                subsets.Add(currentSubset);
            }

        }

        subsets.Sort();
        Console.WriteLine(String.Join("\n", subsets));
    }
}
