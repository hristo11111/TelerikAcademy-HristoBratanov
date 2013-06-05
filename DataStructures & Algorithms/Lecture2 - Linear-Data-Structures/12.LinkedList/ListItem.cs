using System;
using System.Collections.Generic;
using System.Linq;

class ListItem<T>
{
    private T value;
    private ListItem<T> nextItem;

    public ListItem<T> NextItem
    {
        get { return nextItem; }
        set { nextItem = value; }
    }

    public T Value
    {
        get { return value; }
        set { this.value = value; }
    }

    public ListItem(T value, ListItem<T> prevItem)
    {
        this.Value = value;
        prevItem.NextItem = this;
    }

    public ListItem(T value)
    {
        this.Value = value;
        this.NextItem = null;
    }
    
}
