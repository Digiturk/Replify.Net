using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Replify.Net.ConsoleTest.Commands
{
    public class VersionCommand : BaseCommand
    {
        public override void Run()
        {
            var version = Assembly.GetExecutingAssembly().ImageRuntimeVersion;
            ReplifyConsole.WriteLine(version);
        }
    }    
}
