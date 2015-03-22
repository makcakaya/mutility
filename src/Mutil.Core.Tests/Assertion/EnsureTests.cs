using Moq;
using Mutil.Core.Assertion;
using Mutil.Core.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Mutil.Core.Tests.Assertion
{
    public class EnsureTests
    {
        [Fact]
        public void That_ThrowsWhenNotSatisfied()
        {
            Assert.Throws<ArgumentException>(() => Ensure.That(false).OrThrow(new ArgumentException()));
        }

        [Fact]
        public void That_DoesNotThrowIfSatisfied()
        {
            Ensure.That(true).OrThrow(new ArgumentException());
        }

        [Fact]
        public void NotNull_ThrowsIfNotSatisfied()
        {
            Assert.Throws<ArgumentNullException>(() => Ensure.NotNull((string)null));
        }

        [Fact]
        public void NotNull_DoesNotThrowIfSatisfied()
        {
            Ensure.NotNull("");
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

        [Fact]
        public void Assertions_CallLogger()
        {
            int logs = 0;
            var logger = new Mock<IAssertionLogger>();
            logger.Setup(l => l.Exception(It.IsAny<Exception>(), null)).Callback(() => logs++);
            AssertionLogger.Instance = logger.Object;

            Assert.Throws<InvalidOperationException>(() => Ensure.Contains(new List<string>(), "test"));
            Assert.Throws<ArgumentException>(() => Ensure.NotEmpty(""));
            Assert.Throws<ArgumentNullException>(() => Ensure.NotNull((string)null));
            Assert.Throws<ArgumentException>(() => Ensure.NotNullOrWhitespace("  "));
            Assert.Throws<FileNotFoundException>(() => Ensure.That(false).OrThrow(new FileNotFoundException()));

            Assert.Equal(5, logs);
        }
    }
}