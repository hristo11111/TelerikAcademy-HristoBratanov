//Define a class InvalidRangeException<T> that holds information about an error condition related to invalid range. 
//It should hold error message and a range definition [start … end]. 
//Write a sample application that demonstrates the InvalidRangeException<int> and InvalidRangeException<DateTime> 
//by entering numbers in the range [1..100] and dates in the range [1.1.1980 … 31.12.2013].



using System;

public class Test
{
    static void ParseDateOrInt(object obj)
    {
        DateTime startDate = new DateTime(1980, 1, 1);
        DateTime endDate = new DateTime(2013, 12, 31);
        if (obj is DateTime)
        {
            if ((DateTime)obj < startDate || (DateTime)obj > endDate)
            {
                throw new InvalidRangeException<DateTime>((DateTime)obj, startDate, endDate, "not in the right range");
            }
            else
            {
                Console.WriteLine(obj); ;
            }
        }
        int startInt = 1;
        int endInt = 100;
        if (obj is int)
        {
            if ((int)obj < startInt || (int)obj > endInt)
            {
                throw new InvalidRangeException<int>((int)obj, startInt, endInt, "not in the right range");
            }
            else
            {
                Console.WriteLine(obj); ;
            }
        }
        else
        {
            throw new InvalidCastException();
        }
    }

    static void Main()
    {
        ParseDateOrInt(new DateTime(1721,2,5));
        ParseDateOrInt(21);
        ParseDateOrInt(124);
        ParseDateOrInt("dasd");
    }
}
