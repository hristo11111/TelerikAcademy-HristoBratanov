using System;
using System.Collections.Generic;
using System.Linq;

static class CalculateAverage
{
    public static float AverageAge(this IEnumerable<Animal> animals)
    {
        float sum = 0;
        foreach (var item in animals)
        {
            sum += item.Age;
        }

        return sum / animals.Count();
    }
}
