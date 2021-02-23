using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AlinSpace.FluentExceptions.Tests
{
    /// <summary>
    /// Unit tests for Try-Catch-Ignore method variants (with specific exceptions).
    /// </summary>
    public class TryCatchIgnore_Specific
    {
        [Fact]
        public void TryCatchIgnore_1()
        {
            // Setup
            var mock = new Mock<ITryCatchFinally>();
            var m = mock.Object;

            // Act
            Try.CatchIgnore<InvalidCastException>(m.Try);

            // Assert
            mock.Verify(m => m.Try(), Times.Once);
        }

        [Fact]
        public void TryCatchIgnore_2()
        {
            // Setup
            var ex = new InvalidCastException();

            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.Try()).Throws(ex);

            var m = mock.Object;

            // Act
            Try.CatchIgnore<InvalidCastException>(m.Try);

            // Assert
            mock.Verify(m => m.Try(), Times.Once);
        }

        [Fact]
        public void TryCatchIgnore_3()
        {
            // Setup
            var ex = new ArgumentOutOfRangeException();

            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.Try()).Throws(ex);

            var m = mock.Object;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                // Act.
                Try.CatchIgnore<InvalidCastException>(m.Try);
            });

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
            await Try.CatchIgnoreAsync<InvalidCastException>(m.TryAsync);

            // Assert
            mock.Verify(m => m.TryAsync(), Times.Once);
        }

        [Fact]
        public async Task TryCatchIgnoreAsync_2()
        {
            // Setup
            var ex = new InvalidCastException();

            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.TryAsync()).Throws(ex);

            var m = mock.Object;

            // Act
            await Try.CatchIgnoreAsync<InvalidCastException>(m.TryAsync);

            // Assert
            mock.Verify(m => m.TryAsync(), Times.Once);
        }

        [Fact]
        public async Task TryCatchIgnoreAsync_3()
        {
            // Setup
            var ex = new ArgumentOutOfRangeException();

            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.TryAsync()).Throws(ex);

            var m = mock.Object;

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                // Act.
                await Try.CatchIgnoreAsync<InvalidCastException>(m.TryAsync);
            });

            // Assert
            mock.Verify(m => m.TryAsync(), Times.Once);
        }
    }
}
