using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.BiggerThanNeighboursOr_1
{
    class BiggerThanNeighboursOr
    {

        static void Main()
        {
            int[] numbers = { 1, 8, 7, 54, 6, 33, 23, 1, 5, 7, 2 };
            IsBiggerThanNeighbours(numbers);
        }
        static void IsBiggerThanNeighbours(int[] array)
        {
            for (int i = 1; i < array.Length - 1; i++)
            {
                if (array[i - 1] < array[i] && array[i] > array[i + 1])
                {
                    Console.WriteLine("element with index {0} ({1}) is bigger than its neighbours {2} and {3}", i,array[i], array[i - 1], array[i + 1]);
                }
                else
                {
                    Console.WriteLine("-1");
                }
            }
        }
    }
}
