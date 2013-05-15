namespace Matrix
{
    using System;

    public class MatrixEngine
    {
        private int row = 0;
        private int column = 0;
        private int step = 1;
        private int checks = 0;
        private const int directions = 8;
        private const int lastDirection = 7;

        public int[,] GenerateRotatingWalkMatirx(int matrixDimension)
        {
            int[,] matrix = this.CreateMatrix(matrixDimension);
            matrix = this.FillMatrix(matrix, ref row, ref column);

            return matrix;
        }

        private int[,] CreateMatrix(int dimension)
        {
            int[,] matrix = new int[dimension, dimension];
            return matrix;
        }
        

        private int[,] FillMatrix(int[,] matrix, ref int row, ref int column)
        {
            int matrixDimension = matrix.GetLength(0);
            int dx = 1;
            int dy = 1;

            while (true)
            {
                matrix[row, column] = step;

                if (!CheckIfHasCollision(matrix, row, column))
                {
                    step++;
                    break;
                }

                while (row + dx >= matrixDimension || row + dx < 0 ||
                    column + dy >= matrixDimension || column + dy < 0 ||
                    matrix[row + dx, column + dy] != 0)
                {
                    ChangeDirection(ref dx, ref dy);
                }

                row += dx;
                column += dy;
                step++;
            }

            if (checks == 0)
            {
                FindUnfilledCell(matrix, out row, out column);
                if (row != 0 && column != 0)
                {
                    FillMatrix(matrix, ref row, ref column);
                }

                checks++;
            }

            return matrix;
        }

        private void ChangeDirection(ref int dx, ref int dy)
        {
            int[] directionX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int currentDirection = 0;

            for (int count = 0; count < directions; count++)
            {
                if (directionX[count] == dx && directionY[count] == dy)
                {
                    currentDirection = count;
                    break;
                }
            }

            if (currentDirection == lastDirection)
            {
                dx = directionX[0];
                dy = directionY[0];
                return;
            }

            dx = directionX[currentDirection + 1];
            dy = directionY[currentDirection + 1];
        }

        private bool CheckIfHasCollision(int[,] matrix, int x, int y)
        {
            int[] directionX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < directions; i++)
            {
                if (x + directionX[i] >= matrix.GetLength(0) || x + directionX[i] < 0)
                {
                    directionX[i] = 0;
                }

                if (y + directionY[i] >= matrix.GetLength(0) || y + directionY[i] < 0)
                {
                    directionY[i] = 0;
                }
            }

            for (int i = 0; i < directions; i++)
            {
                if (matrix[x + directionX[i], y + directionY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private void FindUnfilledCell(int[,] matrix, out int row, out int column)
        {
            row = 0;
            column = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        row = i;
                        column = j;

                        return;
                    }
                }
            }
        }        
    }
}