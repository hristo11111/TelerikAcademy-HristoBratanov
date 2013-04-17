using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Globalization;

class ExtractDateConvertToCultr
{
    static void Main()
    {
        DateTime dateValue;
        List<string> dates = new List<string>();
        string text = "25.02.2011, 2011.05.06, 02.26.2013, ala bala nica";
        string pattern = @"\d{2}.\d{2}.\d{4}";
        MatchCollection res = Regex.Matches(text, pattern);
        foreach (Match item in res)
        {
            dates.Add(item.Value);
        }

        for (int i = 0; i < dates.Count; i++)
        {
            if (DateTime.TryParseExact(dates[i], "DD.MM.YYYY", new CultureInfo("en-CA"), DateTimeStyles.None, out dateValue))
            {
                Console.WriteLine(dates[i]);
            }

        }

    }

}
