using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Replify.Net
{
    using Extensions;
    public abstract class BaseCommand
    {
        abstract public void Run(String param = "");

        [Parameter(key: "help", ShortKey = "h")]
        public virtual String Help { set { this.WriteAllSubCommandForACommand(); } }

        protected void WriteAllSubCommandForACommand()
        {
            var commandType = this.GetType();
            this.WriteAllSubCommands(properties: commandType.GetProperties());
        }

        protected void WriteAllSubCommands(PropertyInfo[] properties)
        {
            foreach (var property in properties)
            {
                if (property.Name == "Help") continue;

                var getPropertyAttributes = property.GetAttribute<ParameterAttribute>();
                if (getPropertyAttributes == null) continue;

                ConsoleExtensions.WriteLineInfo($"--{getPropertyAttributes.Key}\t\t--{getPropertyAttributes.ShortKey}\t\t{(getPropertyAttributes.Required == true ? "is required" : "is optional") }\t\t{getPropertyAttributes.HelpText}");
            }
        }
    }
}
