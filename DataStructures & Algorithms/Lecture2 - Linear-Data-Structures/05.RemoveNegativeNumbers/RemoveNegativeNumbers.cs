using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class RemoveNegativeNumbers
{
    static void Main()
    {
        List<int> sequence = new List<int>() { -4, 5, -11, 2, 1, 3, -5, 1, -5 };
        List<int> positiveSequence = new List<int>();

        for (int i = 0; i < sequence.Count; i++)
        {
            int number = sequence[i];
            if (number >= 0)
            {
                positiveSequence.Add(number);
            }
        }

        Console.WriteLine("New sequence: {0}", SequenceToString(positiveSequence));
    }

    private static string SequenceToString(List<int> sequence)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < sequence.Count; i++)
        {
            sb.Append(sequence[i]);
            if (i != sequence.Count - 1)
            {
                sb.Append(", ");
            }
        }

        return sb.ToString();
    }
}
