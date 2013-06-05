using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CalendarSystem
{
    public class CommandExecutor
    {
        private readonly IEventsManager eventsManager;

        public CommandExecutor(IEventsManager eventsManager)
        {
            this.eventsManager = eventsManager;
        }

        public IEventsManager EventsProcessor
        {
            get
            {
                return this.eventsManager;
            }
        }

        public string ProcessCommand(Command command)
        {
            switch (command.CommandType)
            {
                case "AddEvent": return AddEvent(command);
                case "DeleteEvents": return DeleteEvents(command);
                case "ListEvents": return ListEvents(command);
                default: throw new ArgumentException("This " + command.CommandType + " is not valid!");
            }
            
        }

        private string AddEvent(Command command)
        {
            var date = DateTime.ParseExact(
                command.paramms[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            if (command.paramms.Length == 2)
            {
                var ev = new Event
                {
                    date = date,
                    Title = command.paramms[1],
                    Location = null,
                };

                this.eventsManager.AddEvent(ev);
            }

            if (command.paramms.Length == 3)
            {
                var ev = new Event
                {
                    date = date,
                    Title = command.paramms[1],
                    Location = command.paramms[2],
                };

                this.eventsManager.AddEvent(ev);

            }
                return "Event added";
        }

        private string DeleteEvents(Command command)
        {
                int count = this.eventsManager.DeleteEventsByTitle(command.paramms[0]);

                if (count == 0)
                {
                    return "No events found";
                }

                return count + " events deleted";
        }

        private string ListEvents(Command command)
        {
            var date = DateTime.ParseExact(command.paramms[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            var title = command.paramms[1];
            var commandParam = int.Parse(command.paramms[1]);
            var events = this.eventsManager.ListEvents(date, commandParam).ToList();
            var output = new StringBuilder();

            if (!events.Any())
            {
                return "No events found";
            }

            foreach (var ev in events)
            {
                output.AppendLine(ev.ToString());
            }

            return output.ToString().Trim();
        }
    }
}
