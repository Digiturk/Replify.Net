using System;
using System.Collections.Generic;
using System.Text;

namespace Replify.Net
{
    public abstract class BaseCommand
    {
        public abstract String Help { set; }

        abstract public void Run(String param = "");
    }
}
