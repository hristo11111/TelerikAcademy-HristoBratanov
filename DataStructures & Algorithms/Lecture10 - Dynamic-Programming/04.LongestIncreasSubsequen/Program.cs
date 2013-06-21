using System;

// This is not part of the homework.

class Program
{
    static void Main()
    {
        int[] sequence = new int[] { 2, 4, 3, 5, 1, 7, 6, 9, 8 };

        int[] lengths = new int[sequence.Length];
        int[] predecessors = new int[sequence.Length];

        lengths[0] = 1;
        predecessors[0] = -1;

        int maxLength = 0;
        int bestEnd = -1;

        for (int i = 1; i < sequence.Length; i++)
        {
            lengths[i] = 1;
            predecessors[i] = -1;

            for (int j = i - 1; j >= 0; j--)
            {
                if (lengths[j] + 1 > lengths[i] &&
                    sequence[j] < sequence[i])
                {
                    lengths[i] = lengths[j] + 1;
                    predecessors[i] = j;
                }
            }

            if (lengths[i] > maxLength)
            {
                bestEnd = i;
                maxLength = lengths[i];
            }
        }
    }
}