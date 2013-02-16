using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SortArray_SelectionSort
{
    static void Main()
    {
        int[] array = { 7, 22, 4, 16, 2, 0, 8 };
        int min;
        int temp = 0;
        for (int i = 0; i < array.Length - 1; i++)
        {
            min = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[min])
                {
                    min = j;
                }
            }
            if (min != i)
            {
                temp = array[i];
                array[i] = array[min];
                array[min] = temp;

            }
                
        }
        for (int m = 0; m < array.Length; m++)
        {
            Console.WriteLine(array[m]);
        }
    }
}
