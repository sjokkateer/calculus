﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXpressionParsing
{
    class InvalidScalarMultipleException : Exception
    {
        public InvalidScalarMultipleException(string message) : base(message)
        { }
        public InvalidScalarMultipleException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
