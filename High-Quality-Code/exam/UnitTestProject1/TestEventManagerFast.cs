using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalendarSystem;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;

namespace TestCalendarSystem
{
    [TestClass]
    public class TestEventManagerFast
    {
        [TestMethod]
        public void TestAddEvent_When1EventAdded()
        {
            var date = DateTime.ParseExact(
                "2012-03-26T09:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            string title = "C# exam";
            var ev = new Event
                {
                    date = date,
                    Title = title,
                    Location = null,
                };

            EventsManagerFast manager = new EventsManagerFast();
            manager.AddEvent(ev);
            var result = manager.ListEvents(date, 1);
            int actual = result.Count();

            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void TestAddEvent_When3EventsAdded()
        {
            EventsManagerFast manager = new EventsManagerFast();
            //first event
            string titleCSharp = "C# exam";
            var dateCSharp = DateTime.ParseExact(
                "2012-03-26T09:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            string locationCSharp = "Home";
            
            var evCSharp1 = new Event
            {
                date = dateCSharp,
                Title = titleCSharp,
                Location = locationCSharp,
            };

            manager.AddEvent(evCSharp1);

            //second event
            string title = "C++ exam";
            var dateCPlus = DateTime.ParseExact(
                "2011-02-26T09:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            string locationCPlus = "Academy";

            var evCPlus = new Event
            {
                date = dateCPlus,
                Title = title,
                Location = locationCPlus,
            };

            //third event
            string titleCSharp2 = "C# exam";
            var dateCSharp2 = DateTime.ParseExact(
                "2012-03-26T09:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            string locationCSharp2 = "Home";

            var evCSharp2 = new Event
            {
                date = dateCSharp2,
                Title = titleCSharp2,
                Location = locationCSharp2,
            };

            manager.AddEvent(evCSharp2);


            var result = manager.ListEvents(dateCSharp, 2);
            int actual = result.Count();

            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        public void TestDeleteEvent()
        {
            var date = DateTime.ParseExact(
                "2012-03-26T09:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            string title = "C# exam";
            var ev = new Event
            {
                date = date,
                Title = title,
                Location = null,
            };

            EventsManagerFast manager = new EventsManagerFast();
            manager.AddEvent(ev);
            string titleToDelete = "C# exam";;
            int actual = manager.DeleteEventsByTitle(titleToDelete);
            int expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDeleteEvents_When3EventsInList()
        {
            EventsManagerFast manager = new EventsManagerFast();
            //first event
            string titleCSharp = "C# exam";
            var dateCSharp = DateTime.ParseExact(
                "2012-03-26T09:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            string locationCSharp = "Home";

            var evCSharp1 = new Event
            {
                date = dateCSharp,
                Title = titleCSharp,
                Location = locationCSharp,
            };

            manager.AddEvent(evCSharp1);

            //second event
            string title = "C++ exam";
            var dateCPlus = DateTime.ParseExact(
                "2011-02-26T09:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            string locationCPlus = "Academy";

            var evCPlus = new Event
            {
                date = dateCPlus,
                Title = title,
                Location = locationCPlus,
            };

            //third event
            string titleCSharp2 = "C# exam";
            var dateCSharp2 = DateTime.ParseExact(
                "2012-03-26T09:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            string locationCSharp2 = "Home";

            var evCSharp2 = new Event
            {
                date = dateCSharp2,
                Title = titleCSharp2,
                Location = locationCSharp2,
            };

            manager.AddEvent(evCSharp2);

            string titleToDelete = "C# exam"; ;
            int actual = manager.DeleteEventsByTitle(titleToDelete);
            int expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDeleteEvents_WhenNoMatches()
        {
            EventsManagerFast manager = new EventsManagerFast();
            //first event
            string titleCSharp = "C# exam";
            var dateCSharp = DateTime.ParseExact(
                "2012-03-26T09:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            string locationCSharp = "Home";

            var evCSharp1 = new Event
            {
                date = dateCSharp,
                Title = titleCSharp,
                Location = locationCSharp,
            };

            manager.AddEvent(evCSharp1);

            //second event
            string title = "C++ exam";
            var dateCPlus = DateTime.ParseExact(
                "2011-02-26T09:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            string locationCPlus = "Academy";

            var evCPlus = new Event
            {
                date = dateCPlus,
                Title = title,
                Location = locationCPlus,
            };

            //third event
            string titleCSharp2 = "C# exam";
            var dateCSharp2 = DateTime.ParseExact(
                "2012-03-26T09:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            string locationCSharp2 = "Home";

            var evCSharp2 = new Event
            {
                date = dateCSharp2,
                Title = titleCSharp2,
                Location = locationCSharp2,
            };

            manager.AddEvent(evCSharp2);

            string titleToDelete = "exam"; ;
            int actual = manager.DeleteEventsByTitle(titleToDelete);
            int expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestListEvents()
        {
            EventsManagerFast manager = new EventsManagerFast();
            //first event
            string titleCSharp = "C# exam";
            var dateCSharp = DateTime.ParseExact(
                "2012-03-26T09:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            string locationCSharp = "Home";

            var evCSharp1 = new Event
            {
                date = dateCSharp,
                Title = titleCSharp,
                Location = locationCSharp,
            };

            manager.AddEvent(evCSharp1);

            //second event
            string title = "C++ exam";
            var dateCPlus = DateTime.ParseExact(
                "2011-02-26T09:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            string locationCPlus = "Academy";

            var evCPlus = new Event
            {
                date = dateCPlus,
                Title = title,
                Location = locationCPlus,
            };

            //third event
            string titleCSharp2 = "C# exam";
            var dateCSharp2 = DateTime.ParseExact(
                "2012-03-26T09:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            string locationCSharp2 = "Home";

            var evCSharp2 = new Event
            {
                date = dateCSharp2,
                Title = titleCSharp2,
                Location = locationCSharp2,
            };

            manager.AddEvent(evCSharp2);

            var dateToList = dateCSharp;
            IEnumerable<Event> actualList = manager.ListEvents(dateToList, 2).ToList();
            List<Event> expectedList = new List<Event>();
            expectedList.Add(evCSharp1);
            expectedList.Add(evCSharp2);

            bool areEqual = CompareLists(expectedList, (List<Event>)actualList);

            Assert.IsTrue(areEqual);
        }

        private bool CompareLists(List<Event> expected, List<Event> actual)
        {
            for (int i = 0; i < expected.Count; i++)
            {
                if (expected[i] != actual[i])
                {
                    return false;  
                }
            }

            return true;
        }
    }


}

