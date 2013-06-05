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
