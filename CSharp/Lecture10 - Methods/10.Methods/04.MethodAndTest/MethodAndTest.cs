using System;
using System.Collections.Generic;

public class MethodAndTest
{
    public static int result;
    public static int number;

    static void Main()
    {
        Console.Write("number to check = ");
        number = Int32.Parse(Console.ReadLine());
        int[] array = { 2, 2, 1, 1, 2, 1, 4 };
        CountTheElements(array);
        Console.WriteLine(result);

    }

    public static void CountTheElements(int[] arr)
    {
        bool isEqual = false;
        int sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (number == arr[i])
            {
                sum++;
                isEqual = true;
            }

        }
        if (isEqual == true)
        {
            result = sum;
        }

        else
        {
            result = 0;
        }

    }

}
