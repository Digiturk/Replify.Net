using System;
using System.Collections.Generic;
using System.Text;

namespace Replify.Net
{
    public static class ReplifyExtensionMethods
    {
        public static string GetNameWithoutGenericArity(this Type t)
        {
            string name = t.Name;
            int index = name.IndexOf('`');
            return index == -1 ? name : name.Substring(0, index);
        }
    }
}
