using System;
using System.Collections.Generic;
using System.Text;

namespace Replify.Net.Commands
{
    using Extensions;

    [Command(command: "help")]
    public class HelpCommand : BaseCommand
    {
        public override string Help { set => throw new NotImplementedException(); }

        public override void Run(string param = "")
        {
            var allCommands = Replify.AllCommands();

            foreach (var command in allCommands)
                if (command.Key != "help")
                {
                    var getAttributeParameters = command.Value.GetProperty(name: "Help").GetAttribute<ParameterAttribute>();

                    ConsoleExtensions.WriteLineInfo(value: $"{command.Key}\t\t{getAttributeParameters.Key}\t\t{getAttributeParameters.ShortKey}\t\t{getAttributeParameters.HelpText}");
                }
        }
    }
}
