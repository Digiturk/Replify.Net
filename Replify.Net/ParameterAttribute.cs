using System;
using System.Collections.Generic;
using System.Text;

namespace Replify.Net
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ParameterAttribute : Attribute
    {
        public ParameterAttribute(String key)
        {
            this.Key = key;
        }

        public String ShortKey { get; set; }
        public String Key { get; }
        public bool Required { get; set; } = false;
        public String HelpText { get; set; } = String.Empty;
    }
}
