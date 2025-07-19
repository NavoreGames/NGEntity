using NGNotification.Models;
using System;

namespace NGEntity.Exceptions
{
    public class ContextAlreadyExists : NGException
    {
        public ContextAlreadyExists(string alias) : base("Context already exists", $"Context with alias {alias} already exists") { }
        public ContextAlreadyExists() : base("Context already exists", "One context already be created") { }
    }
    public class ContextNotExists : NGException
    {
        public ContextNotExists(string alias) : base("Context not exists", $"Context with alias {alias} not exists") { }
    }
    public class ContextAreMany : NGException
    {
        public ContextAreMany(string header, string message) : base(header, message, "") { }
        public ContextAreMany(string message) : base("", message) { }
    }
    public class CommandNotExists : NGException
    {
        public CommandNotExists(string header, string message) : base(header, message, "") { }
        public CommandNotExists(string message) : base("", message) { }
        public CommandNotExists(Guid identifier) : base("Command not exists", $"Command {identifier} not exists or not found") { }
        
    }
    public class CommandNotGenerated : NGException
    {
        public CommandNotGenerated() : 
            base("cannot generate the command", 
                 "context not initialized or entity not registered in no context",
                 "initialize the context and register the entity or use the overload passing the connection") { }
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
    public class ContextNotInitialize : NGException
    {
        public ContextNotInitialize(string header, string message) : base(header, message, "") { }
        public ContextNotInitialize(string message) : base("", message) { }
        public ContextNotInitialize() : base("", "") { }
    }
}
