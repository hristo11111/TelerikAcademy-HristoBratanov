using System;
using System.Globalization;

class DateTimeAfterInBulgarian
{
    static void Main(string[] args)
    {
        string dateNow = "29.01.2013 11:48:30";
        DateTime now;
        now = DateTime.ParseExact(dateNow, "dd.MM.yyyy hh:mm:ss", CultureInfo.InstalledUICulture);
        double hours = (6.5);
        now = now.AddHours(hours);
        string day = now.ToString("dddd", new CultureInfo("bg-BG"));
        Console.WriteLine(day);
    }
}
