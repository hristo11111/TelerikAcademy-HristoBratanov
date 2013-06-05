using System;
using System.Linq;

namespace CalendarSystem
{
    public struct Command
    {
        public string CommandType;

        public string[] paramms { get; set; }

        public static Command Parse(string commandLine)
        {
            int firstEmptySpaceIndex = commandLine.IndexOf(' ');
            if (firstEmptySpaceIndex == -1)
            {
                throw new ArgumentException("Invalid command: " + commandLine);
            }

            string name = commandLine.Substring(0, firstEmptySpaceIndex);
            string argument = commandLine.Substring(firstEmptySpaceIndex + 1);

            var commandArguments = argument.Split('|');
            for (int argumentIndex = 0; argumentIndex < commandArguments.Length; argumentIndex++)
            {
                argument = commandArguments[argumentIndex];
                commandArguments[argumentIndex] = argument.Trim();
            }

            var command = new Command{CommandType = name, paramms = commandArguments};

            return command;
        }
    }
}
