using System;
using System.Linq;

static class LINQQuieries
{
    public static void DivisableBy3and7(this int[] numbers)
    {
        var divisableQuery =
            from num in numbers
            where num % 3 == 0 && num % 7 == 0
            select num;

        foreach (var item in divisableQuery)
        {
            Console.WriteLine(item);
        }
    }
}
