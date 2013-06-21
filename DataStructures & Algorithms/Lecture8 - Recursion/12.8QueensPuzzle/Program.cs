using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int size = 8;

        SolveQueensProblem(new int[size, size], 0);

        Console.WriteLine(count);
    }
    static int count = 0;

    static void SolveQueensProblem(int[,] occupied, int columnIndex)
    {
        if (columnIndex == 8)
        {
            count++;
            return;
        }

        for (int rowIndex = 0; rowIndex < 8; rowIndex++)
        {
            if (occupied[rowIndex, columnIndex] == 0)
            {
                // Mark impossible elements in board
                MarkOccupied(occupied, +1, rowIndex, columnIndex);

                // Recurively call Queens
                SolveQueensProblem(occupied, columnIndex + 1);


                // Un-mark impossible elements in board
                MarkOccupied(occupied, -1, rowIndex, columnIndex);    
            }            
        }
    }

    static void MarkOccupied(int[,] occupied, int value, int rowIndex, int colIndex)
    {
        for (int i = 0; i < occupied.GetLength(0); i++)
        {
            occupied[i, colIndex] += value;
            occupied[rowIndex, i] += value;

            if (colIndex + i < occupied.GetLength(0) && 
                rowIndex + i < occupied.GetLength(0))
            {
                occupied[rowIndex + i, colIndex + i] += value;
            }

            if (colIndex + i < occupied.GetLength(0) && 
                rowIndex - i >= 0)
            {
                occupied[rowIndex - i, colIndex + i] += value;
            }
        }
    }
}
