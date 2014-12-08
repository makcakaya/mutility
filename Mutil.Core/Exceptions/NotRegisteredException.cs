using System;

namespace Mutil.Core.Exceptions
{
    public class NotRegisteredException : MutilException
    {
        public Type NotRegisteredType { get; private set; }

        public NotRegisteredException()
        {

        }

        public NotRegisteredException(Type notRegisteredType)
        {
            this.NotRegisteredType = notRegisteredType;
        }

        public NotRegisteredException(Type notRegisteredType, string message) : base(message)
        {
            this.NotRegisteredType = notRegisteredType;
        }

        public NotRegisteredException(Type notRegisteredType, string message, Exception inner) : base(message, inner)
        {
            this.NotRegisteredType = notRegisteredType;
        }
    }
}
