using System;

namespace eXpressionParsing
{
    class InvalidExpressionException : Exception
    {
        public InvalidExpressionException(string message) : base(message)
        { }

        public InvalidExpressionException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
