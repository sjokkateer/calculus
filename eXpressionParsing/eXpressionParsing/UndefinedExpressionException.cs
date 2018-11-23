using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class UndefinedExpressionException : Exception
    {
        public UndefinedExpressionException(string message) : base(message)
        { }
        public UndefinedExpressionException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
