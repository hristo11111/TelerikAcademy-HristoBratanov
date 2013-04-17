using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SequenceOfMaximalSum
{
    static void Main()
    {
        int sum = 0;
        int index = 0;
        int count = 0;
        int maxSum = 0;
        int[] array = { 22, 3, -6, -1, 2, -1, 1, 4, -8, 1 };
        for (int i = 0; i < array.Length; i++)
		{
            if (array[i] >= 0)
            {
                sum = sum + array[i];
                if (sum > maxSum)
                {
                    maxSum = sum;
                    index = i;
                    count++;
                }
            }
            else
            {
                if (sum + array[i] >= 0)
                {
                    sum = sum + array[i];
                }
                else if (sum + array[i] < 0)
                {
                    
                    sum = 0;
                }
            }
		}
        Console.WriteLine(maxSum);
        Console.Write("{");
        for (int j = index - count; j < index; j++)
        {
            Console.Write(array[j] + ", ");
        }
        Console.WriteLine(array[index]+"}");
    }
}
