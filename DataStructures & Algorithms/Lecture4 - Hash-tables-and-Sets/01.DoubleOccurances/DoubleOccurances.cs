using System;
using System.Collections.Generic;

class DoubleOccurances
{
    static void Main()
    {
        double[] array = { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
        Dictionary<double, int> occurances = new Dictionary<double, int>();

        foreach (double number in array)
        {
            int count = 1;
            if (occurances.ContainsKey(number))
            {
                occurances[number]++;
            }
            else
            {
                occurances[number] = count;
            }
        }

        foreach (var pair in occurances)
        {
            Console.WriteLine(pair.Key + " -> " + pair.Value);
        }
    }
}
