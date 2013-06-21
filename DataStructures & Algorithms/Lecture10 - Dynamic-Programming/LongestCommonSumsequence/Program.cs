using System;

// This is not part of the homework.

class Program
{
    const int ARRSIZE = 100;
    static string[,] sequence = new string[ARRSIZE, ARRSIZE];

    static void Main()
    {
        string S1 = "GCCCTAGCG";
        string S2 = "GCGCAATG";

        int[,] matrix = new int[S2.Length + 1, S1.Length + 1];

        Console.Write("Length of LCS is: ");
        Console.WriteLine(GetLCSInternal(S2, S1, ref matrix));
        Console.WriteLine();

        Console.WriteLine("The matrix:");
        Print(matrix);
        Console.WriteLine();

        Console.Write("LCS is: ");
        PrintDiff(matrix, S1.Length, S2.Length, S1, S2);
        Console.WriteLine();
    }

    private static void Print(int[,] matrix)
    {
        string S1 = "GCCCTAGCG";
        string S2 = " GCGCAATG ";
        Console.Write("    ");

        for (int i = 0; i < S1.Length; i++)
        {
            Console.Write(S1[i] + " ");
        }
        Console.WriteLine();

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            Console.Write(S2[i] + " ");
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }

            Console.WriteLine();
        }
    }

    static int GetLCSInternal(string str1, string str2, ref int[,] matrix)
    {
        int m = str1.Length;
        int n = str2.Length;

        for (int i = 1; i <= m; i++)
        {
            matrix[i, 0] = 0;
        }

        for (int j = 1; j <= n; j++)
        {
            matrix[0, j] = 0;
        }

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (str1[i - 1] == str2[j - 1])
                {
                    matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    sequence[i, j] = "UPLEFT";
                }
                else if (matrix[i - 1, j] >= matrix[i, j - 1])
	            {
		            matrix[i, j] = matrix[i - 1, j];
                    sequence[i, j] = "UP";
	            }
                else
	            {
                    matrix[i, j] = matrix[i, j - 1];
                    sequence[i, j] = "LEFT";
	            }
            }
        }

        return matrix[m, n];
    }

    static void PrintDiff(int[,] matrix, int i, int j, string S1, string S2)
    {
        if (i == 0 || j == 0)
        {
            return;
        }

        if (S1[i - 1] == S2[j - 1])
        {
            PrintDiff(matrix, i - 1, j - 1, S1, S2);
            Console.Write(S1[i - 1]);
        }
        else if (matrix[i, j] == matrix[i - 1, j])
        {
            PrintDiff(matrix, i - 1, j, S1, S2);
        }
        else
        {
            PrintDiff(matrix, i, j - 1, S1, S2);
        }
    }
}