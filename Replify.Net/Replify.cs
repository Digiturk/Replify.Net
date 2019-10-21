using Replify.Net.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;

namespace Replify.Net
{
    public static class Replify
    {
        private static Dictionary<string, Type> _Commands = new Dictionary<string, Type>();

        public static void Register<CommandType>(String key = "") where CommandType : BaseCommand
        {
            var commandType = typeof(CommandType);
            Register(commandType, key);
        }

        private static void Register(Type type, String key = "")
        {
            if (String.IsNullOrEmpty(key))
            {
                var commandAttribute = type.GetAttribute<CommandAttribute>();
                if (commandAttribute == null)
                {
                    throw new Exception("Command should have CommandAttribute when key is empty!");
                }

                key = commandAttribute.Command;
            }

            if (_Commands.ContainsKey(key))
            {
                throw new Exception("Command " + key + " is already registered!");
            }
            else
            {
                _Commands.Add(key, type);
            }
        }

        public static void RegisterAssembly(String assemblyName)
        {
            var assembly = Assembly.Load(assemblyName);
            RegisterAssembly(assembly);
        }

        public static void RegisterAssembly(Assembly assembly)
        {
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                if (type.IsSubclassOf(typeof(BaseCommand)))
                {
                    Register(type);
                }
            }
        }

        public static void Start()
        {
            while (true)
            {
                try
                {
                    Console.Write(">");
                    var commandText = Console.ReadLine();
                    if (commandText.Trim().Length == 0)
                    {
                        continue;
                    }

                    var parameterSet = ParameterParser.Parse(commandText);

                    if (!_Commands.ContainsKey(parameterSet.CommandName))
                    {
                        ReplifyConsole.WriteLine("Unknown Command!!!", OutputType.Warning);
                        continue;
                    }

                    var commandType = _Commands[parameterSet.CommandName];
                    if (commandType == typeof(ExitCommand))
                    {
                        break;
                    }
                    else
                    {
                        var command = Activator.CreateInstance(commandType) as BaseCommand;

                        var props = commandType.GetProperties();
                        foreach (var prop in props)
                        {
                            var parameterAttibute = prop.GetAttribute<ParameterAttribute>();
                            if (parameterAttibute == null)
                            {
                                continue;
                            }

                            var parameter = parameterSet.Parameters.Find(p =>
                                (!String.IsNullOrEmpty(parameterAttibute.Key) && p.Key == parameterAttibute.Key) ||
                                (!String.IsNullOrEmpty(parameterAttibute.ShortKey) && p.ShortKey == parameterAttibute.ShortKey));

                            if (parameter == null)
                            {
                                if (parameterAttibute.Required)
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
                catch (Exception ex)
                {
                    Console.WriteLine("An exception occurred when executing command: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// CLI icerisinde olan tum Command'lara ulasilabilen fonksiyon
        /// </summary>
        /// <returns></returns>
        internal static Dictionary<string, Type> AllCommands()
        {
            return _Commands;
        }


    }
}
