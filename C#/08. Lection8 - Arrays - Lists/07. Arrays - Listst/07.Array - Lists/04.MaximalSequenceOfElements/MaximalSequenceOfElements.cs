using System;
using System.Collections.Generic;
using System.Linq;

class MaximalSequenceOfElements
{
    static void Main()
    {
        List<int> array = new List<int>() { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };
        int previousElement = array[0];
        int count = 1;
        int maxCount = 0;
        int element = 0;
        for (int i = 0; i < array.Count-1; i++)
        {
            if (array[i+1] == previousElement)
            {
                count++;
                if (count > maxCount)
                {
                    maxCount = count;
                    element = array[i + 1];
                }
            }
            else
            {
                count = 1;
            }
            previousElement = array[i+1]; 
        }
        Console.Write("{ ");
        for (int i = maxCount-1; i >= 0; i--)
        {
            Console.Write(element);
            if (i != 0)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine(" }");
    }
}
