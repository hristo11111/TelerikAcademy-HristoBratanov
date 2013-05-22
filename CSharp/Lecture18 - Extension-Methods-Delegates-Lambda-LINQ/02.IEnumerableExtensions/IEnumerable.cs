using System;
using System.Collections.Generic;
using System.Linq;

public static class IEnumerableExtensions
{
    public static T Sum<T>(this IEnumerable<T> elements)
    {
        if (elements.Count() == 0)
        {
            throw new ArgumentNullException("collection is empty");
        }
        T sum = default(T);
        foreach (T item in elements)
        {
            sum = sum + (dynamic)item;
        }

        return sum;
    }

    public static T Product<T>(this IEnumerable<T> elements)
    {
        if (elements.Count() == 0)
        {
            throw new ArgumentNullException("collection is empty");
        }
        dynamic product = 1;
        foreach (T item in elements)
        {
            product = product * item;
        }

        return product;
    }

    public static T Min<T>(this IEnumerable<T> elements) where T : IComparable
    {
        if (elements.Count() == 0)
        {
            throw new ArgumentNullException("collection is empty");
        }
        T min = elements.ElementAt(0);
        foreach (T item in elements)
        {
            if (item.CompareTo(min) == -1)
            {
                min = item;
            }
        }

        return min;
    }
    public static T Max<T>(this IEnumerable<T> elements) where T : IComparable
    {
        if (elements.Count() == 0)
        {
            throw new ArgumentNullException("collection is empty");
        }
        T max = elements.ElementAt(0);
        foreach (T item in elements)
        {
            if (item.CompareTo(max) == 1)
            {
                max = item;
            }
        }

        return max;
    }

    public static T Average<T>(this IEnumerable<T> elements)
    {
        dynamic sum = 0;
        foreach (T item in elements)
        {
            sum = sum + item;
        }

        return sum / elements.Count();
    }


}
