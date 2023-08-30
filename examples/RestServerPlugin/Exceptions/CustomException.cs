using System;

namespace Neo.Plugins.Example.Exceptions
{
    internal class CustomException : Exception
    {
        public CustomException() { }
        public CustomException(string message) : base(message) { }
    }
}
