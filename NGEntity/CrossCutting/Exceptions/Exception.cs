using NGNotification.Models;
using System;

namespace NGEntity.Exceptions
{
    public class ContextAlreadyExists : NGException
    {
        public ContextAlreadyExists(string header, string message) : base(header, message, "") { }
        public ContextAlreadyExists(string message) : base("", message) { }
    }

    public class ContextNotExists : NGException
    {
        public ContextNotExists(string header, string message) : base(header, message, "") { }
        public ContextNotExists(string message) : base("", message) { }
    }
    public class TypeNotExistInContext : NGException
    {
        public TypeNotExistInContext(string header, string message) : base(header, message, "") { }
        public TypeNotExistInContext(string message) : base("", message) { }
    }
    public class TypeInToManyContext : NGException
    {
        public TypeInToManyContext(string header, string message) : base(header, message, "") { }
        public TypeInToManyContext(string message) : base("", message) { }
    }
}
