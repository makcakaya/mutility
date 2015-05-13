using System;
using System.Collections.Generic;
using System.Linq;

namespace Mutil.Core.Assertion
{
    /// <summary>
    /// Provides methods to handle assertions and throwing exceptions when assertions fail.
    /// </summary>
    public static class Ensure
    {
        private static readonly IAndNotEmpty NotEmptyOp = new AndNotEmpty();
        private static readonly IAndNotWhiteSpace NotWhiteSpaceOp = new AndNotWhiteSpace();
        private static readonly IAndNotNull NotNullOp = new AndNotNull();

        public static IAndThat That(bool value)
        {
            return new AndThat(value);
        }

        public static IAndNotNull NotNull<T>(T argument, string argumentName = null) where T : class
        {
            return NotNullOp.And(argument, argumentName);
        }

        public static IAndNotEmpty NotEmpty(string argument, string argumentName = null)
        {
            return NotEmptyOp.And(argument, argumentName);
        }

        public static IAndNotWhiteSpace NotWhiteSpace(string argument, string argumentName = null)
        {
            return NotWhiteSpaceOp.And(argument, argumentName);
        }

        public static void Contains<T>(IEnumerable<T> collection, T value)
        {
            if (!collection.Contains(value))
            {
                throw new InvalidOperationException(string.Format("{0} collection does not contain {1}", collection, value));
            }
        }
    }
}
