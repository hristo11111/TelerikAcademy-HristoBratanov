using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class ReadAndCalculMatrixInFile
{
    static void Main()
    {
        int sum = 0;
        int maxSum = Int32.MinValue;
        Console.Write("N = ");
        int N = Int32.Parse(Console.ReadLine());
        StreamWriter input = new StreamWriter("input.txt");
        using (input)
        {
            input.WriteLine(N);
            for (int i = 0; i < N; i++)
            {
                input.WriteLine(Console.ReadLine());
            }
        }
        StreamReader readInput = new StreamReader("input.txt");
        using (readInput)
        {
            string[] firstLineArr = new string[N];
            int[] firstLineArrInt = new int[N];
            string[] nextLineArr = new string[N];
            int[] nextLineArrInt = new int[N];
            string firstLine = readInput.ReadLine();
            firstLine = readInput.ReadLine();
            string nextLine = readInput.ReadLine();
            while (nextLine != null)
            {
                firstLineArr = firstLine.Split(' ');
                firstLineArrInt = ConvertStringArrayToIntArray(firstLineArr);
                nextLineArr = nextLine.Split(' ');
                nextLineArrInt = ConvertStringArrayToIntArray(nextLineArr);
                for (int i = 0; i < N-1; i++)
                {
                    sum = firstLineArrInt[i] + firstLineArrInt[i + 1] + nextLineArrInt[i] + nextLineArrInt[i + 1];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                    }
                }
                firstLine = nextLine;
                nextLine = readInput.ReadLine();
            }
        }
        SaveResult(maxSum);
    }

    static int[] ConvertStringArrayToIntArray(string[] arr)
    {
        int[] arrInt = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            arrInt[i] = Int32.Parse(arr[i]);
        }

        return arrInt;
    }

    static void SaveResult(int res)
    {
        StreamWriter result = new StreamWriter("result.txt");
        using (result)
        {
            result.Write(res);    
        }
        
    }
}
