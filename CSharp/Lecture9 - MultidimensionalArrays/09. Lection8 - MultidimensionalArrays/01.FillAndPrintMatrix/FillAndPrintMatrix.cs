using System;
using System.Collections.Generic;
using System.Linq;

class FillAndPrintMatrix
{
    static void Main()
    {
        //print matrix a)
        Console.Write("n= ");
        int nA = Int32.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine("Matrix a):");
        int[,] matrixA = new int[nA,nA];
        int counterA = 1;
        for (int rows = 0; rows < nA; rows++)
        {
            for (int colls = 0; colls < nA; colls++)
            {
                matrixA[colls, rows] = counterA++;
            }
        }
        for (int i = 0; i < matrixA.GetLength(0); i++)
        {
            for (int j = 0; j < matrixA.GetLength(1); j++)
            {
                Console.Write("{0,4}", matrixA[i,j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine("-----------------------");

        //print matrix b)
        Console.Write("n= ");
        int nB = Int32.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine("Matrix b):");
        int[,] matrixB = new int[nA, nA];
        int counterB = 1;
        for (int colls = 0; colls < nB; colls+=2)
        {
            for (int rows = 0; rows < nB; rows++)
            {
                matrixB[rows, colls] = counterB++;
            }
            for (int rows = nB - 1; rows >= 0; rows--)
            {
                matrixB[rows, colls + 1] = counterB++;
            }
        }
        for (int i = 0; i < matrixB.GetLength(0); i++)
        {
            for (int j = 0; j < matrixB.GetLength(1); j++)
            {
                Console.Write("{0,4}", matrixB[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine("-----------------------");

        //print matrix "c"
        Console.Write("n= ");
        int nC = Int32.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine("Matrix c):");
        int[,] matrixC = new int[nC, nC];
        int counterC = 1;
        for (int row = nC-1; row >= 0; row--)
        {
            for (int coll = 0; coll < nC-row; coll++)
            {
                matrixC[row + coll, coll] = counterC++;
            }
        }
        for (int col = 1; col < nC; col++)
        {
            for (int row = 0; row < nC-col; row++)
            {
                matrixC[row, row + col] = counterC++;
            }
        }
        for (int i = 0; i < nC; i++)
        {
            for (int j = 0; j < nC; j++)
            {
                Console.Write("{0,4}", matrixC[i,j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine("-----------------------");

        // print matrix d);
        Console.Write("n= ");
        int nD = Int32.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine("Matrix c):");
        int[,] matrixD = new int[nD, nD];
        int counterD = 1;
        int index = 0;
        while (counterD < matrixD.GetLength(0)*matrixD.GetLength(1))
        {
            for (int cols = index; cols < index + 1; cols++)
            {
                for (int rows = index; rows < nD-index; rows++)
                {
                    matrixD[rows, cols] = counterD++;
                }
            }
            for (int rows = nD - 1 - index; rows > nD - index - 2; rows--)
            {
                for (int cols = index + 1; cols < nD - index; cols++)
                {
                    matrixD[rows, cols] = counterD++;
                }
            }
            for (int cols = nD - 1 - index; cols > nD - 2 - index; cols--)
            {
                for (int row = nD - 2 - index; row >= 0 + index; row--)
                {
                    matrixD[row, cols] = counterD++;
                }
            }
            for (int rows = index; rows < 1+index; rows++)
            {
                for (int cols = nD - 2 - index; cols > 0+index; cols--)
                {
                    matrixD[rows, cols] = counterD++;
                }
            }
            index++;
        }
        for (int i = 0; i < matrixD.GetLength(0); i++)
        {
            for (int j = 0; j < matrixD.GetLength(1); j++)
            {
                Console.Write("{0,4}", matrixD[i,j]);
            }
            Console.WriteLine();
        }
    }
}
