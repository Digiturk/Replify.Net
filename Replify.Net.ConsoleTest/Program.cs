using Replify.Net.Commands;
using Replify.Net.ConsoleTest.Commands;
using System;
using System.Reflection;

namespace Replify.Net.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Replify.RegisterAssembly(Assembly.GetExecutingAssembly());
            Replify.RegisterAssembly("Replify.Net");
            //Replify.Register<ExitCommand>();
            //Replify.Register<VersionCommand>();
            //Replify.Register<ViewFileCommand>();

            Replify.Start();
        }
    }
}
