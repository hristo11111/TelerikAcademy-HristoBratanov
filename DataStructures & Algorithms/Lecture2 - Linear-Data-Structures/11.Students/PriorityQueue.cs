﻿using System;
using Wintellect.PowerCollections;

//problem from last year homework. Please do not evaluate.

class PriorityQueue<T> where T : IComparable<T>
{
    private OrderedBag<T> bag;

    public int Count
    {
        get
        {
            return bag.Count;
        }
        private set
        {
        }
    }

    public PriorityQueue()
    {
        bag = new OrderedBag<T>();
    }

    public void Enqueue(T element)
    {
        bag.Add(element);
    }

    public T Dequeue()
    {
        var element = bag.GetFirst();
        bag.RemoveFirst();
        return element;
    }
}
