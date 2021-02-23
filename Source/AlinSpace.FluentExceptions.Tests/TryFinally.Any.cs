using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AlinSpace.FluentExceptions.Tests
{
    /// <summary>
    /// Unit tests for Try-Finally method variants.
    /// </summary>
    public class TryFinally_Any
    {
        [Fact]
        public void TryFinally_1()
        {
            // Setup
            var mock = new Mock<ITryCatchFinally>();
            var m = mock.Object;

            // Act
            Try.Finally(m.Try, m.Finally);

            // Assert
            mock.Verify(m => m.Try(), Times.Once);
            mock.Verify(m => m.Finally(), Times.Once);
        }

        [Fact]
        public void TryFinally_2()
        {
            // Setup
            var ex = new InvalidCastException();
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.Try()).Throws(ex);

            var m = mock.Object;

            Assert.Throws<InvalidCastException>(() =>
            {
                // Act
                Try.Finally(m.Try, m.Finally);
            });

            // Assert
            mock.Verify(m => m.Try(), Times.Once);
            mock.Verify(m => m.Finally(), Times.Once);
        }

        [Fact]
        public async Task TryFinallyAsync_1()
        {
            // Setup
            var mock = new Mock<ITryCatchFinally>();
            var m = mock.Object;

            // Act
            await Try.FinallyAsync(m.TryAsync, m.Finally);

            // Assert
            mock.Verify(m => m.TryAsync(), Times.Once);
            mock.Verify(m => m.Finally(), Times.Once);
        }

        [Fact]
        public async Task TryFinallyAsync_2()
        {
            // Setup
            var ex = new InvalidCastException();
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.TryAsync()).Throws(ex);

            var m = mock.Object;

            await Assert.ThrowsAsync<InvalidCastException>(async () =>
            {
                // Act
                await Try.FinallyAsync(m.TryAsync, m.FinallyAsync);
            });

            // Assert
            mock.Verify(m => m.TryAsync(), Times.Once);
            mock.Verify(m => m.FinallyAsync(), Times.Once);
        }
    }
}
