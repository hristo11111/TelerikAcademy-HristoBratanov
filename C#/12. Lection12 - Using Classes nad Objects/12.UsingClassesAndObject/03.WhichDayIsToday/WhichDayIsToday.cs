using System;

class WhichDayIsToday
{
    static void Main()
    {
        DateTime now;
        now = DateTime.Now;
        DayOfWeek today = now.DayOfWeek;
        Console.WriteLine(today);
    }
}
