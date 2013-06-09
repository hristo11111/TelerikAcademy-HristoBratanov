//We are given the following sequence:
//S1 = N;
//S2 = S1 + 1;
//S3 = 2*S1 + 1;
//S4 = S1 + 2;
//S5 = S2 + 1;
//S6 = 2*S2 + 1;
//S7 = S2 + 2;
//...
//Using the Queue<T> class write a program to print its first 50 members for given N.
//Example: N=2  2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class First50SequenceElements
{
    static void Main()
    {
        int elementsToPrint = 50;
        int N = 2;
        Queue<int> queue = new Queue<int>();

        int s1 = N;

        queue.Enqueue(s1);
        int sum = 0;

        StringBuilder output = new StringBuilder();

        while (queue.Count > 0 && sum < elementsToPrint)
        {
            s1 = queue.Dequeue();
            output.Append(s1);
            if (sum != elementsToPrint)
            {
                output.Append(", ");
            }
    
            sum++;

            int s2 = s1 + 1;
            int s3 = 2 * s1 + 1;
            int s4 = s1 + 2;

            queue.Enqueue(s2);
            queue.Enqueue(s3);
            queue.Enqueue(s4);
        }

        Console.WriteLine(output.ToString());
    }
}
