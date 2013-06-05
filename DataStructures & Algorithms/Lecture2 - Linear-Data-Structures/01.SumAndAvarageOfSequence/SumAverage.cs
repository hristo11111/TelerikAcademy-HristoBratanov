using System;
using System.Collections.Generic;
using System.Linq;

class SumAverage
{
    static void Main()
    {
        List<int> sequence = new List<int>();

        while (true)
        {
            string command = Console.ReadLine();

            if (command == "")
            {
                Console.WriteLine("End sequence!\n");
                break;
            }
            else
            {
                int number = int.Parse(command);
                sequence.Add(number);
            }
        }

        int sum = Sum(sequence);
        double average = CalculateAverage(sequence);

        
        Console.WriteLine("Results:");
        Console.WriteLine("Sum: {0}", sum);
        Console.WriteLine("Average: {0}", average);
    }

    private static double CalculateAverage(List<int> sequence)
    {
        double average = sequence.Average();

        return average;
    }

    private static int Sum(List<int> sequence)
    {
        int sum = sequence.Sum();

        return sum;
    }
}
