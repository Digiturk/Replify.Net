using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Replify.Net.ConsoleTest.Commands
{
    [Command("version")]
    public class VersionCommand : BaseCommand
    {
        public override void Run(String param)
        {
            var version = Assembly.GetExecutingAssembly().ImageRuntimeVersion;
            ReplifyConsole.WriteLine(version);
        }
    }    
}
