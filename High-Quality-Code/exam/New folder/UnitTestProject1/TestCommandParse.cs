using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalendarSystem;
using System.Text;

namespace TestCalendarSystem
{
    [TestClass]
    public class TestCommandParse
    {
        [TestMethod]
        public void TestCommandParse_WhenValidCommand_AddEvent()
        {
            string input = "AddEvent 2012-01-21T20:00:00 | party Viki | home";
            Command command =  Command.Parse(input);
            string expected = input;
            string actualCmdType = command.CommandType;
            string[] actualParams = command.paramms;

            StringBuilder actual = new StringBuilder();
            actual.Append(actualCmdType);
            actual.Append(" ");
            for (int param = 0; param < actualParams.Length; param++)
            {
                actual.Append(actualParams[param]);
                if (param != actualParams.Length - 1)
                {
                    actual.Append(" | ");
                }
            }

            Assert.AreEqual(expected, actual.ToString());
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestCommandParse_WhenInvalidCommand()
        {
            string input = "AddEvent";
            Command command = Command.Parse(input);
        }

        [TestMethod]
        public void TestCommandParse_WhenValidCommand_ListEvents()
        {
            string input = "ListEvents 2012-03-07T08:00:00 | 3";
            Command command = Command.Parse(input);
            
            string actualCmdType = command.CommandType;
            string[] actualParams = command.paramms;

            StringBuilder actual = new StringBuilder();
            actual.Append(actualCmdType);
            actual.Append(" ");
            for (int param = 0; param < actualParams.Length; param++)
            {
                actual.Append(actualParams[param]);
                if (param != actualParams.Length - 1)
                {
                    actual.Append(" | ");
                }
            }

            string expected = input;
            Assert.AreEqual(expected, actual.ToString());
        }

        [TestMethod]
        public void TestCommandParse_WhenValidCommand_DeleteEvent()
        {
            string input = "DeleteEvents My granny's bushes";
            Command command = Command.Parse(input);
            string expected = input;
            string actualCmdType = command.CommandType;
            string[] actualParams = command.paramms;

            StringBuilder actual = new StringBuilder();
            actual.Append(actualCmdType);
            actual.Append(" ");
            for (int param = 0; param < actualParams.Length; param++)
            {
                actual.Append(actualParams[param]);
                if (param != actualParams.Length - 1)
                {
                    actual.Append(" | ");
                }
            }

            Assert.AreEqual(expected, actual.ToString());
        }

        //throw exception because  Command.Parse is called after 
        //the check for "End" int CalendarExecutor.cs
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestCommandParse_WhenValidCommand_End()
        {
            string input = "End";
            Command command = Command.Parse(input);
        }
    }
}

