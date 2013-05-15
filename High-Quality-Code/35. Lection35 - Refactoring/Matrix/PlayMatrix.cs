namespace Matrix
{
    using System;
    using System.Linq;

    class PlayMatrix
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a positive number: ");
            string input = Console.ReadLine();
            int number = 0;
            while (!int.TryParse(input, out number) || number < 0 || number > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            int matrixDimension = number;

            MatrixEngine engine = new MatrixEngine();
            int[,] matrix = engine.GenerateRotatingWalkMatirx(matrixDimension);

            PrintMatrix(matrix);
        }

        static void PrintMatrix(int[,] matrix)
        {
            int matrixDimension = matrix.GetLength(0);

            for (int i = 0; i < matrixDimension; i++)
            {
                Console.Write("{");
                for (int j = 0; j < matrixDimension; j++)
                {
                    Console.Write("{0, 3}", matrix[i, j]);
                    if (j != matrixDimension - 1)
                    {
                        Console.Write(",");    
                    }
                    
                }
                Console.Write("}");


                Console.WriteLine();
            }
        }
    }
}
