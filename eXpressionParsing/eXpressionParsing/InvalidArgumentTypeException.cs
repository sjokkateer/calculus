using System;

namespace eXpressionParsing
{
    class InvalidArgumentTypeException : Exception
    {
        public InvalidArgumentTypeException(string message) : base(message)
        { }

        public InvalidArgumentTypeException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
