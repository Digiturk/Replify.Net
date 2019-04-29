using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Replify.Net
{
    public static class ReplifyExtensionMethods
    {
        public static T GetAttribute<T>(this Type t) where T : Attribute
        {
            foreach (var obj in t.GetCustomAttributes(false))
            {
                if (obj.GetType() == typeof(T))
                {
                    return (T)obj;
                }
            }

            return null;
        }

        public static T GetAttribute<T>(this PropertyInfo t) where T : Attribute
        {
            foreach (var obj in t.GetCustomAttributes(false))
            {
                if (obj.GetType() == typeof(T))
                {
                    return (T)obj;
                }
            }

            return null;
        }
    }
}
