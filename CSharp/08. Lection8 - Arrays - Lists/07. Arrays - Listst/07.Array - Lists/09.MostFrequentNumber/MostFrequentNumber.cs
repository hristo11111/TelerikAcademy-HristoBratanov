using System;
using System.Collections.Generic;
using System.Linq;

class MostFrequentNumber
{
    static void Main()
    {
        List<int> numbers = new List<int>() {4,1,1,4,2,3,4,4,1,2,4,9,3};
        numbers.Sort();
        int element = numbers[0];
        int sum = 1;
        int maxSum = 1;
        int maxElement = numbers[0];
        for (int i = 1; i < numbers.Count; i++)
        {
            if (element == numbers[i])
            {
                sum++;
                if (sum > maxSum)
                {
                    maxSum = sum;
                    maxElement = element;
                }
            }
            else
            {
                element = numbers[i];
                sum = 1;
            }
        }
        Console.WriteLine("{0} ({1} times)", maxElement, maxSum);
    }
}
