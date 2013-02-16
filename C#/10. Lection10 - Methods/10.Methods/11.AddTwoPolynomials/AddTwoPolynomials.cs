using System;
using System.Collections.Generic;

class AddTwoPolynomials
{
    static void Main()
    {
        decimal[] poly1 = { 2M, 5M, -6M };
        decimal[] poly2 = { -5M, -9.6M, 6M };
        decimal[] result = AddPolynomials(poly1, poly2);
        PrintAddedPolynomials(result);
        Console.WriteLine();
    }

    static decimal[] AddPolynomials(decimal[] arr1, decimal[] arr2)
    {
        decimal[] result = new decimal[arr1.Length];
        for (int i = 0; i < arr1.Length; i++)
        {
            result[i] = arr1[i] + arr2[i];
        }
        return result;
    }

    static void PrintAddedPolynomials(decimal[] arr)
    {
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            if (arr[i] != 0 && i != 0)
            {
                if (arr[i-1] >= 0)
                {
                    Console.Write("{0}x^{1} + ", arr[i], i);    
                }
                else
                {
                    Console.Write("{0}x^{1} ", arr[i], i);
                }
            }
            else if (i == 0)
            {
                Console.Write(arr[i]);
            }
        }
    }
}
