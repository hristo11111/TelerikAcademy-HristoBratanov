using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MostFrequentNumber
{
    static void Main()
    {
        int minElement = 0;
        int temp = 0;
        int sum = 1;
        int index = 0;
        int maxSum = 0;
        int[] array = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
        for (int i = 0; i < array.Length; i++)
        {
            minElement = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[minElement])
                {
                    minElement = j;    
                }
            }
            if (array[minElement] != array[i])
            {
                temp = array[i];
                array[i] = array[minElement];
                array[minElement] = temp;
            }
        }
        for (int k = 0; k < array.Length - 1; k++)
        {
            if (array[k] == array[k + 1])
            {
                sum = sum + 1;
                index = k + 1;
            }
            else
            {
                sum = 1;
            }
            if (sum > maxSum)
            {
                maxSum = sum;
            }
        }
        if (maxSum != 1)
        {
            Console.WriteLine("the most frequent number is: " + array[index]);
            Console.WriteLine("it appears {0} times in the array", maxSum);    
        }
        else
        {
            Console.WriteLine("all numbers are different");
        }
        
    }
}
