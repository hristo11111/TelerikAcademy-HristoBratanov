using System;
using System.Linq;

class Program
{
    static void Main()
    {
        double[] data = {3.5, 5, -23, 6, 0.25454};

        StatisticsCalculator statisticsCalculator = new StatisticsCalculator(data);
        double max = statisticsCalculator.GetMax();
        double min = statisticsCalculator.GetMin();
        double average = statisticsCalculator.GetAverage();

        Console.WriteLine(max);
        Console.WriteLine(min);
        Console.WriteLine(average);
    }
}
