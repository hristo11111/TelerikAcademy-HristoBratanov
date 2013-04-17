using System;
using System.Collections.Generic;

class SortAscAndDesc
{
    static void Main()
    {
        int index = 4;
        int[] array = {4,6,7,8,12,4,32,5,15,1};
        Console.WriteLine("the bigest element for index {0} = {1}", index, array[PickTheBiggest(array, index)]);
        int[] ascending = SortAscending(array);
        int[] descending = SortDescending(array);
        PrintArray(ascending);
        Console.WriteLine();
        PrintArray(descending);

        

    }
    static int PickTheBiggest(int[] numbers, int index)
    {
        int max = numbers[index];
        int maxIndex = index;
        for (int i = index; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
                maxIndex = i;
            }
        }
        return maxIndex;
    }
    
    static int[] SortAscending(int[] numbers)
    {
        int[] arrayAscending = new int[numbers.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            int indexOfBiggest = PickTheBiggest(numbers, i);
            arrayAscending[numbers.Length - 1 - i] = numbers[indexOfBiggest];
            int swap = numbers[i];
            numbers[i] = numbers[indexOfBiggest];
            numbers[indexOfBiggest] = swap;
        }
        return arrayAscending;
    }
    static int[] SortDescending(int[] numbers)
    {
        int[] sort = SortAscending(numbers);
        int[] arrayDescending = new int[sort.Length];
        for (int i = 0; i < arrayDescending.Length; i++)
        {
            arrayDescending[i] = sort[sort.Length - i - 1];
        }
        return arrayDescending;
    }
    static void PrintArray(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write(numbers[i] + " ");
        }
    }
}
