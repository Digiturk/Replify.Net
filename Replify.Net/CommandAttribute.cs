using System;
using System.Collections.Generic;
using System.Text;

namespace Replify.Net
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CommandAttribute : Attribute
    {
        public CommandAttribute(String command)
        {
            this.Command = command;
        }

        public String Command { get; set; }        
    }
}
