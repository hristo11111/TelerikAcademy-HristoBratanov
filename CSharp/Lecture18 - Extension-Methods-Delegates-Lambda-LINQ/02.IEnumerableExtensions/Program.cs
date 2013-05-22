//Implement a set of extension methods for IEnumerable<T> that implement 
//the following group functions: sum, product, min, max, average.


using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        decimal[] numbers = new decimal[5] { 4.7M, 6.67M, 8, 9, 12 };
        List<string> numList = new List<string>() { "4", "5", "6", "3", "21", "3" };
        Console.WriteLine(numList.Sum());
        Console.WriteLine(numbers.Product());
        Console.WriteLine(numList.Min());
        Console.WriteLine(numbers.Min());
        Console.WriteLine(numList.Max());
        Console.WriteLine(numbers.Max());
        Console.WriteLine(numbers.Average());
        
    }
}
