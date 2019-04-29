using System;
using System.Collections.Generic;
using System.Text;

namespace Replify.Net.ConsoleTest.Commands
{
    [Command("view")]
    public class ViewFileCommand : BaseCommand
    {   
        [Parameter("line", ShortKey = "l")]
        public String LineCount { get; set; }

        public override void Run(String fileName)
        {            
            Console.WriteLine("file command executed: " + fileName + " " + this.LineCount + " lines");
        }
    }
}
