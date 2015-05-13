using Mutil.Core.Assertion;
using NLog;

namespace Mutil.Core.Logging
{
    public sealed class NLogFactory : ILoggerFactory
    {
        public ILogger Get(string loggerName)
        {
            Ensure.NotWhiteSpace(loggerName, "loggerName");

            return new NLogAdapter(LogManager.GetLogger(loggerName));
        }
    }
}
