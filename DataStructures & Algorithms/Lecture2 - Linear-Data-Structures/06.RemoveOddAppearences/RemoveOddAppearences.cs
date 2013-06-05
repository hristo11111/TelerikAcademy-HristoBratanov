using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class RemoveOddAppearences
{
    static void Main()
    {
        List<int> sequence = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
        List<int> sequenceCopy = CopyList(sequence);
        sequence.Sort();

        int sum = 1;
        int currentElement = sequence[0];
        List<int> oddAppear = new List<int>();

        for (int i = 1; i < sequence.Count; i++)
        {
            if (currentElement == sequence[i])
            {
                sum++;
            }
            else
            {
                if (sum % 2 != 0)
                {
                    oddAppear.Add(currentElement);
                }

                sum = 1;
            }
            currentElement = sequence[i];
        }

        for (int i = 0; i < oddAppear.Count; i++)
        {
            sequenceCopy.RemoveAll(element => element == oddAppear[i]);
        }

        Console.WriteLine("Sequence without odd apperences: {0}", 
            SequenceToString(sequenceCopy));
    }

    private static List<int> CopyList(List<int> sequence)
    {
        List<int> copy = new List<int>();

        foreach (var item in sequence)
        {
            copy.Add(item);
        }

        return copy;
    }

    private static string SequenceToString(List<int> sequence)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("{");

        for (int i = 0; i < sequence.Count; i++)
        {
            sb.Append(sequence[i]);
            if (i != sequence.Count - 1)
            {
                sb.Append(", ");
            }
        }

        sb.Append("}");

        return sb.ToString();
    }
}
