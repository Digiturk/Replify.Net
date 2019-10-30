using System;
using System.Collections.Generic;
using System.Text;

namespace Replify.Net.ConsoleTest.Commands
{
    [Command("view", helpText: "This text is for the ViewFile Command")]
    public class ViewFileCommand : BaseCommand
    {
        [Parameter("line", ShortKey = "l", HelpText = "Sayfaya ait gosterilecek satir sayisi")]
        public String LineCount { get; set; }

        [Parameter("deneme", ShortKey = "d", HelpText = "Deneme Property'si")]
        public int Deneme { get; set; }

        [Parameter("palamut", ShortKey = "p", HelpText = "Palamut Propertysi")]
        public int Palamut { get; set; }

        public override void Run(String fileName)
        {
            Console.WriteLine("file command executed: " + fileName + " " + this.LineCount + " lines");
        }
    }
}
