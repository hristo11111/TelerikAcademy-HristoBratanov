using System;
using System.Collections.Generic;
using System.Linq;

class BinarySearch
{
    static void Main()
    {
        List<int> numbers = new List<int>() {1,3,12,6,8,22,7,8,9,14};
        numbers.Sort();
        int goal = Int32.Parse(Console.ReadLine());
        int start = 0;
        int end = numbers.Count - 1;
        int index = -1;
        while (start < end)
        {
            int center = (start + end) / 2;
            if (numbers[center] == goal)
            {
                index = center;
                break;
            }
            else if (numbers[center] > goal)
            {
                end = center - 1;
            }
            else if (numbers[center] < goal)
            {
                start = center + 1;
            }
        }
        if (index != -1)
        {
            Console.WriteLine("the index of the element {0} is {1}", goal, index);
        }
        else
        {
            Console.WriteLine("no such number in the array");
        }
    }
}