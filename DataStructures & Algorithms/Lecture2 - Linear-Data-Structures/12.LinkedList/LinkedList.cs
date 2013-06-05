using System;
using System.Collections.Generic;
using System.Linq;

class LinkedList<T>
{
    public ListItem<T> FirstElement { get; private set; }
    public ListItem<T> LastElement { get; private set; }
    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            if (index >= this.Count || index < 0)
                throw new ArgumentOutOfRangeException("Invalid index: " + index);
            ListItem<T> currentNode = this.FirstElement;
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.NextItem;
            }
            return currentNode.Value;
        }
    }

    public LinkedList()
    {
        this.Count = 0;
        this.FirstElement = null;
        this.LastElement = null;
    }

    public void Add(T item)
    {
        if (FirstElement == null)
        {
            this.FirstElement = new ListItem<T>(item);
            this.LastElement = this.FirstElement;
        }
        else
        {
            ListItem<T> newItem = new ListItem<T>(item, this.LastElement);
            this.LastElement = newItem;
        }
        this.Count++;
    }

    public object Remove(int index)
    {
        if (index >= this.Count ||index < 0)
        {
            throw new ArgumentOutOfRangeException("Invalid index: " + index);
        }

        //find the element at specified index
        int currentIndex = 0;
        ListItem<T> currentItem = this.FirstElement;
        ListItem<T> prevItem = null;
        while (currentIndex < index)
        {
            prevItem = currentItem;
            currentItem = currentItem.NextItem;
            currentIndex++;
        }

        //remove the element
        this.Count--;
        if (this.Count == 0)
        {
            this.FirstElement = null;
        }
        else if (prevItem == null)
        {
            this.FirstElement = currentItem.NextItem;
        }
        else
        {
            prevItem.NextItem = currentItem.NextItem;
        }

        //find last element
        ListItem<T> last = null;
        if (this.FirstElement != null)
        {
            last = this.FirstElement;
            while (last.NextItem != null)
            {
                last = last.NextItem;
            }
        }

        this.LastElement = last;

        return currentItem.Value;
    }

    public int Remove(T value)
    {
        int currentIndex = 0;
        ListItem<T> currentElement = this.FirstElement;
        ListItem<T> prevElement = null;
        while (currentElement != null)
        {
            if ((currentElement.Value != null && currentElement.Value.Equals(value)) ||
                (currentElement.Value == null) && (value == null))
            {
                break;
            }

            prevElement = currentElement;
            currentElement = currentElement.NextItem;
            currentIndex++;
        }

        if (currentElement != null)
        {
            //element is found in the list. Remove it.
            this.Count--;
            if (this.Count == 0)
            {
                this.FirstElement = null;
            }
            else if (prevElement == null)
            {
                this.FirstElement = currentElement.NextItem;
            }
            else
            {
                prevElement.NextItem = currentElement.NextItem;
            }

            //find last element
            ListItem<T> last = null;
            if (this.FirstElement != null)
            {
                last = this.FirstElement;
                while (last.NextItem != null)
                {
                    last = last.NextItem;
                }
            }

            this.LastElement = last;

            return currentIndex;
        }
        else
        {
            //element is not found in the list
            return -1;
        }
    }


}
