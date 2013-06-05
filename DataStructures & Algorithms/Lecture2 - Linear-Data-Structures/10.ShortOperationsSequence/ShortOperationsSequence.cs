using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Maybe there is mistake in the example.
//My output is 5 -> 6 -> 8 -> 16 not 5 -> 7 -> 8 -> 16
class ShortOperationsSequence
{
    static void Main()
    {
        int N = 5;
        int M = 16;
        
        Queue<int> queue = new Queue<int>();

        int s1 = N;

        queue.Enqueue(s1);
        int sum = 0;

        StringBuilder output = new StringBuilder();

        while (queue.Count > 0)
        {
            s1 = queue.Dequeue();
            output.Append(s1);
            if (s1 != M)
            {
                output.Append(" -> ");
            }
            else
            {
                break;
            }

            int s2 = s1 + 1;
            int s3 = s2 + 2;
            int s4 = s3 * 2;

            queue.Enqueue(s2);
            queue.Enqueue(s3);
            queue.Enqueue(s4);
        }

        Console.WriteLine(output.ToString());
    }
}
