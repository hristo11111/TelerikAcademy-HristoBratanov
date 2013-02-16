using System;
using System.Collections.Generic;
using System.Linq;

class MaxSumOfElementsInArray
{
    static void Main()
    {
        Console.Write("N = ");
        int N = Int32.Parse(Console.ReadLine());
        Console.Write("K = ");
        int K = Int32.Parse(Console.ReadLine());
        List<int> numbers = new List<int>();
        for (int i = 0; i < N; i++)
        {
            Console.Write("numbers[{0}] = ", i);
            int num = Int32.Parse(Console.ReadLine());
            numbers.Add(num);
        }
        numbers.Sort();
        int sum = 0;
        for (int i = N-1; i > N-K-1; i--)
        {
            sum = sum + numbers[i];
        }
        Console.WriteLine("the maximal sum of {0} elements in the array is = {1}", K, sum);
    }
}