using System;
using System.Collections.Generic;
using System.Linq;

class MultipliedArray
{
    static void Main()
    {
        List<int> numbers = new List<int>(20);
        for (int i = 0; i < 20; i++)
		{
            numbers.Add(i*5); 
		}
        for (int i = 0; i < numbers.Count; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
}
