using Replify.Net.Commands;
using Replify.Net.ConsoleTest.Commands;
using System;

namespace Replify.Net.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Replify.Register<ExitCommand>();
            Replify.Register<VersionCommand>();
            Replify.Register<ViewFileCommand>();

            Replify.Start();
        }
    }
}
