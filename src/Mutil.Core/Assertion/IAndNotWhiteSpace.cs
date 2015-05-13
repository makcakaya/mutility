
namespace Mutil.Core.Assertion
{
    /// <summary>
    /// White space string argument checking utility with fluent interface.
    /// </summary>
    public interface IAndNotWhiteSpace
    {
        /// <summary>
        /// Ensures the given argument is not a null or white space string by throwing <see cref="ArgumentException"/> with the given argument name otherwise.
        /// </summary>
        /// <param name="argument">Argument to be checked.</param>
        /// <param name="argumentName">Name of the argument to pass to the exception.</param>
        /// <returns></returns>
        IAndNotWhiteSpace And(string argument, string argumentName);
    }
}
