using System;
using System.Collections.Generic;
using System.Text;

namespace Replify.Net.ConsoleTest.Commands
{
    [Command("view")]
    public class ViewFileCommand : BaseCommand
    {
        [Parameter("path", ShortKey = "p")]
        public string Path { get; set; }

        public override void Run()
        {            
            Console.WriteLine("file command executed: " + this.Path);
        }
    }
}
