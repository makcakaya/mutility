using Mutil.Core.Logging;
using System;

namespace Mutil.Core.Assertion
{
    public class AssertionLogger
    {
        public static IAssertionLogger Instance { get; set; }

        public static void Log(Exception ex, string message = null)
        {
            if (Instance == null) { return; }

            Instance.Exception(ex, message);
        }

        public static void Log(string assumptionId, string message = null)
        {
            if (Instance == null) { return; }

            Instance.AssumptionFailed(assumptionId, message);
        }
    }
}
