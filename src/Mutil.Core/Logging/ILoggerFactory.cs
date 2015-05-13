
namespace Mutil.Core.Logging
{
    /// <summary>
    /// Contract to get an instance of ILogger.
    /// </summary>
    public interface ILoggerFactory
    {
        /// <summary>
        /// Gets an <see cref="ILogger"/> with the given name.
        /// </summary>
        /// <param name="loggerName">Name to be used when creating the logger.</param>
        /// <returns>Instance of <see cref="ILogger"/>.</returns>
        ILogger Get(string loggerName);
    }
}
