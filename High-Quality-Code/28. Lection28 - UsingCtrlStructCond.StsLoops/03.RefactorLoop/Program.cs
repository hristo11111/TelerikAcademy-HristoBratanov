using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int index = 0;
        int maxIndex = 100;
        int[] array = new int[100];
        var expectedValue = 555;

        for (index = 0; index < maxIndex; index++)
        {
            if (index % 10 == 0)
            {
                Console.WriteLine(array[index]);

                if (CheckArrValueEqualsExpValue(array, expectedValue, ref index))
                {
                    Console.WriteLine("Value Found");
                }
            }
        }
    }
  
    private static bool CheckArrValueEqualsExpValue(int[] array, int expectedValue, ref int index)
    {
        if (array[index] == expectedValue)
        {
            index = 666;

            if (index == 666)
            {
                return true;
            }
        }
        return false;
    }
}
