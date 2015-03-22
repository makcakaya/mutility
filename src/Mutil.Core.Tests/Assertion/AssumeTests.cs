using Moq;
using Mutil.Core.Assertion;
using Mutil.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mutil.Core.Tests.Assertion
{
    public class AssumeTests
    {
        [Fact]
        public void Assume_Logs()
        {
            var logged = false;
            var logger = new Mock<IAssertionLogger>();
            var assumptionId = "TestAssumption";
            logger.Setup(l => l.AssumptionFailed(assumptionId, null)).Callback(() => logged = true);
            AssertionLogger.Instance = logger.Object;

            Assume.That(false, assumptionId, null);

            Assert.True(logged);
        }
    }
}
