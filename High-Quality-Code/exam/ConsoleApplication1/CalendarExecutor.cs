using System;
using System.Linq;

namespace CalendarSystem
{
    public class CalendarExecutor
    {
        public static void Main()
        {
            var eventManager = new EventsManagerFast();
            var cmdExecutor = new CommandExecutor(eventManager);

            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine == "End" || inputLine == null)
                {
                    break;
                }

                try
                {
                    Console.WriteLine(cmdExecutor.ProcessCommand(Command.Parse(inputLine)));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}