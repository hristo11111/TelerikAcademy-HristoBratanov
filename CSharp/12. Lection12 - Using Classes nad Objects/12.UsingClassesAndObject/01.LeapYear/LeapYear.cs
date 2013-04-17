using System;

class LeapYear
{
    static void Main()
    {
        Console.Write("enter a year: ");
        int year = Int16.Parse(Console.ReadLine());
        bool isLeap = DateTime.IsLeapYear(year);
        Console.WriteLine("year " + year + " is leap : {0}", isLeap);
    }
}
