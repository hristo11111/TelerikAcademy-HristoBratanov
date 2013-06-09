//Implement the ADT queue as dynamic linked list. Use generics (LinkedQueue<T>) 
//to allow storing different data types in the queue.

using System;
using System.Linq;

public class Queueue<T>
{
    private T[] queueArray;
    private int firstElementIndex;
    private int lastElementIndex;
    private bool isFirstElement;

    public Queueue(int currentCapacity = 4)
    {
        this.queueArray = new T[currentCapacity];
        this.isFirstElement = true;
    }

    public void Enqueue(T value)
    {
        IncreaseLastElementPossition();

        if (this.lastElementIndex == this.firstElementIndex)
        {
            ResizeQueue();
        }

        if (isFirstElement)
        {
            this.firstElementIndex = this.lastElementIndex;
            this.isFirstElement = false;
        }

        this.queueArray[this.lastElementIndex] = value;
    }

    public T Dequeue()
    {
        var item = this.queueArray[this.firstElementIndex];

        this.IncreaseFirstElementPossition();

        return item;
    }

    public T Peek()
    {
        return this.queueArray[firstElementIndex];
    }

    private void ResizeQueue()
    {
        var newQueue = new T[this.queueArray.Length * 2];
        this.DecreaseLastElementPossition();

        for (int newPos = 0; this.firstElementIndex != this.lastElementIndex; newPos++)
        {
            newQueue[newPos] = this.queueArray[this.firstElementIndex];
            this.IncreaseFirstElementPossition();
        }
        newQueue[this.queueArray.Length - 1] = this.queueArray[this.firstElementIndex];

        this.firstElementIndex = 0;
        this.lastElementIndex = this.queueArray.Length;
        this.queueArray = newQueue;
    }

    private void IncreaseFirstElementPossition()
    {
        if (this.firstElementIndex == this.queueArray.Length - 1)
        {
            this.firstElementIndex = 0;
        }
        else
        {
            this.firstElementIndex++;
        }
    }

    private void IncreaseLastElementPossition()
    {
        if (this.lastElementIndex == this.queueArray.Length - 1)
        {
            this.lastElementIndex = 0;
        }
        else
        {
            this.lastElementIndex++;
        }
    }

    private void DecreaseLastElementPossition()
    {
        if (this.lastElementIndex == 0)
        {
            this.lastElementIndex = this.queueArray.Length - 1;
        }
        else
        {
            this.lastElementIndex--;
        }
    }
}
