using System;
using System.Linq;

class PriorityQueue<T> where T : IComparable
{
    BinaryHeap<T> heap;

    public PriorityQueue()
        : this(4)
    {

    }

    public PriorityQueue(int size)
    {
        heap = new BinaryHeap<T>(size);
    }

    public void Enqueue(T value)
    {
        heap.Add(value);
    }

    public void Dequeue()
    {
        heap.Pop();
    }

    public T Peek
    {
        get
        {
            return heap.Peek;
        }
    }

    public int Count
    {
        get
        {
            return heap.Count;
        }
    }
}
