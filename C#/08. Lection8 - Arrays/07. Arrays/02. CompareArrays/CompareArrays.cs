using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CompareArrays
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] firstArray = new int[n];
        int[] secondArray = new int[n];
        for (int i = 0; i < firstArray.Length; i++)
        {
            firstArray[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < secondArray.Length; i++)
        {
            secondArray[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < secondArray.Length; i++)
        {
            if (firstArray[i] > secondArray[i])
            {
                Console.WriteLine("element {0} in the first array is > element {0} in the second array", i);
            }
            if (firstArray[i] == secondArray[i])
            {
                Console.WriteLine("element {0} in the first array is = element {0} in the second array", i);
            }
            if (firstArray[i] < secondArray[i])
            {
                Console.WriteLine("element {0} in the first array is < element {0} in the second array", i);
            }
        }
    }
}
