using System;

class CalculateWorkdays
{
    
    static void Main()
    {
        DateTime given = new DateTime(2013, 03, 30);
        int length = 365;
        DateTime next = DateTime.Now.Date;
        int sum = 0;
        for (int i = 0; i < length; i++)
        {
            next = next.AddDays(1);
            if (DateTime.Compare(next, given) == 0)
            {
                break;
            }

            int isWorkDay = IsNextWorkDaySundaySaturday(next) - IsNextDayPublicHoliday(next);
            if (isWorkDay == 1)
            {
                sum++;
            }
            

        }
        Console.WriteLine("working days between {0} and {1} are = {2}", next.Date, given.Date, sum);

    }

    static int IsNextWorkDaySundaySaturday(DateTime next)
    {
        int sumWorkDays = 0;
        DayOfWeek today = next.DayOfWeek;
        switch (today)
        {
            case DayOfWeek.Friday: sumWorkDays = 1;
                break;
            case DayOfWeek.Monday: sumWorkDays = 1;
                break;
            case DayOfWeek.Saturday: sumWorkDays = 0;
                break;
            case DayOfWeek.Sunday: sumWorkDays = 0;
                break;
            case DayOfWeek.Thursday: sumWorkDays = 1;
                break;
            case DayOfWeek.Tuesday: sumWorkDays = 1;
                break;
            case DayOfWeek.Wednesday: sumWorkDays = 1;
                break;
            default:
                break;
        }
        return sumWorkDays;
    }

    static int IsNextDayPublicHoliday(DateTime next)
    {
        int sum = 0;
        DateTime[] holidays = {
                                  new DateTime(2013, 01, 01),
                                  new DateTime(2013, 05, 03),
                                  new DateTime(2013, 05, 01),
                                  new DateTime(2013, 05, 06),
                                  new DateTime(2013, 05, 24),
                                  new DateTime(2013, 09, 06),
                                  new DateTime(2013, 09, 22),
                                  new DateTime(2013, 12, 24),
                                  new DateTime(2013, 12, 25),
                                  new DateTime(2013, 12, 26),
                              };
        for (int i = 0; i < holidays.Length; i++)
        {
            if (DateTime.Compare(next.Date, holidays[i].Date) == 0)
            {
                sum++;
            }    
        }
        return sum;
    }
}
