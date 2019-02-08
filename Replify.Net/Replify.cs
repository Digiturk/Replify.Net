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

        private static void Register(String key, Type commandType)
        {
            if (_Commands.ContainsKey(key))
            {
                _Commands[key] = commandType;
            }
            else
            {
                _Commands.Add(key, commandType);
            }
        }

        public static void RegisterCommand<CommandType, ParameterType>(String key) where ParameterType : ICommandParameter where CommandType : BaseCommand<ParameterType> 
        {
            var commandType = typeof(CommandType);
            Register(key, commandType);
        }

        public static void RegisterCommand<CommandType>(String key) where CommandType : BaseCommand
        {
            var commandType = typeof(CommandType);
            Register(key, commandType);
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

                    if (commandType.BaseType.IsGenericType)
                    {
                        var parameterType = commandType.BaseType.GenericTypeArguments[0];
                        var parameters = Activator.CreateInstance(parameterType) as ICommandParameter;

                        // TODO Parse and fill parameters

                        commandType.GetProperty("Parameters").SetValue(command, parameters);


                    }

                    command.Run();
                }
            }
        }
    }
}
