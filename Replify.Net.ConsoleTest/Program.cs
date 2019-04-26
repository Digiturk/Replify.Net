using Replify.Net.Commands;
using Replify.Net.ConsoleTest.Commands;
using System;

namespace Replify.Net.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Replify.RegisterCommand<ExitCommand>();
            Replify.RegisterCommand<VersionCommand>();
            Replify.RegisterCommand<ViewFileCommand>();

            Replify.Start();
        }
    }
}
