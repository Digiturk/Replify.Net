using System;
using System.Collections.Generic;
using System.Text;

namespace Replify.Net
{
    public static class ReplifyConsole
    {
        public static void WriteLine(String text, OutputType outputType = OutputType.Normal)
        {
            Console.WriteLine(text);
        }
    }

    public enum OutputType
    {
        Normal,
        Info,
        Warning,
        Error,
        Success
    }
}
