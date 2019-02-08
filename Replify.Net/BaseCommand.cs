using System;
using System.Collections.Generic;
using System.Text;

namespace Replify.Net
{
    public abstract class BaseCommand
    {
        abstract public void Run();
    }

    public abstract class BaseCommand<T> : BaseCommand where T : ICommandParameter
    {
        public T Parameters { get; set; }
    }

    public interface ICommandParameter
    {

    }
}
