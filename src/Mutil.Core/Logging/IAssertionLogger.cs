using System;

namespace Mutil.Core.Logging
{
    public interface IAssertionLogger
    {
        void Exception(Exception exception, string message = null);

        void AssumptionFailed(string assumptionId, string message = null);
    }
}
