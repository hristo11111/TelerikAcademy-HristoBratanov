using System;
using System.Collections.Generic;
using System.Linq;

class ExactSubsetSubInArray
{
    static void Main()
    {
        //if there are numbers who appear more than one time in the array, some answers will be identical
        //if you want to have just one answer, in Line 52 replace "Console.WriteLine("-----------------------")" with "break"  

        // create List of numbers (read N from console)
        List<int> numbers = new List<int>();
        Console.Write("N = ");
        int N = Int32.Parse(Console.ReadLine());
        Console.WriteLine("enter {0} elements in the array", N);
        for (int i = 0; i < N; i++)
        {
            numbers.Add(Int32.Parse(Console.ReadLine()));
        }
        numbers.Sort();
        Console.Write("S = ");
        int S = Int32.Parse(Console.ReadLine()); // read S from console
        Console.Write("K = ");
        int K = Int32.Parse(Console.ReadLine()); // read K from console
        int sum = 0;
        int count = 0;
        bool isThereResult = false;
        List<int> result = new List<int>();
        int combinations = (int)Math.Pow(2, (numbers.Count - 1)); // possible combinations between the elements in array

        // search for sums equal to S using bits
        for (int i = 1; i < combinations; i++)
        {
            for (int j = 0; j < numbers.Count; j++)
            {
                int number = (i >> j) & 1;
                if (number == 1)
                {
                    sum = sum + numbers[j];
                    count++;
                    result.Add(numbers[j]); // insert element of the sum in new List
                }
            }
            if ((sum == S) && (count == K))
            {
                isThereResult = true;
                for (int m = 0; m < result.Count; m++)
                {
                    Console.WriteLine(result[m]);
                }
                Console.WriteLine("-----------------------");
            }
            else
            {
                result.Clear();
                sum = 0;
                count = 0;
            }
        }
        if (isThereResult == false)
        {
            Console.WriteLine("there is no such sum");
        }
    }
}
