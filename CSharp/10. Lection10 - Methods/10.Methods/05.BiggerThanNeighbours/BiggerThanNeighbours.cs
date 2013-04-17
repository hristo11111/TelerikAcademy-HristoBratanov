using System;
using System.Collections.Generic;

class BiggerThanNeighbours
{
    static void Main()
    {
        int[] numbers = { 1, 8, 7, 54, 6, 33, 23, 1, 5, 7, 2 };
        IsBiggerThanNeighbours(numbers);
    }
    static void IsBiggerThanNeighbours(int[] array)
    {
        for (int i = 1; i < array.Length-1; i++)
        {
            if (array[i-1] < array[i] && array[i] > array[i+1])
            {
                Console.WriteLine("element array[i] = {0} is bigger than its neighbours {1} and {2}", array[i], array[i-1], array[i+1]);
            }
        }
    }
}
