using System;
using System.Globalization;

class GSMCallHistoryTest
{
    static public void Print()
    {
        
        GSM phone = new GSM("galaxy", "samsung");

        string date1 = "07/07/2011 10:48:12";
        string date2 = "17/03/2012 08:43:08";
        string date3 = "08/06/2012 02:52:24";
        Call call1 = new Call(ParseDate(date1).ToString("dd/MM/yyyy"), ParseDate(date1).ToString("hh:mm:ss"), 0898456456, 450);
        Call call2 = new Call(ParseDate(date2).ToString("dd/MM/yyyy"), ParseDate(date2).ToString("hh:mm:ss"), 0898324456, 350);
        Call call3 = new Call(ParseDate(date3).ToString("dd/MM/yyyy"), ParseDate(date3).ToString("hh:mm:ss"), 0898324879, 620);

        Console.WriteLine(call1);
        Console.WriteLine(new string('-', 20));
        Console.WriteLine(call2);
        Console.WriteLine(new string('-', 20));
        Console.WriteLine(call3);

        phone.AddCall(call1);
        phone.AddCall(call2);
        phone.AddCall(call3);

        decimal sum = phone.CalculateTotalPriceOfCalls(phone.CallHistory);
        Console.WriteLine("price of all calls in History is {0}", sum);

        ulong maxDuration = 0;
        int maxIndex = -1;
        for (int i = 0; i < phone.CallHistory.Count; i++)
        {
            if (maxDuration < phone.CallHistory[i].Duration)
            {
                maxDuration = phone.CallHistory[i].Duration;
                maxIndex = i;
            }
        }

        phone.DeleteCall(phone.CallHistory[maxIndex]);

        sum = phone.CalculateTotalPriceOfCalls(phone.CallHistory);
        Console.WriteLine("price of all calls in History is {0}", sum);

        phone.ClearCallHistory();
        Console.WriteLine("there are {0} calls in call history", phone.CallHistory.Count);
        //Console.WriteLine(call1.Date + " " + call1.Time + " " + call1.DialedNumber + " " + call1.Duration);

    }

    static DateTime ParseDate(string date)
    {
        DateTime dateParse = DateTime.ParseExact(date, "dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture);
        return dateParse;
    }

    


}
