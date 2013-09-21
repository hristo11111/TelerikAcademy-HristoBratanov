﻿using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Tuple<int, int>> path = new List<Tuple<int, int>>();

    static char[,] matrix =
        {
            {' ', ' ', ' ', '*', ' ', ' ', ' '},
            {'*', '*', ' ', '*', ' ', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', '*', '*', '*', '*', '*', ' '},
            {' ', ' ', ' ', '*', '*', ' ', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
        };

    static void Main()
    {
        Console.Write("From row: ");
        int startRow = int.Parse(Console.ReadLine());
        Console.Write("From column: ");
        int startCol = int.Parse(Console.ReadLine());

        Console.Write("To row: ");
        int endRow = int.Parse(Console.ReadLine());
        Console.Write("To column: ");
        int endCol = int.Parse(Console.ReadLine());

        matrix[endRow, endCol] = 'e';

        FindPath(startRow, startCol);
    }

    private static void FindPath(int row, int col)
    {
        if (row < 0 || col < 0 || row > matrix.GetLength(0) - 1 || col > matrix.GetLength(1) - 1)
        {
            return;
        }

        if (matrix[row, col] == 'e')
        {
            path.Add(new Tuple<int, int>(row, col));
            Print(path);
            path.RemoveAt(path.Count - 1);
            return;
        }

        if (matrix[row, col] != ' ')
        {
            return;
        }

        matrix[row, col] = 'V';
        Tuple<int, int> pair = new Tuple<int, int>(row, col);
        path.Add(pair);

        FindPath(row + 1, col);
        FindPath(row, col - 1);
        FindPath(row - 1, col);
        FindPath(row, col + 1);

        matrix[row, col] = ' ';
        path.RemoveAt(path.Count - 1);
    }

    private static void Print(List<Tuple<int, int>> path)
    {
        Console.Write("<<Start>>----");

        foreach (var item in path)
        {
            Console.Write("{" + item.Item1 + ", " + item.Item2 + "}");
            Console.Write(" > ");
        }

        Console.WriteLine("----<<End>>");
    }
}