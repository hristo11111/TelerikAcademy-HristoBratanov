using System;
using System.Collections.Generic;
using System.Linq;

class Majorant
{
    static void Main()
    {
        List<int> sequence = new List<int>() { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
        sequence.Sort();

        int sum = 1;
        int maxSum = sequence.Count/2 + 1;
        int currentElement = sequence[0];
        bool hasMajorant = false;

        for (int i = 1; i < sequence.Count; i++)
        {
            if (currentElement == sequence[i])
            {
                sum++;

                if (sum >= maxSum)
                {
                    hasMajorant = true;
                    int maxElement = currentElement;
                    Console.WriteLine("The majorant is {0}", maxElement);
                    break;
                }
            }
            else
            {
                sum = 1;

                //if new number appears and index is more than (count/2 + 1),
                //there is no possibility of majorant occurance
                if (i > maxSum)
                {
                    break;
                }
            }
            currentElement = sequence[i];
        }

        if (hasMajorant == false)
        {
            Console.WriteLine("The sequence does not have majorant");
        }
    }
}
