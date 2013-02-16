using System;
using System.Collections.Generic;
using System.Linq;

class SelectionSort
{
    static void Main()
    {
        Console.Write("enter the length of the array, N = ");
        int N = Int32.Parse(Console.ReadLine());
        List<int> numbers = new List<int>();
        for (int i = 0; i < N; i++)
        {
            Console.Write("numbers[{0}] = ", i);
            numbers.Add(Int32.Parse(Console.ReadLine()));
        }
        List<int> numbersSorted = new List<int>();
        int index = 0;
        for (int j = 0; j < numbers.Count; j++)
        {
            index = j;
            int min = numbers[j];
            int temp = numbers[j];
            for (int i = j+1; i < numbers.Count; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                    index = i;
                }
            }
            numbers[j] = min;
            numbers[index] = temp;
        }
        Console.WriteLine("the sorted array is: ");
        for (int i = 0; i < numbers.Count; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
}
