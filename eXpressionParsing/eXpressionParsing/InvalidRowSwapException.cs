using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class InvalidRowSwapException : Exception
    {
        public InvalidRowSwapException(string message) : base(message)
        { }

        public InvalidRowSwapException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
