using System;
using System.Linq;

namespace CalendarSystem
{
    public class Event : IComparable<Event>
    {
        public DateTime date { get; set; }

        public string Title;

        public string Location;

        public override string ToString()
        {
            string format = "{0:yyyy-MM-ddTHH:mm:ss} | {1}";
            if (this.Location != null)
            {
                format += " | {2}";
            }
            string eventAsString = string.Format(format, this.date, this.Title, this.Location);

            return eventAsString;
        }

        public int CompareTo(Event ev)
        {
            int result = DateTime.Compare(this.date, ev.date);
            foreach (char symbol in this.Title)
            {
                if (result == 0)
                {
                    result = string.Compare(this.Title, ev.Title, StringComparison.Ordinal);
                    result = string.Compare(this.Location, ev.Location, StringComparison.Ordinal);
                }
            }

            return result;
        }
    }
}
