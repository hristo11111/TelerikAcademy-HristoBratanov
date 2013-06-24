using System;
using System.Collections.Generic;

class Program
{
    static int result = int.MinValue;
    static int maxTone;
    const int minTone = 0;

    static HashSet<int> possible = new HashSet<int>();

    static void Main()
    {
        int tonesNumber = int.Parse(Console.ReadLine());

        List<int> tones = new List<int>();

        string[] tonesLine = Console.ReadLine().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < tonesLine.Length; i++)
        {
            int tone = int.Parse(tonesLine[i]);
            tones.Add(tone);
        }

        int initialTone = int.Parse(Console.ReadLine());
        maxTone = int.Parse(Console.ReadLine());

        CalculateTones(tones, initialTone);

        if (result == -1)
	    {
		    Console.WriteLine(-1); 
	    }
        else
	    {
            for (int i = maxTone; i >= 0; i--)
            {
                if (possible.Contains(i))
                {
                    Console.WriteLine(i);
                    break;
                }
            }
            
	    }
    }

private static void CalculateTones(List<int> tones,int initialTone)
{
    int sumPlus = initialTone + tones[0];
    int sumMinus = initialTone - tones[0];

    if (IsInScope(sumPlus))
	{
		 possible.Add(sumPlus);
	}

    if (IsInScope(sumMinus))
	{
		 possible.Add(sumMinus);
	}

    HashSet<int> newSums = new HashSet<int>();

    for (int i = 1; i < tones.Count; i++)
	{
	    foreach (var prevTone in possible)
	    {
		    int tonePlus = prevTone + tones[i];
            int toneMinus = prevTone - tones[i];

            if (IsInScope(tonePlus))
	        {
		        newSums.Add(tonePlus);
	        }

            if (IsInScope(toneMinus))
	        {
                newSums.Add(toneMinus);
	        }
	    }

        if (newSums.Count == 0)
	    {
		    result = -1;
            return;
	    }

        possible.Clear();

        foreach (var item in newSums)
	    {
		    possible.Add(item); 
	    }

        newSums.Clear();
	}

}

private static bool IsInScope(int tone)
{
    if (tone >= 0 && tone <= maxTone)
	{
		return true;
	}

    return false;
}

}
