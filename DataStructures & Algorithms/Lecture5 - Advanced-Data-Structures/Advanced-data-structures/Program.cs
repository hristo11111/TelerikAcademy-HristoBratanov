using System;
using System.Linq;

class Program
{
    static void Main()
    {
        PriorityQueue<int> priorityQueue = new PriorityQueue<int>();

        priorityQueue.Enqueue(1);
        priorityQueue.Enqueue(2);
        priorityQueue.Enqueue(3);
        priorityQueue.Enqueue(4);
        priorityQueue.Enqueue(10);

        Console.WriteLine("Peek at biggest element: {0} ", priorityQueue.Peek);

        priorityQueue.Dequeue();

        Console.WriteLine("Peek after dequeue: {0}", priorityQueue.Peek);

        priorityQueue.Enqueue(9);
        Console.WriteLine("Biggest element after enqueue: {0} ", priorityQueue.Peek);
    }
}
