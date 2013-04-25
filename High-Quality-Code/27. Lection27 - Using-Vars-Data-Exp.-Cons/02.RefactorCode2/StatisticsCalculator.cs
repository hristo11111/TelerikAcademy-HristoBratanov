using System;
using System.Linq;

class StatisticsCalculator
{
    private double[] statisticsData;

    public double[] StatisticsData
    {
        get
        {
            return this.statisticsData;
        }
        set
        {
            if (value.Length == 0)
            {
                throw new ArgumentException("statisticsData.length", "statistics data array can not be empty");
            }

            this.statisticsData = value;
        }
    }

    public StatisticsCalculator(double[] statisticsData)
    {
        this.StatisticsData = statisticsData;
    }

    public double GetMax()
    {
        double max = this.GetBiggestDataElement(this.StatisticsData);
        return max;
    }

    public double GetMin()
    {
        double min = this.GetSmallestDataElement(this.StatisticsData);
        return min;
    }

    public double GetAverage()
    {
        double average = this.GetAverageValueOfDataElement(this.StatisticsData);
        return average;
    }

    private double GetBiggestDataElement(double[] data)
    {
        double biggestElement = double.MinValue;

        for (int i = 0; i < data.Length; i++)
		{
            if (data[i] > biggestElement)
            {
                biggestElement = data[i];
            }	 
		}

        return biggestElement;
    }

    private double GetSmallestDataElement(double[] data)
    {
        double smallestElement = double.MaxValue;

        for (int i = 0; i < data.Length; i++)
        {
            if (data[i] < smallestElement)
            {
                smallestElement = data[i];
            }
        }

        return smallestElement;
    }

    private double GetAverageValueOfDataElement(double[] data)
    {
        double averageValue;
        double sum = 0;

        for (int i = 0; i < data.Length; i++)
		{
		    sum = sum + data[i]; 	 
		}

        averageValue = sum / data.Length;

        return averageValue;
    }
}
