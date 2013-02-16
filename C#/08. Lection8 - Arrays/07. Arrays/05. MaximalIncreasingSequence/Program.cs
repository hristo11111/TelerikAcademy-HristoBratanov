using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        int[] array = {1, 2, 3, 4, 4, 1, 2, 3, 4, 5, 6, 7, 1, 3};
        int maxSequence = 1;
        int count = 1;
        int maxPosition = 1;
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] <= array[i+1])
            {
                count = count + 1;
                if (count > maxSequence)
                {
                    maxSequence = count;
                    maxPosition = i + 1;
                }
            }
            else
            {
                count = 1;
            }
        }
        Console.WriteLine("maximal sequence is: " + maxSequence);
        Console.Write("the sequence is: ");
        for (int i = (maxPosition - maxSequence + 1); i <= maxPosition  ; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}
