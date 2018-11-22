using System;

namespace eXpressionParsing
{
    class InvalidNumberException : Exception
    {
        public InvalidNumberException(string message) : base(message)
        { }

        public InvalidNumberException(string message, Exception innerException): base(message, innerException)
        { }
    }
}
