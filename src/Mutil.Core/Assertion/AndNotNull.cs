using System;

namespace Mutil.Core.Assertion
{
    public sealed class AndNotNull : IAndNotNull
    {
        public IAndNotNull And<T>(T argument, string argumentName = null) where T : class
        {
            if (object.ReferenceEquals(argument, null))
            {
                throw new ArgumentNullException(argumentName);
            }

            return this;
        }
    }
}
