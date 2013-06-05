using System;
using System.Collections.Generic;
using System.Linq;

namespace CalendarSystem
{
    public class EventManager : IEventsManager
    {
        private readonly List<Event> eventsList = new List<Event>();

        public void AddEvent(Event ev)
        {
            this.eventsList.Add(ev);
        }

        public int DeleteEventsByTitle(string title)
        {
            return this.eventsList.RemoveAll(
                ev => ev.Title.ToLowerInvariant() == title.ToLowerInvariant());
        }

        public IEnumerable<Event> ListEvents(DateTime date, int count)
        {
            return (from ev in this.eventsList
                    where ev.date >= date
                    orderby ev.date, ev.Title, ev.Location
                    select ev)
                    .Take(count);
        }
    }
}
