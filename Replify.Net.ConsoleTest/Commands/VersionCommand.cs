using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Replify.Net.ConsoleTest.Commands
{
    [Command("version", helpText: "This text is for the Version Command")]
    public class VersionCommand : BaseCommand
    {

        [Parameter("deneme", ShortKey = "d", HelpText = "Deneme Property'si")]
        public int Deneme { get; set; }


        public override void Run(String param)
        {
            var version = Assembly.GetExecutingAssembly().ImageRuntimeVersion;
            ReplifyConsole.WriteLine(version);
        }
    }
}
