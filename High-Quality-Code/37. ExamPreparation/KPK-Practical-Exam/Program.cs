namespace FreeContentCatalog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder();
            Catalog catalog = new Catalog();
            ICommandExecutor commandExecutor = new CommandExecutor();

            foreach (ICommand item in Parse())
            {
                commandExecutor.ExecuteCommand(catalog, item, output);
            }

            Console.Write(output);
        }

        private static List<ICommand> Parse()
        {
            List<ICommand> commandList = new List<ICommand>();
            bool isEnd = false;

            do
            {
                string commandLine = Console.ReadLine();
                isEnd = commandLine.Trim() == "End";
                if (!isEnd)
                {
                    commandList.Add(new Command(commandLine));
                }
            }
            while (!isEnd);

            return commandList;
        }
    }
}