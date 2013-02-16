using System;
using System.Collections.Generic;
using System.Numerics;

class CalculateFactorial
{
    static void Main()
    {
        Console.Write("enter a number (1-100) = ");
        int givenNumber = Int32.Parse(Console.ReadLine());
        Console.WriteLine(FindFactorial(givenNumber)); 
    }
    static BigInteger FindFactorial(int number)
    {
        List<int> arr = new List<int>();
        BigInteger sum = 1;
        for (int i = 1; i <= number; i++)
        {
            arr.Add(i);
        }
        for (int i = 0; i < arr.Count; i++)
		{
            sum = sum * arr[i];
	    }
        return sum;
         
    }
}
