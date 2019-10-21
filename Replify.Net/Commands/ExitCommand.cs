using System;
using System.Collections.Generic;
using System.Text;

namespace Replify.Net.Commands
{
    [Command("exit")]
    public class ExitCommand : BaseCommand
    {
        [Parameter(key: "help", ShortKey = "h", HelpText = "Exit The CLI")]
        public override string Help { set => Extensions.ConsoleExtensions.WriteLineInfo("Exit Commands Help Command Runned"); }

        public override void Run(String name)
        {
        }
    }
}
