using System;
using System.Collections.Generic;
using System.Linq;

class MaximalSum
{
    static void Main()
    {
        List<int> numbers = new List<int>() { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
        int sum = 0;
        int maxSum = 0;
        int index = 0;
        int count = 0;
        int maxCount = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            sum = sum + numbers[i];
            if (sum > 0)
            {
                count++;
                if (sum > maxSum)
                {
                    maxSum = sum;
                    index = i;
                    maxCount = count;
                }
            }
            else
            {
                sum = 0;
                count = 0;
            }
        }
        Console.Write("{ ");
        for (int i = index - maxCount+1; i <= index; i++)
        {
            Console.Write(numbers[i]);
            if (i != index)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine(" }");
    }
}
