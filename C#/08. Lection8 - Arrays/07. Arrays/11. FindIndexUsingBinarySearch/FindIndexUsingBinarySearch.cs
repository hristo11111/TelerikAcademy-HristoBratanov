using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FindIndexUsingBinarySearch
{
    static void Main()
    {
        int element = 3;
        int[] array = { 1, 3, 4, 6, 8, 99, 100, 123, 124, 145 };
        int iMin = array[0];
        int iMax = array[array.Length - 1];
        int iMid = (array.Length - 1) / 2;
        while (iMax > iMin)
        {
            if (element < array[iMid])
            {
                iMid = iMid - 1;
            }
            else if (element > array[iMid])
            {
                iMid = iMid + 1;
            }
            else
            {
                Console.WriteLine(iMid);
                break;
            }
        }
    }
}
