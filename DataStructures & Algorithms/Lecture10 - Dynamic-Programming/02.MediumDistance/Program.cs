using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.Write("First word: ");
        string firstWord = Console.ReadLine();
        Console.Write("Second word: ");
        string secondWord = Console.ReadLine();
        Console.WriteLine(MED(firstWord, secondWord));
    }


    public static double MED(string firstWord, string secondWord)
    {
        double result = 0;

        string LCS = LongestCommonSubstring(firstWord, secondWord);
        if (LCS == String.Empty || LCS.Length == 0)
        {
            if (firstWord.Length == secondWord.Length)
            {
                result = firstWord.Length;
            }
            else if (firstWord.Length > secondWord.Length)
            {
                result = (firstWord.Length - secondWord.Length) * 0.9 + secondWord.Length;
            }
            else
            {
                result = (secondWord.Length - firstWord.Length) * 0.8 + firstWord.Length;
            }
        }

        else
        {

            int indexOfLcsInFirstWord = firstWord.IndexOf(LCS);
            int indexOfLcsInSecondWord = secondWord.IndexOf(LCS);

            string firstWordPrefix = firstWord.Substring(0, indexOfLcsInFirstWord);
            string secondWordPrefix = secondWord.Substring(0, indexOfLcsInSecondWord);

            string firstWordSufix = firstWord.Substring(indexOfLcsInFirstWord + LCS.Length);
            string secondWordSufix = secondWord.Substring(indexOfLcsInSecondWord + LCS.Length);

            result = MED(firstWordPrefix, secondWordPrefix) + MED(firstWordSufix, secondWordSufix);
        }

        return result;
    }

    public static string LongestCommonSubstring(string firstWord, string secondWord)
    {
        if (String.IsNullOrEmpty(firstWord) || String.IsNullOrEmpty(secondWord))
            return string.Empty;

        int[,] num = new int[firstWord.Length, secondWord.Length];
        int maxlen = 0;
        int lastSubsBegin = 0;
        StringBuilder sequenceBuilder = new StringBuilder();

        for (int i = 0; i < firstWord.Length; i++)
        {
            for (int j = 0; j < secondWord.Length; j++)
            {
                if (firstWord[i] != secondWord[j])
                    num[i, j] = 0;
                else
                {
                    if ((i == 0) || (j == 0))
                        num[i, j] = 1;
                    else
                        num[i, j] = 1 + num[i - 1, j - 1];

                    if (num[i, j] > maxlen)
                    {
                        maxlen = num[i, j];
                        int thisSubsBegin = i - num[i, j] + 1;
                        if (lastSubsBegin == thisSubsBegin)
                        {
                            sequenceBuilder.Append(firstWord[i]);
                        }
                        else
                        {
                            lastSubsBegin = thisSubsBegin;
                            sequenceBuilder.Length = 0;
                            sequenceBuilder.Append(firstWord.Substring(lastSubsBegin, (i + 1) - lastSubsBegin));
                        }
                    }
                }
            }
        }
        return sequenceBuilder.ToString();
    }
}
