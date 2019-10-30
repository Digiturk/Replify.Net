using System;
using System.Collections.Generic;
using System.Text;

namespace Replify.Net
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CommandAttribute : Attribute
    {
        public CommandAttribute(String command, String helpText = default(string))
        {
            this.Command = command;
            this.HelpText = helpText;
        }
        public String Command { get; set; }

        public String HelpText { get; set; } = string.Empty;
    }
}
