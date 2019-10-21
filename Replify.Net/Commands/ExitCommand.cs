using System;
using System.Collections.Generic;
using System.Text;

namespace Replify.Net.Commands
{
    [Command("exit")]
    public class ExitCommand : BaseCommand
    {
        [Parameter(key: "help", ShortKey = "h", HelpText = "ExitCommand icin aciklama")]
        public override string Help => throw new NotImplementedException();

        public override void Run(String name)
        {
        }
    }
}
