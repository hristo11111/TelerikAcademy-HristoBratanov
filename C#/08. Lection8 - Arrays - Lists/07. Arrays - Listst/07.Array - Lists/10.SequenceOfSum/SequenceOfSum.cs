using System;
using System.Collections.Generic;
using System.Linq;

class SequenceOfSum
{
    static void Main()
    {
        List<int> numbers = new List<int>() {4,3,1,4,2,5,8};
        Console.Write("S = ");
        int S = Int32.Parse(Console.ReadLine());
        int sum = 0;
        int count = 0;
        int index = -1;
        for (int i = 0; i < numbers.Count; i++)
        {
            sum = sum + numbers[i];
            count++;
            if (sum == S)
            {
                index = i;
                break;
            }
            else
            {
                if (sum > S)
                {
                    count = 0;
                    sum = 0;
                }
            }
        }
        if (index != -1)
        {
            Console.Write("{");
            for (int i = index - count + 1; i <= index; i++)
            {
                Console.Write(numbers[i]);
                if (i != index)
                {
                    Console.Write(",");
                }
            }
            Console.WriteLine("}");    
        }
        else
        {
            Console.WriteLine("no such sum");
        }
    }
}
