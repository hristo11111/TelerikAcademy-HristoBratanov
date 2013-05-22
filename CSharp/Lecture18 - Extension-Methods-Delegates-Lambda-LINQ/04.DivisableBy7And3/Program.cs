// Write a program that prints from given array of integers all numbers that are 
// divisible by 7 and 3. Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] numbers = {21,12,34,121,54,47,42};
        var query = numbers.Where(num => num % 3 == 0 && num % 7 == 0);
        foreach (var item in query)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
        numbers.DivisableBy3and7();
    }
}
