using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
