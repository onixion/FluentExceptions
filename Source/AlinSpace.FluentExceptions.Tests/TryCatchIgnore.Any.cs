using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AlinSpace.FluentExceptions.Tests
{
    /// <summary>
    /// Unit tests for Try-Catch-Ignore method variants.
    /// </summary>
    public class TryCatchIgnore_Any
    {
        [Fact]
        public void TryCatchIgnore_1()
        {
            // Setup
            var mock = new Mock<ITryCatchFinally>();
            var m = mock.Object;

            // Act
            Try.CatchIgnore(m.Try);

            // Assert
            mock.Verify(m => m.Try(), Times.Once);
        }

        [Fact]
        public void TryCatchIgnore_2()
        {
            // Setup
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.Try()).Throws(new Exception());
            var m = mock.Object;

            // Act
            Try.CatchIgnore(m.Try);

            // Assert
            mock.Verify(m => m.Try(), Times.Once);
        }

        [Fact]
        public async Task TryCatchIgnoreAsync_1()
        {
            // Setup
            var mock = new Mock<ITryCatchFinally>();
            var m = mock.Object;

            // Act
            await Try.CatchIgnoreAsync(m.TryAsync);

            // Assert
            mock.Verify(m => m.TryAsync(), Times.Once);
        }

        [Fact]
        public async Task TryCatchIgnoreAsync_2()
        {
            // Setup
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.TryAsync()).Throws(new Exception());
            var m = mock.Object;

            // Act
            await Try.CatchIgnoreAsync(m.TryAsync);

            // Assert
            mock.Verify(m => m.TryAsync(), Times.Once);
        }
    }
}
