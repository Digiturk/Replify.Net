using Replify.Net.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Replify.Net
{
    public static class Replify
    {
        private static Dictionary<string, Type> _Commands = new Dictionary<string, Type>();

        public static void RegisterCommand<CommandType>(String key = "") where CommandType : BaseCommand
        {
            var commandType = typeof(CommandType);
            var commandKey = key;

            if (String.IsNullOrEmpty(commandKey))
            {
                var commandAttribute = commandType.GetAttribute<CommandAttribute>();
                if(commandAttribute == null)
                {
                    throw new Exception("Command should have CommandAttribute when key is empty!");
                }

                commandKey = commandAttribute.Command;
            }

            if (_Commands.ContainsKey(commandKey))
            {
                throw new Exception("Command " + commandKey + " is already registered!");
            }
            else
            {
                _Commands.Add(commandKey, commandType);
            }
        }

        public static void Start()
        {
            while(true)
            {
                Console.Write(">");
                var commandText = Console.ReadLine();
                var commandKey = commandText; // TODO parse command according parameters

                if (!_Commands.ContainsKey(commandKey))
                {
                    ReplifyConsole.WriteLine("Unknown Command!!!", OutputType.Warning);
                    continue;
                }

                var commandType = _Commands[commandKey];
                if(commandType == typeof(ExitCommand))
                {
                    break;
                }
                else
                {
                    var command = Activator.CreateInstance(commandType) as BaseCommand;

                    // TODO Parse parameters

                    command.Run();
                }
            }
        }
    }
}
