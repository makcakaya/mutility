
namespace Mutil.Core.Assertion
{
    /// <summary>
    /// Empty string argument checking utility with fluent interface.
    /// </summary>
    public interface IAndNotEmpty
    {
        /// <summary>
        /// Ensures the given argument is not a null or empty string by throwing <see cref="ArgumentException"/> with the given argument name otherwise.
        /// </summary>
        /// <param name="argument">Argument to be checked.</param>
        /// <param name="argumentName">Argument name to be passed to the expcetion.</param>
        /// <returns></returns>
        IAndNotEmpty And(string argument, string argumentName);
    }
}
