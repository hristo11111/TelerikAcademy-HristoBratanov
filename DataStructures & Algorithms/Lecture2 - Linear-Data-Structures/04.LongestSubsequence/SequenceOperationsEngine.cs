using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SequenceOperationsEngine
{
    public List<int> FindSubsequence(List<int> sequence)
    {
        int sum = 1;
        int maxSum = Int32.MinValue;
        int currentElement = sequence[0];
        Stack<int> indexes = new Stack<int>();

        for (int i = 1; i < sequence.Count; i++)
        {
            if (currentElement == sequence[i])
            {
                sum++;

                if (sum > maxSum)
                {
                    maxSum = sum;
                    indexes.Push(i);
                }
            }
            else
            {
                sum = 1;
            }
            currentElement = sequence[i];
        }

        if (maxSum == Int32.MinValue)
        {

            return new List<int>();
        }
        else
        {
            int lastSubsequenceIndex = indexes.Peek();
            int subsequenceLength = maxSum;
            List<int> subsequence = new List<int>();
            subsequence = sequence.GetRange(lastSubsequenceIndex - subsequenceLength + 1, subsequenceLength);

            return subsequence;
        }
    }

    public string SequenceToString(List<int> sequence)
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