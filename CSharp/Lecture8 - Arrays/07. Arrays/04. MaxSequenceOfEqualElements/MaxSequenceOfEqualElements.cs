using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MaxSequenceOfEqualElements
{
    static void Main()
    {
        int maxcount = 1;
        int count = 1;
        int[] numbers = { 3, 3, 3, 3, 3, 3, 3, 1, 2, 3, 4, 4, 4, 4, 4, 4, 4, 4, 6, 2, 3, 3, 3, 3, 3, 3 };
        int maxValue = numbers[0];
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            if (numbers[i] == numbers[i+1])
            {
                count = count + 1;
                if (count > maxcount)
                {
                    maxcount = count;
                    maxValue = numbers[i];
                }
            }
            else
            {
                count = 1;
            }
        }
        Console.WriteLine("the biggest sequence of equal integers is the sequence of {0}'s is = {1} pcs ", maxValue, maxcount);
    }
}
