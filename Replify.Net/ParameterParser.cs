using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace Replify.Net
{
    public class ParameterParser
    {
        public static CommandParameterSet Parse(String text)
        {
            var parts = Regex.Matches(text, @"[\""].+?[\""]|[^ ]+").Cast<Match>().Select(m => m.Value).ToList();
            var result = new CommandParameterSet();

            result.CommandName = parts[0];
            result.DefaultParameter = String.Empty;
            result.Parameters = new List<CommandParameter>();

            if (parts.Count == 1)
            {
                return result;
            }

            var i = 1;
            if (!parts[i].StartsWith("-"))
            {
                result.DefaultParameter = parts[i];
                i++;
            }

            while(i < parts.Count)
            {
                var key = String.Empty;
                var shortKey = String.Empty;
                var value = String.Empty;

                if (parts[i].StartsWith("--"))
                {
                    key = parts[i].Substring(2);
                }
                else if(parts[i].StartsWith("-"))
                {
                    shortKey = parts[i].Substring(1);
                }
                else
                {
                    throw new Exception("Wrong parameter prefix " + parts[i]);
                }

                i++;

                if(i < parts.Count)
                {
                    if(parts[i].StartsWith("-") == false)
                    {
                        value = parts[i];
                        i++;
                    }
                }


                result.Parameters.Add(new CommandParameter()
                {
                    Key = key,
                    ShortKey = shortKey,
                    Value = value
                });
            }

            return result;
        }        
    }

    public class CommandParameterSet
    {
        public String CommandName { get; set; }
        public String DefaultParameter { get; set; }
        public List<CommandParameter> Parameters { get; set; }
    }

    public class CommandParameter
    {
        public String Key { get; set; }
        public String ShortKey { get; set; }
        public String Value { get; set; }
    }
}
