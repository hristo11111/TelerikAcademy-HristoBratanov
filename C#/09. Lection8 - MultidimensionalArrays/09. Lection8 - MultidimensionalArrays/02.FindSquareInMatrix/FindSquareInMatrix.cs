using System;
using System.Collections.Generic;
using System.Linq;

class FindSquareInMatrix
{
    static void Main()
    {
        Console.Write("N = ");
        int N = Int32.Parse(Console.ReadLine());
        Console.Write("M = ");
        int M = Int32.Parse(Console.ReadLine());
        int[,] matrix = new int[N, M];
        Console.WriteLine("enter elements of the matrix: ");
        for (int rows = 0; rows < N; rows++)
        {
            for (int colls = 0; colls < M; colls++)
            {
                Console.Write("matrix[{0},{1}] = ", rows, colls);
                matrix[rows, colls] = Int32.Parse(Console.ReadLine());
            }
        }
        int bestSum = int.MinValue;
        int bestRow = 0;
        int bestColl = 0;
        for (int rows = 0; rows <= matrix.GetLength(0) - 3; rows++)
        {
            for (int colls = 0; colls <= matrix.GetLength(1) - 3; colls++)
            {
                int sum = matrix[rows, colls] + matrix[rows, colls + 1] + matrix[rows, colls + 2] +
                          matrix[rows + 1, colls] + matrix[rows + 1, colls + 1] + matrix[rows + 1, colls + 2] +
                          matrix[rows + 2, colls] + matrix[rows + 2, colls + 1] + matrix[rows + 2, colls + 2];
                if (sum > bestSum)
                {
                    bestSum = sum;
                    bestRow = rows;
                    bestColl = colls;
                }
            }
        }
        for (int i = bestRow; i < bestRow+3; i++)
        {
            for (int j = bestColl; j < bestColl+3; j++)
            {
                Console.Write("{0,4}", matrix[i,j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine("sum = {0}", bestSum);
    }
}
