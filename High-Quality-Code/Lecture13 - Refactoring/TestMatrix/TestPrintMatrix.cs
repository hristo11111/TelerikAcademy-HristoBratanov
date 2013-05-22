﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Matrix;
using System.Text;

namespace TestMatrix
{
    [TestClass]
    public class TestPrintMatrix
    {
        public string MatrixAsString(int[,] matrix)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result.Append(matrix[i, j] + " ");
                }
            }

            result.Length--;
            return result.ToString();
        }

        [TestMethod]
        public void TestPrintMatrixSize4()
        {
            MatrixEngine engine = new MatrixEngine();

            int n = 4;
            int[,] expectedMatrix =
            {
                {1, 10, 11, 12},
                {9,  2, 15, 13},
                {8, 16,  3, 14},
                {7,  6,  5,  4}
            };

            string expected = MatrixAsString(expectedMatrix);
            int[,] actualMatrix = engine.GenerateRotatingWalkMatirx(n);
            string actual = MatrixAsString(actualMatrix);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPrintMatrixSize7()
        {
            MatrixEngine engine = new MatrixEngine();

            int n = 7;
            int[,] expectedMatrix =
            {
                {1, 19, 20, 21, 22, 23, 24},
                {18,  2, 33, 34, 35, 36, 25},
                {17, 40,  3, 32, 39, 37, 26},
                {16, 48, 41,  4, 31, 38, 27},
                {15, 47, 49, 42,  5, 30, 28},
                {14, 46, 45, 44, 43,  6, 29},
                {13, 12, 11, 10,  9,  8,  7}
            };

            string expected = MatrixAsString(expectedMatrix);
            int[,] actualMatrix = engine.GenerateRotatingWalkMatirx(n);
            string actual = MatrixAsString(actualMatrix);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInvalidOutputMatrixSize7()
        {
            MatrixEngine engine = new MatrixEngine();

            int n = 7;
            int[,] expectedMatrix =
            {
                { 1, 19, 20, 21, 22, 23, 24},
                {18,  2, 33, 34, 35, 36, 25},
                {17, 39,  3, 32, 39, 37, 26},
                {16, 48, 41,  4, 31, 38, 27},
                {15, 47, 49, 42,  5, 30, 28},
                {14, 46, 45, 44, 43,  6, 29},
                {13, 12, 11, 10,  9,  8,  7}
            };

            string expected = MatrixAsString(expectedMatrix);
            int[,] actualMatrix = engine.GenerateRotatingWalkMatirx(n);
            string actual = MatrixAsString(actualMatrix);
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void TestInvalidOutputMatrixWith7InFirstPosition()
        {
            MatrixEngine engine = new MatrixEngine();

            int n = 7;
            int[,] expectedMatrix =
            {
                {50, 19, 20, 21, 22, 23, 24},
                {18,  2, 33, 34, 35, 36, 25},
                {17, 40,  3, 32, 39, 37, 26},
                {16, 48, 41,  4, 31, 38, 27},
                {15, 47, 49, 42,  5, 30, 28},
                {14, 46, 45, 44, 43,  6, 29},
                {13, 12, 11, 10,  9,  8,  7}
            };

            string expected = MatrixAsString(expectedMatrix);
            int[,] actualMatrix = engine.GenerateRotatingWalkMatirx(n);
            string actual = MatrixAsString(actualMatrix);
            Assert.AreNotEqual(expected, actual);
        }
    }
}
