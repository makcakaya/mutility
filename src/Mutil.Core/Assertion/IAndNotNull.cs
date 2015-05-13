
namespace Mutil.Core.Assertion
{
    /// <summary>
    /// Null argument checking utility with fluent interface.
    /// </summary>
    public interface IAndNotNull
    {
        /// <summary>
        /// Ensure the given argument is not null by throwing <see cref="ArgumentNullException"/> with the given argument name if it is null.
        /// </summary>
        /// <typeparam name="T">Only class types are supported.</typeparam>
        /// <param name="argument">Argument to be null checked.</param>
        /// <param name="argumentName">Argument name to be passed to the exception.</param>
        /// <returns></returns>
        IAndNotNull And<T>(T argument, string argumentName = null) where T : class;
    }
}
