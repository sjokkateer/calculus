using System;

namespace eXpressionParsing
{
    class InvalidFactorialArgumentException : Exception
    {
        public InvalidFactorialArgumentException(string message) : base(message)
        { }
        public InvalidFactorialArgumentException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
