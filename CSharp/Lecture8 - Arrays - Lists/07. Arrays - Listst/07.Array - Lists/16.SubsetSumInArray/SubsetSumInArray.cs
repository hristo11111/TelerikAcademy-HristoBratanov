using System;
using System.Collections.Generic;
using System.Linq;

class SubsetSumInArray
{
    static void Main()
    {
        //if there are numbers who appear more than one time in the array, some answers will be identical

        // create List of numbers (read N from console)
        List<int> numbers = new List<int>();
        int N = Int32.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            numbers.Add(Int32.Parse(Console.ReadLine()));
        }
        numbers.Sort();
        int S = Int32.Parse(Console.ReadLine()); // read S from console
        int sum = 0;
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
                    result.Add(numbers[j]); // insert element of the sum in new List
                }
            }
            if (sum == S)
            {
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
            }
        }
    }
}
