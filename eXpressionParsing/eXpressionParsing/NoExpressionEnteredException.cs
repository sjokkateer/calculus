using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class NoExpressionEnteredException : Exception
    {
        public NoExpressionEnteredException(string message) : base(message)
        { }

        public NoExpressionEnteredException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
