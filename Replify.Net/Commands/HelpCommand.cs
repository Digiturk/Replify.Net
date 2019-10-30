using System;
using System.Collections.Generic;
using System.Text;

namespace Replify.Net.Commands
{
    using Extensions;

    [Command(command: "help")]
    public class HelpCommand : BaseCommand
    {
        public override void Run(string param = "")
        {
            var allCommands = Replify.AllCommands();
            foreach (var command in allCommands)
            {
                var getCommandAttributes = command.Value.GetAttribute<CommandAttribute>();
                ConsoleExtensions.WriteLineInfo($"{command.Key}\t\t{getCommandAttributes.HelpText}");
                ConsoleExtensions.WriteLineInfo(value: "------------------------------------------");
                this.WriteAllSubCommands(command.Value.GetProperties());
                ConsoleExtensions.WriteLineInfo(value: "==========================================");
            }
        }



    }
}
