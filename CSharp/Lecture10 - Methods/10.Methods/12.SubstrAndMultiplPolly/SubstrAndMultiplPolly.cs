using System;
using System.Collections.Generic;

class SubstrAndMultiplPolly
{
    static void Main()
    {
        List<decimal> poly1 = new List<decimal>{ 1.3M, -5M, -6M };
        List<decimal> poly2 = new List<decimal>{ 0M, -9.6M, 6M };
        PrintPoly(SubstractPoly(poly1, poly2));
        PrintPoly(MultiplicatePoly(poly1, poly2));
        PrintPoly(AddPoly(poly1,poly2));
    }

    static List<decimal> SubstractPoly(List<decimal> arr1, List<decimal> arr2)
    {
        List<decimal> substract = new List<decimal>();
        decimal substractValue = 0;
        for (int i = 0; i < arr1.Count; i++)
        {
            substractValue = arr1[i] - arr2[i];
            substract.Add(substractValue);
        }
        return substract;
    }

    static List<decimal> MultiplicatePoly(List<decimal> arr1, List<decimal> arr2)
    {
        List<decimal> multiplicate = new List<decimal>();
        for (int i = 0; i < arr1.Count; i++)
        {
            multiplicate.Add(arr1[i] * arr2[i]);
        }
        return multiplicate;
    }

    static List<decimal> AddPoly(List<decimal> arr1, List<decimal> arr2)
    {
        List<decimal> result = new List<decimal>();
        for (int i = 0; i < arr1.Count; i++)
        {
            result.Add(arr1[i] + arr2[i]);
        }
        return result;
    }

    static void PrintPoly(List<decimal> arr)
    {
        for (int i = arr.Count - 1; i >= 0; i--)
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
                Console.WriteLine(arr[0]);
            }
        }
    }
}
