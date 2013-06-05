using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace CalendarSystem
{
    /// <summary>
    /// Contains methods that process the commands entered in the console.
    /// </summary>
    public class EventsManagerFast : IEventsManager
    {
        /// <summary>
        /// Object from type <see cref="OrderedMultiDictionary"/>, with key - title
        /// and value <see cref="Event"/>
        /// </summary>
        private readonly OrderedMultiDictionary<string, Event> title;

        /// <summary>
        /// Object from type <see cref="OrderedMultiDictionary"/>, with key - date
        /// and value <see cref="Event"/>
        /// </summary>
        private readonly OrderedMultiDictionary<DateTime, Event> date;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventsManagerFast" /> class.
        /// The EventsManagerFast will have boolean variable 
        /// <paramref name="allowDuplicateValues"/> allowDuplicateValues,
        /// <paramref name="date"/> title and <paramref name="date"/> date.
        /// <paramref name="title"/> title and <paramref name="title"/> date.
        /// </summary>
        public EventsManagerFast()
        {
            bool allowDuplicateValues = true;
            this.date = new OrderedMultiDictionary<DateTime, Event>(allowDuplicateValues);
            this.title = new OrderedMultiDictionary<string, Event>(allowDuplicateValues);
        }

        /// <summary>
        /// Method for adding event in the calendar system
        /// </summary>
        /// <param name="ev">The event which is added to the calendar system.</param>
        public void AddEvent(Event ev)
        {
            string eventTitleLowerCase = ev.Title.ToLowerInvariant();
            this.title.Add(eventTitleLowerCase, ev);
            this.date.Add(ev.date, ev);
        }

        /// <summary>
        /// Method for deleting events by given title.
        /// </summary>
        /// <param name="title">The parameter which is indicates the title of the
        /// event which will be removed</param>
        /// <returns>The count of deleted events.</returns>
        public int DeleteEventsByTitle(string title)
        {
            string titleToDelete = title.ToLowerInvariant();
            var deletedItems = this.title[titleToDelete];
            int deletedCount = deletedItems.Count;

            foreach (var item in deletedItems)
            {
                this.date.Remove(item.date, item);
            }

            this.title.Remove(titleToDelete);

            return deletedCount;
        }

        /// <summary>
        /// Lists and orders the events by given date/time parameter.
        /// </summary>
        /// <param name="date">The parameter which is indicates the date of the
        /// event which will be listed</param>
        /// <param name="count">The number of the listed events</param>
        /// <returns>List of events which count is equal or less to the given count.
        /// The events in the list are ordered chronologically by date and time and 
        /// then by title and location(in ascending order).
        /// </returns>
        public IEnumerable<Event> ListEvents(DateTime date, int count)
        {
            return (from ev in this.date.RangeFrom(date,true).Values
                    where ev.date >= date
                    orderby ev.date, ev.Title, ev.Location
                    select ev)
                    .Take(count);
        }
    }
}