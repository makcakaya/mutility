using System;

namespace Mutil.Core.Exceptions
{
    /// <summary>
    /// Represents an exception thrown when a readonly field or variable is assigned value for more than once
    /// </summary>
    public sealed class WriteOnceException : Exception
    {
        public WriteOnceException() : base()
        {

        }

        public WriteOnceException(string message) : base(message)
        {

        }

        public WriteOnceException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
