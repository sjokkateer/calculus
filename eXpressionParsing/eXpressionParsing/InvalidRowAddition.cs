using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class InvalidRowAddition : Exception
    {
        public InvalidRowAddition(string message) : base(message)
        { }

        public InvalidRowAddition(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
