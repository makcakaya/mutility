using System;
using Xunit;

namespace Mutil.Core.Tests.Assertion
{
    public class EnsureTests
    {
        [Fact]
        public void That_ThrowsWhenNotSatisfied()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void That_DoesNotThrowIfSatisfied()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void NotNull_ThrowsIfNotSatisfied()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void NotNull_DoesNotThrowIfSatisfied()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Contains_ThrowsIfNotSatisfied()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Contains_DoesNotThrowIfSatisfied()
        {
            throw new NotImplementedException();
        }
    }
}
