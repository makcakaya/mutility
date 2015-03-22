namespace Mutil.Core.Assertion
{
    public static class Assume
    {
        public static void That(bool assumption, string assumptionId, string message = null)
        {
            if (assumption) { return; }

            AssertionLogger.Instance.AssumptionFailed(assumptionId, message);
        }
    }
}
