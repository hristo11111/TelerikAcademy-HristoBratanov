using System;
using System.Collections.Generic;
using System.Linq;

class SequencesInMatrix
{
    static void Main()
    {
        //string[,] matrix = {
        //                       {"ha",  "ho",  "ho", "hi", "hu"},
        //                       {"fo",  "fo",  "fo", "fo", "l"},
        //                       {"xxx", "ho",  "ha", "xl", "li"},
        //                       {"xnx", "ho",  "ha", "h8", "li"},
        //                       {"xxx", "ho",  "ha", "xh", "ha"},
        //                   };
        Console.Write("N = ");
        int N = Int32.Parse(Console.ReadLine());
        Console.Write("M = ");
        int M = Int32.Parse(Console.ReadLine());
        string[,] matrix = new string[N, M];
        int k = 4;
        // k=0 => horizontal sequence
        // k=1 => vertical sequence
        // k=2 => right diagonal sequence
        // k=3=> left diagonal sequence

        int[, ,] storage = new int[N,M,k];
        int bestSequence = 1;
        int bestRow = 0;
        int bestColl = 0;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                Console.Write("matrix[{0},{1}] = ", i,j);
                matrix[i,j] = Console.ReadLine();

            }
        }
        for (int rows = 0; rows < N; rows++)
        {
            for (int colls = 0; colls < M; colls++)
            {
                for (k = 0; k < 4; k++)
                {
                    storage[rows, colls, k] = 1;
                }
                
                // check horizontal lines
                if (colls > 0 && matrix[rows, colls] == matrix[rows, colls-1])
                {
                    storage[rows, colls, 0] = storage[rows, colls - 1, 0] + 1;
                }

                //check vertical lines
                if (rows > 0 && matrix[rows, colls] == matrix[rows-1, colls])
                {
                    storage[rows, colls, 1] = storage[rows - 1, colls, 1] + 1;
                }

                //check right diagonal lines
                if (rows > 0 && colls > 0 && matrix[rows-1, colls-1] == matrix[rows, colls])
                {
                    storage[rows, colls, 2] = storage[rows - 1, colls - 1, 2] + 1; 
                }

                //check left diagonal lines
                if (rows > 0 && colls < N - 1 && matrix[rows, colls] == matrix[rows-1, colls+1])
                {
                    storage[rows, colls, 3] = storage[rows - 1, colls + 1, 3] + 1;
                }

                //check for max sequence
                for (k = 0; k < 4; k++)
                {
                    if (storage[rows, colls, k] > bestSequence)
                    {
                        bestSequence = storage[rows, colls,k];
                        bestColl = colls;
                        bestRow = rows;
                    }
                }
            }
        }
        for (int i = 0; i < bestSequence; i++)
        {
            Console.Write(matrix[bestRow, bestColl]);
            if (i < bestSequence - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine();
    }
    
}
