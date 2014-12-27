using System;

namespace Mutil.Core.Exceptions
{
    /// <summary>
    /// Represents an exception thrown when a readonly field or variable is assigned value for more than once
    /// </summary>
    public sealed class ReadonlyException : Exception
    {
        public ReadonlyException() : base()
        {

        }

        public ReadonlyException(string message) : base(message)
        {

        }

        public ReadonlyException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
