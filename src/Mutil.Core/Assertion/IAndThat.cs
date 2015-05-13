using System;

namespace Mutil.Core.Assertion
{
    /// <summary>
    /// Assertion chain building utility with fluent interface.
    /// </summary>
    public interface IAndThat
    {
        /// <summary>
        /// Ensures that the value is true and let's you build fluent call chains.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        IAndThat And(bool value);

        /// <summary>
        /// Ends the chain by throwing an <see cref="InvalidOperationException"/> with the given message.
        /// </summary>
        /// <param name="message">The message that will be passed to the exception to be thrown.</param>
        void OrThrow(string message = null);

        /// <summary>
        /// Ends the chain by throwing the given exception.
        /// </summary>
        /// <param name="exception"></param>
        void OrThrow(Exception exception);
    }
}
