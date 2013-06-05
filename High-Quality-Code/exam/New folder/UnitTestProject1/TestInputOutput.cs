//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.IO;
//using CalendarSystem;

//namespace TestCalendarSystem
//{
//    [TestClass]
//    public class TestInputOutput
//    {
//        [TestMethod]
//        public void TestInput01()
//        {
//            var output = new StringWriter();
//            var input = new StringReader(
//                "AddEvent 2012-01-21T20:00:00 | party Viki | home" + "\r\n" +
//                "AddEvent 2012-03-26T09:00:00 | C# exam\r\n" +
//                "AddEvent 2012-03-26T09:00:00 | C# exam\r\n" +
//                "AddEvent 2012-03-26T08:00:00 | C# exam\r\n" +
//                "AddEvent 2012-03-07T22:30:00 | party | Vitosha\r\n" +
//                "ListEvents 2012-03-07T08:00:00 | 3\r\n" +
//                "DeleteEvents c# exam\r\n" +
//                "DeleteEvents My granny's bushes\r\n" +
//                "ListEvents 2013-11-27T08:30:25 | 25\r\n" +
//                "AddEvent 2012-03-07T22:30:00 | party | Club XXX\r\n" +
//                "ListEvents 2012-01-07T20:00:00 | 10\r\n" +
//                "AddEvent 2012-03-07T22:30:00 | Party | Club XXX\r\n" +
//                "ListEvents 2012-03-07T22:30:00 | 3\r\n" +
//                "End\r\n");

//            string expected = "Event added\r\n" +
//                "Event added\r\n" +
//                "Event added\r\n" +
//                "Event added\r\n" +
//                "Event added\r\n" +
//                "2012-03-07T22:30:00 | party | Vitosha\r\n" +
//                "2012-03-26T08:00:00 | C# exam\r\n" +
//                "2012-03-26T09:00:00 | C# exam\r\n" +
//                "3 events deleted\r\n" +
//                "No events found\r\n" +
//                "No events found\r\n" +
//                "Event added\r\n" +
//                "2012-01-21T20:00:00 | party Viki | home\r\n" +
//                "2012-03-07T22:30:00 | party | Club XXX\r\n" +
//                "2012-03-07T22:30:00 | party | Vitosha\r\n" +
//                "Event added\r\n" +
//                "2012-03-07T22:30:00 | party | Club XXX\r\n" +
//                "2012-03-07T22:30:00 | party | Vitosha\r\n" +
//                "2012-03-07T22:30:00 | Party | Club XXX\r\n";

//            using (output)
//            {
//                using (input)
//                {
//                    Console.SetIn(input);
//                    Console.SetOut(output);

//                    CalendarSystem.CalendarExecutor.Main();
//                    string actual = output.ToString();

//                    Assert.AreEqual(expected, actual);
//                }
//            }
//        }

//        [TestMethod]
//        public void TestInput02()
//        {
//            var output = new StringWriter();
//            var input = new StringReader(
//                "AddEvent 2012-01-21T20:00:00 | party Viki | home" + "\r\n" +
//                "AddEvent 2012-03-26T09:00:00 | C# exam\r\n" +
//                "AddEvent 2012-03-26T09:00:00 | C# exam\r\n" +
//                "AddEvent 2012-03-26T08:00:00 | C# exam\r\n" +
//                "AddEvent 2012-03-07T22:30:00 | party | Vitosha\r\n" +
//                "ListEvents 2012-03-07T08:00:00 | 3\r\n" +
//                "DeleteEvents c# exam\r\n" +
//                "DeleteEvents My granny's bushes\r\n" +
//                "ListEvents 2013-11-27T08:30:25 | 25\r\n" +
//                "AddEvent 2012-03-07T22:30:00 | party | Club XXX\r\n" +
//                "ListEvents 2012-01-07T20:00:00 | 10\r\n" +
//                "AddEvent 2012-03-07T22:30:00 | Party | Club XXX\r\n" +
//                "ListEvents 2012-03-07T22:30:00 | 3\r\n" +
//                "End\r\n");

//            string expected = "Event added\r\n" +
//                "Event added\r\n" +
//                "Event added\r\n" +
//                "Event added\r\n" +
//                "Event added\r\n" +
//                "2012-03-07T22:30:00 | party | Vitosha\r\n" +
//                "2012-03-26T08:00:00 | C# exam\r\n" +
//                "2012-03-26T09:00:00 | C# exam\r\n" +
//                "3 events deleted\r\n" +
//                "No events found\r\n" +
//                "No events found\r\n" +
//                "Event added\r\n" +
//                "2012-01-21T20:00:00 | party Viki | home\r\n" +
//                "2012-03-07T22:30:00 | party | Club XXX\r\n" +
//                "2012-03-07T22:30:00 | party | Vitosha\r\n" +
//                "Event added\r\n" +
//                "2012-03-07T22:30:00 | party | Club XXX\r\n" +
//                "2012-03-07T22:30:00 | party | Vitosha\r\n" +
//                "2012-03-07T22:30:00 | Party | Club XXX\r\n";

//            using (output)
//            {
//                using (input)
//                {
//                    Console.SetIn(input);
//                    Console.SetOut(output);

//                    CalendarSystem.CalendarExecutor.Main();
//                    string actual = output.ToString();

//                    Assert.AreEqual(expected, actual);
//                }
//            }
//        }
//    }
//}

