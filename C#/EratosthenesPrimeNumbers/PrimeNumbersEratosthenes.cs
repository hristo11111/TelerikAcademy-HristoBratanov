using System;
using System.Collections.Generic;
using System.Linq;

class PrimeNumbersEratosthenes
{
    static void Main()
    {
        // create array with 10 000 000 elements
        List<bool> isPrime = new List<bool>();
        for (int i = 1; i < 10000000; i++)
        {
            isPrime.Add(true);
        }

        // the element with index = 0 and 1 are not prime numbers, 
        // because they correspond to numbers 0 and 1
        isPrime[0] = false;
        isPrime[1] = false;
        
        // if j(index of the array) is equal to each multiple of i, j is not Prime (j = false)
        for (int i = 2; i < Math.Sqrt(isPrime.Count); i++) 
        {
            for (int j = i*2; j < isPrime.Count; j = j+i)
            {
                isPrime[j] = false;
            }
        }
        // print all primes
        for (int i = 0; i < isPrime.Count; i++)
        {
            if (isPrime[i] == true)
            {
                Console.Write(i + ", ");    
            }
        }
    }
}
