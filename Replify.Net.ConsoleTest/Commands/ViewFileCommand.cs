using System;
using System.Collections.Generic;
using System.Text;

namespace Replify.Net.ConsoleTest.Commands
{
    public class ViewFileCommand : BaseCommand<ViewFileCommandParameter>
    {
        public override void Run()
        {
            
            Console.WriteLine("file command executed: " + Parameters.Path);
        }
    }

    public class ViewFileCommandParameter : ICommandParameter
    {
        [Parameter("path")]
        public String Path { get; set; } = "Trial";
    }


}
