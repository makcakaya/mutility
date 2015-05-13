using Mutil.Core.Assertion;
using System;
using System.Collections.Generic;
using Xunit;

namespace Mutil.Core.Tests.Assertion
{
    public class EnsureTests
    {
        [Fact]
        public void That_ThrowsWhenNotSatisfied()
        {
            Assert.Throws<InvalidOperationException>(() => Ensure.That(false).OrThrow());
            Assert.Throws<ArgumentException>(() => Ensure.That(false).OrThrow(new ArgumentException()));
            Assert.Throws<InvalidOperationException>(() => Ensure.That(true).And(false).OrThrow());
            Assert.Throws<InvalidOperationException>(() => Ensure.That(false).And(true).OrThrow());
        }

        [Fact]
        public void That_DoesNotThrowIfSatisfied()
        {
            Ensure.That(true).OrThrow();
            Ensure.That(true).And(true).OrThrow();
        }

        [Fact]
        public void NotNull_ThrowsIfNotSatisfied()
        {
            Assert.Throws<ArgumentNullException>(() => Ensure.NotNull((string)null));
            Assert.Throws<ArgumentNullException>(() => Ensure.NotNull("").And((object)null));
            Assert.Throws<ArgumentNullException>(() => Ensure.NotNull((object)null).And(""));
        }

        [Fact]
        public void NotNull_DoesNotThrowIfSatisfied()
        {
            Ensure.NotNull("");
            Ensure.NotNull("").And(new object());
        }

        [Fact]
        public void Contains_ThrowsIfNotSatisfied()
        {
            var collection = new List<string>();

            Assert.Throws<InvalidOperationException>(() => Ensure.Contains(collection, "test"));
        }

        [Fact]
        public void Contains_DoesNotThrowIfSatisfied()
        {
            var value = "test";
            var collection = new List<string> { value };

            Ensure.Contains(collection, value);
        }
    }
}