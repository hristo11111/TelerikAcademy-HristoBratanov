using System;
using System.Text;

class ReplaceSameLettersWithOne
{
    static void Main()
    {
        string line = "aaaaabbbbbcdddeeeedssaa";
        StringBuilder sb = new StringBuilder();
        sb.Append(line);
        char compare = sb[0];
        int startIndex = 0;
        int sum = 1;
        int count = 0;
        for (int i = 1; i < sb.Length; i++)
        {
            if (compare == sb[i])
            {
                sum++;
            }

            else
            {
                sb.Remove(startIndex + 1, sum - 1);
                sum = 1;
                count++;
                startIndex = count;
                compare = sb[startIndex];
                i = count;
            }

        }

        sb.Remove(startIndex + 1, sum - 1);
        Console.WriteLine(sb.ToString());
    }

}
