using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CompareCharArrays
{
    static void Main()
    {
        char[] firstArray = {'p', 'e', 'y', 'k'};
        char[] secondArray = { 'p', 'e', 's', 'k'};
        bool isBigger = false;
        bool isSmaller = false;
        if (firstArray.Length == secondArray.Length)
        {
            for (int i = 0; i < secondArray.Length; i++)
            {
                if (firstArray[i] > secondArray[i])
                {
                    isBigger = true;
                    Console.WriteLine("first array is bigger than second");
                    break;
                }
                if (firstArray[i] < secondArray[i])
                {
                    isSmaller = true;
                    Console.WriteLine("first array is smaller than second");
                    break;
                }
            }
            if ((isBigger == false) & (isSmaller == false))
            {
                Console.WriteLine("the arrays are equal");
            }
        }
        if (firstArray.Length > secondArray.Length)
        {
            for (int i = 0; i < secondArray.Length; i++)
            {
                if (firstArray[i] > secondArray[i])
                {
                    isBigger = true;
                    Console.WriteLine("first array is bigger than second");
                    break;
                }
                if (firstArray[i] < secondArray[i])
                {
                    isSmaller = true;
                    Console.WriteLine("first array is smaller than second");
                    break;
                }
            }
            if ((isBigger == false) & (isSmaller == false))
            {
                Console.WriteLine("second array is smaller");
            }
        }
        if (firstArray.Length < secondArray.Length)
        {
            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] > secondArray[i])
                {
                    isBigger = true;
                    Console.WriteLine("first array is bigger than second");
                    break;
                }
                if (firstArray[i] < secondArray[i])
                {
                    isSmaller = true;
                    Console.WriteLine("first array is smaller than second");
                    break;
                }
            }
            if ((isBigger == false) & (isSmaller == false))
            {
                Console.WriteLine("first array is smaller");
            }
        }
    }
}
