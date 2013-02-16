using System;
using System.Collections.Generic;
using System.Linq;

class CompareCharArrays
{
    static void Main()
    {
        List<char> firstArray = new List<char>() { 'a', 'g', 'u', 'm', 'f', 'a' };
        List<char> secondArray = new List<char>() { 'a', 't', 'j', 'm', 'i', 'a' };
        for (int i = 0; i < firstArray.Count; i++)
        {
            if (firstArray[i] > secondArray[i])
            {
                Console.WriteLine("element {0} in firstArray = '{1}' > element {2} in secondArray = '{3}'", i, firstArray[i], i, secondArray[i]);
            }
            else if (firstArray[i] < secondArray[i])
            {
                Console.WriteLine("element {0} in firstArray = '{1}' < element {2} in secondArray = '{3}'", i, firstArray[i], i, secondArray[i]);
            }
            else
            {
                Console.WriteLine("element {0} in firstArray = '{1}' = element {2} in secondArray = '{3}'", i, firstArray[i], i, secondArray[i]);
            }
        }
    }
}
