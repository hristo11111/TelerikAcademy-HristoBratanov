using System;
using System.Collections.Generic;
using System.Linq;

class CompareArrays
{
    static void Main()
    {
        List<int> firstArray = new List<int>(); 
        List<int> secondArray = new List<int>();
        Console.Write("enter the length of the arrays, N = ");
        int N = Int32.Parse(Console.ReadLine());
        Console.WriteLine("enter first array:");
        for (int i = 0; i < N; i++)
        {
            Console.Write("firstArray<{0}> = ", i);
            firstArray.Add(Int32.Parse(Console.ReadLine()));
        }
        Console.WriteLine();
        Console.WriteLine("enter second array:");
        for (int i = 0; i < N; i++)
        {
            Console.Write("secondArray<{0}> = ", i);
            secondArray.Add(Int32.Parse(Console.ReadLine()));
        }
        for (int i = 0; i < firstArray.Count; i++)
        {
            if (firstArray[i] == secondArray[i])
            {
                Console.WriteLine("elements with index {0} in both arrays are equal = {1}", i, firstArray[i]);
            }
            else if (firstArray[i] > secondArray[i])
            {
                Console.WriteLine("element with intex {0} in firstArray > element with index {0} in secondArray", i);
            }
            else
            {
                Console.WriteLine("element with intex {0} in firstArray < element with index {0} in secondArray", i);
            }
        }
        

    }
}
