using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FindSequenceOfGivenSum
{
    static void Main()
    {
        int sum = 0;
        int index = 0;
        int elementsInSum = 0;
        int[] array = { 4, 3, 1, 4, 2, 5, 8 };
        for (int i = 0; i < array.Length; i++)
        {
            sum = sum + array[i];
            elementsInSum++;
            if (sum == 11)
            {
                index = i;
                for (int j = index - elementsInSum + 1; j <= index; j++)
                {
                    Console.WriteLine(array[j]);
                    
                }
            }
            else if (sum > 11)
            {
                sum = 0;
                elementsInSum = 0;
                i = i - 1;
            }
        }
    }
}
