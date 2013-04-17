using System;
using System.Collections.Generic;

class MultipleTasksParams
{
    static void Main()
    {
        Console.WriteLine("Min = {0}", FindMinimum(10, 2, 5, 2, 1));
        Console.WriteLine("Max = {0}", FindMaximum(10, 2, 5, 2, 1));
        Console.WriteLine("Average = {0}", FindAverage(10, 2, 5, 3, 1));
        Console.WriteLine("Sum = {0}", FindSum(10, 2, 5, 3, 1));
        Console.WriteLine("Product = {0}", FindProduct(10, 2, 5, 3, 1));
    }

    static int FindMinimum(params int[] numbers)
    {
        int min = numbers[0];
        foreach (var item in numbers)
	    {
		if (item < min)
            {
                min = item;
            }
	    }
        return min;
    }

    static int FindMaximum(params int[] numbers)
    {
        int max = numbers[0];
        foreach (var item in numbers)
        {
            if (item > max)
            {
                max = item;
            }
        }
        return max;
    }

    static double FindAverage(params int[] numbers)
    {
        double sum = 0;
        foreach (var item in numbers)
        {
            sum = sum + item;
        }
        return (sum / numbers.Length);
    }

    static int FindSum(params int[] numbers)
    {
        int sum = 0;
        foreach (var item in numbers)
        {
            sum = sum + item;
        }
        return sum;
    }

    static int FindProduct(params int[] numbers)
    {
        int product = 1;
        foreach (var item in numbers)
        {
            product = product * item;
        }
        return product;
    }
}
