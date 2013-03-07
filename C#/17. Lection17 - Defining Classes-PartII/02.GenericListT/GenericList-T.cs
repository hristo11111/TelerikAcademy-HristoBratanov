using System;
using System.Text;

class GenericList<T> 
    where T :  IComparable<T>
{
    public const int capacity = 5;

    private T[] elements;
    private int count = 0;
    private int newCapacity = capacity;

    public GenericList(int capacity)
    {
        elements = new T[capacity];
    }

    public GenericList()
        : this(capacity)
    {
    }

    public void Add(T element)
    {
        if (count >= newCapacity)
        {
            DoubleCapacity();
        }
        this.elements[count] = element;
        count++;
    }

    public T this[int index]
    {
        get
        {
            if (count <= index || index < 0)
            {
                throw new IndexOutOfRangeException("index out of range");
            }

            T element = this.elements[index];
            return element;
        }

        set
        {
            if (count <= index || index < 0)
            {
                throw new IndexOutOfRangeException("index out of range");
            }

            T element = this.elements[index];
            element = value;
        }
    }

    public void RemoveAtIndex(int index)
    {
        int k = 0;
        if (count <= index)
        {
            throw new IndexOutOfRangeException("index out of range");
        }

        bool[] isRemoved = new bool[count];
        isRemoved[index] = true;
        count--;
        T[] newElements = new T[count];
        for (int i = 0; i < count+1; i++)
        {
            if (isRemoved[i] == false)
            {
                int j = i - k;
                newElements[j] = this.elements[i];
            }

            else
            {
                k = 1;
            }
        }

        this.elements = newElements;
    }

    public void InsertAtPosition(int index, T element)
    {
        int k = 0;
        if (count >= newCapacity)
        {
            DoubleCapacity();
        }

        if (count <= index)
        {
            throw new IndexOutOfRangeException("index out of range");
        }

        bool[] isInserted = new bool[count+1];
        isInserted[index] = true;
        count++;
        T[] newElements = new T[newCapacity];
        for (int i = 0; i < count; i++)
        {
            if (isInserted[i] == false)
            {
                
                newElements[i] = this.elements[i-k];
            }

            else
            {
                k = 1;
                newElements[i] = element;
            }
        }

        this.elements = newElements;
    }

    public void Clear()
    {
        for (int i = 0; i < count; i++)
        {
            elements[i] = default(T);
        }
    }

    public void FindElementByValue(T element)
    {
        int index = -1;
        for (int i = 0; i < count; i++)
        {
            if (this.elements[i].CompareTo(element) == 0)
            {
                index = i;    
            }
        }

        if (index != -1)
        {
            Console.WriteLine("index of {0} is {1}", element, index);    
        }

        else
        {
            Console.WriteLine("no such element");
        }
    }

    public void ToStringNew()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < count; i++)
        {
            sb.Append(this.elements[i]);
        }

        Console.WriteLine(sb);
    }

    private void DoubleCapacity()
    {
        newCapacity = newCapacity + newCapacity;
        T[] newElements = new T[newCapacity];
        for (int i = 0; i < count; i++)
        {
            newElements[i] = elements[i];
        }

        this.elements = newElements;
    }

    public T Min()
    {
        T min = this.elements[0];
        for (int i = 1; i < elements.Length; i++)
        {
            if ((elements[i].CompareTo(min) < 0))
            {
                min = elements[i];
            }
        }

        return min;
    }

    public T Max()
    {
        T max = this.elements[0];
        for (int i = 1; i < elements.Length; i++)
        {
            if ((elements[i].CompareTo(max) > 0))
            {
                max = elements[i];
            }
        }

        return max;
    }

}
