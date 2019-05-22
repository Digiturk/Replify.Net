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

        public static void Register<CommandType>(String key = "") where CommandType : BaseCommand
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
                var parameterSet = ParameterParser.Parse(commandText);                

                if (!_Commands.ContainsKey(parameterSet.CommandName))
                {
                    ReplifyConsole.WriteLine("Unknown Command!!!", OutputType.Warning);
                    continue;
                }

                var commandType = _Commands[parameterSet.CommandName];
                if(commandType == typeof(ExitCommand))
                {
                    break;
                }
                else
                {
                    var command = Activator.CreateInstance(commandType) as BaseCommand;

                    var props = commandType.GetProperties();
                    foreach(var prop in props)
                    {
                        var parameterAttibute = prop.GetAttribute<ParameterAttribute>();
                        if(parameterAttibute == null)
                        {
                            continue;
                        }

                        var parameter = parameterSet.Parameters.Find(p => 
                            (!String.IsNullOrEmpty(parameterAttibute.Key) && p.Key == parameterAttibute.Key) ||
                            (!String.IsNullOrEmpty(parameterAttibute.ShortKey) && p.ShortKey == parameterAttibute.ShortKey));

                        if(parameter == null)
                        {
                            if(parameterAttibute.Required)
                            {
                                throw new Exception(parameterAttibute.Key + " parameter is missing");
                            }
                            else
                            {
                                continue;
                            }
                        }

                        prop.SetValue(command, parameter.Value);
                    }

                    command.Run(parameterSet.DefaultParameter);
                }
            }
        }
    }
}
